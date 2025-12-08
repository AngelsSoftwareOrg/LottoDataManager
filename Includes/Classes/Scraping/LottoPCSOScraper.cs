using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Helpers;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public class LottoPCSOScraper : LottoWebScraper
    {
        public event EventHandler<LottoWebScraperEvent> WebScrapingStatus;
        private LottoWebScraperEvent lottoWebScraperEvent = new LottoWebScraperEvent();
        private List<LotteryDetails> lotteriesDetailsArr;
        private LotteryDetails currentLotteryDetailsProcess;
        private DateTime sinceWhenToScrape;
        private readonly string webUrlToScrape = AppSettings.GetLottoScrapeSite;
        private int newRecordsCount;
        List<Lottery> lotteries = new List<Lottery>();

        public void StartScraping(List<LotteryDetails> lotteriesDetailsArr)
        {
            this.lotteriesDetailsArr = lotteriesDetailsArr;
            LotteryDrawResultDao lotteryDao = LotteryDrawResultDaoImpl.GetInstance();
            try
            {
                foreach (LotteryDetails lotteryDetails in this.lotteriesDetailsArr)
                {
                    this.currentLotteryDetailsProcess = lotteryDetails;
                    RaiseEvent(LottoWebScrapingStages.INIT);
                    this.sinceWhenToScrape = lotteryDao.GetLatestDrawDate(lotteryDetails.GameMode);
                    ScrapeWebsite(lotteryDetails, GenerateParametersSingleGame(lotteryDetails));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartScrapingAllGames()
        {
            LotteryDao lotteryDao = LotteryDaoImpl.GetInstance();
            lotteries = lotteryDao.GetLotteries();
            LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            this.lotteriesDetailsArr = new List<LotteryDetails>();

            //Default would be one month back
            DateTime sinceWhenToScrapeLowest = DateTime.Today.AddMonths(-1);

            RaiseEvent(LottoWebScrapingStages.INIT);
            lotteries.ForEach(lottery =>
            {
                sinceWhenToScrapeLowest = lotteryDrawResultDao.GetLatestDrawDate(lottery.GetGameMode());
                if (sinceWhenToScrapeLowest < this.sinceWhenToScrape || this.sinceWhenToScrape == DateTime.MinValue)
                {
                    this.sinceWhenToScrape = sinceWhenToScrapeLowest;
                }
            });
            ScrapeWebsiteAllGames(GenerateParametersAllGames());
        }

        private Dictionary<string, string> GenerateParametersCommon()
        {
            var parameters = new Dictionary<string, string>
                {
                    { "ctl00$ctl00$cphContainer$cpContent$ddlStartMonth", sinceWhenToScrape.ToString("MMMM") }, //e.g. January
                    { "ctl00$ctl00$cphContainer$cpContent$ddlStartDate", sinceWhenToScrape.ToString("d ").Trim() }, //e.g. 1
                    { "ctl00$ctl00$cphContainer$cpContent$ddlStartYear", sinceWhenToScrape.ToString("yyyy") }, //e.g. 2021
                    { "ctl00$ctl00$cphContainer$cpContent$ddlEndMonth", DateTime.Now.ToString("MMMM") },  //e.g. January
                    { "ctl00$ctl00$cphContainer$cpContent$ddlEndDay", DateTime.Now.ToString("d ").Trim() }, // //e.g. 12
                    { "ctl00$ctl00$cphContainer$cpContent$ddlEndYear", DateTime.Now.ToString("yyyy") }, // //e.g. 2020
                    { "ctl00$ctl00$cphContainer$cpContent$btnSearch", "Search+Lotto" },
                    { "ctl00$ctl00$cphContainer$cpRightSidebar$TodaysNationalDraw$hSuspensionFrom", "2020/03/17" },
                    { "ctl00$ctl00$cphContainer$cpRightSidebar$TodaysNationalDraw$hSuspensionTo", "2020/08/07" }
                };
            return parameters;
        }

        private Dictionary<string, string> GenerateParametersSingleGame(LotteryDetails lotteryDetails)
        {
            var parameters = GenerateParametersCommon();
            parameters.Add("ctl00$ctl00$cphContainer$cpContent$ddlSelectGame", lotteryDetails.Lottery.GetWebScrapeGameCode().ToString());  //e.g. 18 for 6/58, refer to PCSO Website for the number
            return parameters;
        }

        private Dictionary<string, string> GenerateParametersAllGames()
        {
            var parameters = GenerateParametersCommon();
            //parameters.Add("ctl00$ctl00$cphContainer$cpContent$ddlSelectGame", ((int) GameMode.ALL).ToString());
            return parameters;
        }

        private Dictionary<string, string> GetSessionBasedParameters(Dictionary<string, string> parameters, IHtmlDocument documentPreLoading)
        {
            IEnumerable<IElement> tableElement = null;
            string[] queryParamName = new string[] { "__EVENTTARGET", "__EVENTARGUMENT",
                    "__VIEWSTATE", "__VIEWSTATEGENERATOR", "__EVENTVALIDATION" };

            foreach (String query in queryParamName)
            {
                tableElement = documentPreLoading.All.Where(x => x.NodeName.Equals("Input", StringComparison.OrdinalIgnoreCase)
                                                                && x.Id.Equals(query, StringComparison.OrdinalIgnoreCase));
                if (tableElement.Any())
                {
                    foreach (IElement element in tableElement)
                    {
                        parameters.Add(query, element.GetAttribute("value"));
                        break;
                    }
                }
                else
                {
                    parameters.Add(query, "");
                }
            }

            return parameters;
        }

        internal async Task<IHtmlDocument> GetWebsiteDOMAsync(Dictionary<string, string> parameters)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var encodedContent = new FormUrlEncodedContent(parameters);
                CancellationTokenSource cancellationToken = new CancellationTokenSource();
                cancellationToken.CancelAfter(TimeSpan.FromMilliseconds(Timeout.Infinite));

                HttpResponseMessage response = null;
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:121.0) Gecko/20100101 Firefox/121.0");
                httpClient.DefaultRequestHeaders.Add("Accept", "text/html");
                httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
                httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
                httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                httpClient.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                httpClient.DefaultRequestHeaders.Add("Pragma", "no-cache");
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                httpClient.DefaultRequestHeaders.Add("TE", "trailers");

                if (parameters.Count <= 0)
                {
                    response = await httpClient.GetAsync(webUrlToScrape);
                }
                else
                {
                    response = await httpClient.PostAsync(webUrlToScrape, encodedContent);
                }
                response.EnsureSuccessStatusCode();
                cancellationToken.Token.ThrowIfCancellationRequested();
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                {
                    cancellationToken.Token.ThrowIfCancellationRequested();
                    HtmlParser parser = new HtmlParser();
                    IHtmlDocument document = parser.ParseDocument(stream);
                    return document;
                }
            }
        }

        internal async void ScrapeWebsiteAllGames(Dictionary<string, string> parameters)
        {
            try
            {
                RaiseEvent(LottoWebScrapingStages.CONNECTING);
                IHtmlDocument documentForSession = await GetWebsiteDOMAsync(new Dictionary<string, string>());
                RaiseEvent(LottoWebScrapingStages.SESSION_CREATION);
                Dictionary<string, string> sessionParam = GetSessionBasedParameters(parameters, documentForSession);
                RaiseEvent(LottoWebScrapingStages.SEARCHING_DATA);
                IHtmlDocument document = await GetWebsiteDOMAsync(sessionParam);
                RaiseEvent(LottoWebScrapingStages.SCRAPING);
                List<LotteryDrawResult> lotteryDrawResultArr = GetScrapeResults(document);

                int countCtr = 1;
                LotteryDao lotteryDao = LotteryDaoImpl.GetInstance();
                LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
                foreach (LotteryDrawResult scrapeResult in lotteryDrawResultArr.ToList())
                {
                    GameMode gameMode = EnumConverter.ToEnum<GameMode>(scrapeResult.GetGameCode(), GameMode.UNKNOWN);
                    if (gameMode == GameMode.UNKNOWN) continue;

                    LotteryDrawResult result = lotteryDrawResultDao.GetLotteryDrawResultByDrawDate(gameMode, scrapeResult.GetDrawDate());
                    if (result == null && !scrapeResult.IsDrawResulSequenceEmpty())
                    {
                        newRecordsCount++;
                        lotteryDrawResultDao.InsertDrawDate(scrapeResult);
                    }
                    RaiseEvent(LottoWebScrapingStages.INSERT,
                        ConverterUtils.GetPercentageFloored(countCtr++, lotteryDrawResultArr.Count),
                           String.Format("{0} ({1})",
                            scrapeResult.GetExtractedDrawnResultDetails(),
                                lotteries.FirstOrDefault(lot => lot.GetGameMode() == gameMode)?.GetDescription() ?? "Undetermined game"
                        ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                RaiseEvent(LottoWebScrapingStages.ERROR, 0, ex.Message);
            }
            finally
            {
                RaiseEvent(LottoWebScrapingStages.FINISH);
            }
        }

        internal async void ScrapeWebsite(LotteryDetails lotteryDetails, Dictionary<string, string> parameters)
        {
            try
            {
                RaiseEvent(LottoWebScrapingStages.CONNECTING);
                IHtmlDocument documentForSession = await GetWebsiteDOMAsync(new Dictionary<string, string>());
                RaiseEvent(LottoWebScrapingStages.SESSION_CREATION);
                Dictionary<string, string> sessionParam = GetSessionBasedParameters(parameters, documentForSession);
                RaiseEvent(LottoWebScrapingStages.SEARCHING_DATA);
                IHtmlDocument document = await GetWebsiteDOMAsync(sessionParam);
                RaiseEvent(LottoWebScrapingStages.SCRAPING);
                List<LotteryDrawResult> lotteryDrawResultArr = GetScrapeResults(document);

                int countCtr = 1;
                LotteryDrawResultDao lotteryDao = LotteryDrawResultDaoImpl.GetInstance();
                foreach (LotteryDrawResult scrapeResult in lotteryDrawResultArr.ToList())
                {
                    LotteryDrawResult result = lotteryDao.GetLotteryDrawResultByDrawDate(lotteryDetails.GameMode, scrapeResult.GetDrawDate());
                    if (result == null && !scrapeResult.IsDrawResulSequenceEmpty())
                    {
                        newRecordsCount++;
                        lotteryDao.InsertDrawDate(scrapeResult);
                    }
                    RaiseEvent(LottoWebScrapingStages.INSERT,
                        ConverterUtils.GetPercentageFloored(countCtr++, lotteryDrawResultArr.Count), scrapeResult.GetExtractedDrawnResultDetails());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                RaiseEvent(LottoWebScrapingStages.ERROR, 0, ex.Message);
            }
            finally
            {
                RaiseEvent(LottoWebScrapingStages.FINISH);
            }
        }

        private List<LotteryDrawResult> GetScrapeResults(IHtmlDocument document)
        {
            List<LotteryDrawResult> lotteryDrawResultArr = new List<LotteryDrawResult>();
            IEnumerable<IElement> tableElement = null;
            tableElement = document.All.Where(x => x.ClassName == "Grid search-lotto-result-table" &&
                                                   x.Id == "cphContainer_cpContent_GridView1");
            if (tableElement.Any())
            {
                IElement tbody = tableElement.First();
                foreach (INode node in tbody.ChildNodes)
                {
                    foreach (INode tr in node.ChildNodes.Skip(1))
                    {
                        INodeList tds = tr.ChildNodes;
                        LotteryDrawResultSetup setup = new LotteryDrawResultSetup();
                        if (tr.ChildNodes.Length >= 5)
                        {
                            GameMode gameMode = GetGameModeFromScrapeTitle(tr.ChildNodes[1].TextContent);
                            if (gameMode == GameMode.UNKNOWN) continue;

                            setup.PutNumberSequence(tr.ChildNodes[2].TextContent);
                            setup.DrawDate = DateTime.ParseExact(tr.ChildNodes[3].TextContent, "M/d/yyyy", CultureInfo.InvariantCulture);
                            setup.JackpotAmt = double.Parse(tr.ChildNodes[4].TextContent);
                            setup.Winners = int.Parse(tr.ChildNodes[5].TextContent);
                            setup.GameCode = (int)gameMode;
                            lotteryDrawResultArr.Add(setup);
                        }
                    }
                }
            }
            return lotteryDrawResultArr;
        }

        private GameMode GetGameModeFromScrapeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return GameMode.UNKNOWN;

            // Normalize
            string s = title.Trim().ToLowerInvariant();

            // Replace common separators and punctuation with spaces, collapse whitespace
            s = System.Text.RegularExpressions.Regex.Replace(s, @"[\/\-\—\–\:\,_\.\(\)]", " ");
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ").Trim();

            // Numeric-first approach is safest: detect the 6/x pattern in many forms (6/55, 6-55, "6 55", "6 55 (Grand)")
            bool IsSixAnd(int n)
            {
                // match patterns like "6/55", "6-55", "6 55", "6  55"
                string pattern = $@"\b6\s*[\/\-\s]?\s*{n}\b";
                return System.Text.RegularExpressions.Regex.IsMatch(s, pattern);
            }

            if (IsSixAnd(58)) return GameMode.Mode_658;
            if (IsSixAnd(55)) return GameMode.Mode_655;
            if (IsSixAnd(49)) return GameMode.Mode_649;
            if (IsSixAnd(45)) return GameMode.Mode_645;
            if (IsSixAnd(42)) return GameMode.Mode_642;

            // Word-based fallbacks (many variants / misspellings considered)
            if (s.Contains("ultra") || s.Contains("ultra lotto") || s.Contains("ultralotto")) return GameMode.Mode_658;
            if (s.Contains("grand") || s.Contains("grand lotto") || s.Contains("grandlotto")) return GameMode.Mode_655;
            if (s.Contains("super") || s.Contains("super lotto") || s.Contains("superlotto")) return GameMode.Mode_649;
            if (s.Contains("mega") || s.Contains("mega lotto") || s.Contains("megalotto")) return GameMode.Mode_645;
            if (s.Contains("lucky 6/42") || s.Contains("6 42") || s.Contains("6/42") || s.Contains("lotto 6 42") || s.Contains("lotto 6/42") || s.Contains("lotto 6/42")) return GameMode.Mode_642;

            // Broad heuristics: look for the spelled-out numbers that might appear in titles
            if (s.Contains("six fifty eight") || s.Contains("six fifty-eight") || s.Contains("six fiftyeight")) return GameMode.Mode_658;
            if (s.Contains("six fifty five") || s.Contains("six fifty-five") || s.Contains("six fiftyfive")) return GameMode.Mode_655;
            if (s.Contains("six forty nine") || s.Contains("six forty-nine") || s.Contains("six fortynine")) return GameMode.Mode_649;
            if (s.Contains("six forty five") || s.Contains("six forty-five") || s.Contains("six fortyfive")) return GameMode.Mode_645;
            if (s.Contains("six forty two") || s.Contains("six forty-two") || s.Contains("six fortytwo")) return GameMode.Mode_642;

            // Last-ditch checks for common tokens
            if (s.Contains("grandlotto") || (s.Contains("grand") && s.Contains("lotto"))) return GameMode.Mode_655;
            if (s.Contains("ultralotto") || (s.Contains("ultra") && s.Contains("lotto"))) return GameMode.Mode_658;
            if (s.Contains("superlotto") || (s.Contains("super") && s.Contains("lotto"))) return GameMode.Mode_649;
            if (s.Contains("megalotto") || (s.Contains("mega") && s.Contains("lotto"))) return GameMode.Mode_645;
            if (s.Contains("lotto") && s.Contains("42")) return GameMode.Mode_642;

            // If nothing matched, be conservative and return UNKNOWN
            return GameMode.UNKNOWN;
        }

        private void RaiseEvent(LottoWebScrapingStages stage, int progress = 0, String addedInfo = "")
        {
            if (WebScrapingStatus == null) return;

            GameMode gameMode = currentLotteryDetailsProcess == null ? GameMode.ALL : currentLotteryDetailsProcess.GameMode;
            String gameDescription = gameMode == GameMode.ALL ? "All" : currentLotteryDetailsProcess.Description;

            lottoWebScraperEvent.LottoWebScrapingStage = stage;
            lottoWebScraperEvent.GameMode = gameMode;
            lottoWebScraperEvent.Progress = progress;
            lottoWebScraperEvent.NewRecordsCount = newRecordsCount;

            if (stage == LottoWebScrapingStages.INIT)
            {
                lottoWebScraperEvent.CustomStatusMessage = String.Format(ResourcesUtils.GetMessage("pcso_scrape_cls_msg_1"), gameDescription);
            }
            else if (stage == LottoWebScrapingStages.CONNECTING)
            {
                lottoWebScraperEvent.CustomStatusMessage = ResourcesUtils.GetMessage("pcso_scrape_cls_msg_2");
            }
            else if (stage == LottoWebScrapingStages.SESSION_CREATION)
            {
                lottoWebScraperEvent.CustomStatusMessage = ResourcesUtils.GetMessage("pcso_scrape_cls_msg_3");
            }
            else if (stage == LottoWebScrapingStages.SEARCHING_DATA)
            {
                lottoWebScraperEvent.CustomStatusMessage = ResourcesUtils.GetMessage("pcso_scrape_cls_msg_4");
            }
            else if (stage == LottoWebScrapingStages.SCRAPING)
            {
                lottoWebScraperEvent.CustomStatusMessage = ResourcesUtils.GetMessage("pcso_scrape_cls_msg_5");
            }
            else if (stage == LottoWebScrapingStages.INSERT)
            {
                lottoWebScraperEvent.CustomStatusMessage = String.Format(ResourcesUtils.GetMessage("pcso_scrape_cls_msg_6"), addedInfo);
            }
            else if (stage == LottoWebScrapingStages.ERROR)
            {
                lottoWebScraperEvent.CustomStatusMessage = String.Format(ResourcesUtils.GetMessage("pcso_scrape_cls_msg_8"), addedInfo);
            }
            else if (stage == LottoWebScrapingStages.FINISH)
            {
                lottoWebScraperEvent.CustomStatusMessage = ResourcesUtils.GetMessage("pcso_scrape_cls_msg_7");
            }

            WebScrapingStatus.Invoke(this, lottoWebScraperEvent);
        }

    }
}
