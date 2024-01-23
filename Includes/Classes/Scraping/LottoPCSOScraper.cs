using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public class LottoPCSOScraper: LottoWebScraper
    {
        public event EventHandler<LottoWebScraperEvent> WebScrapingStatus;
        private LottoWebScraperEvent lottoWebScraperEvent = new LottoWebScraperEvent();
        private List<LotteryDetails> lotteriesDetailsArr;
        private LotteryDetails currentLotteryDetailsProcess;
        private DateTime sinceWhenToScrape;
        private readonly string webUrlToScrape = AppSettings.GetLottoScrapeSite;
        private int newRecordsCount;
        
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
                    ScrapeWebsite(lotteryDetails, GenerateParameters(lotteryDetails));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Dictionary<string, string> GenerateParameters(LotteryDetails lotteryDetails)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "ctl00$ctl00$cphContainer$cpContent$ddlStartMonth", sinceWhenToScrape.ToString("MMMM") }, //e.g. January
                    { "ctl00$ctl00$cphContainer$cpContent$ddlStartDate", sinceWhenToScrape.ToString("d ").Trim() }, //e.g. 1
                    { "ctl00$ctl00$cphContainer$cpContent$ddlStartYear", sinceWhenToScrape.ToString("yyyy") }, //e.g. 2021
                    { "ctl00$ctl00$cphContainer$cpContent$ddlEndMonth", DateTime.Now.ToString("MMMM") },  //e.g. January
                    { "ctl00$ctl00$cphContainer$cpContent$ddlEndDay", DateTime.Now.ToString("d ").Trim() }, // //e.g. 12
                    { "ctl00$ctl00$cphContainer$cpContent$ddlEndYear", DateTime.Now.ToString("yyyy") }, // //e.g. 2020
                    { "ctl00$ctl00$cphContainer$cpContent$ddlSelectGame", lotteryDetails.Lottery.GetWebScrapeGameCode().ToString() },  //e.g. 18 for 6/58, refer to PCSO Website for the number
                    { "ctl00$ctl00$cphContainer$cpContent$btnSearch", "Search+Lotto" },
                    { "ctl00$ctl00$cphContainer$cpRightSidebar$TodaysNationalDraw$hSuspensionFrom", "2020/03/17" },
                    { "ctl00$ctl00$cphContainer$cpRightSidebar$TodaysNationalDraw$hSuspensionTo", "2020/08/07" }
                };
            return parameters;
        }

        private Dictionary<string, string> GetSessionBasedParameters(LotteryDetails lotteryDetails, IHtmlDocument documentPreLoading)
        {
            Dictionary<string, string> parameters = GenerateParameters(lotteryDetails);

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
                
                if (parameters.Count <=0)
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

        internal async void ScrapeWebsite(LotteryDetails lotteryDetails, Dictionary<string, string> parameters)
        {
            try
            {
                RaiseEvent(LottoWebScrapingStages.CONNECTING);
                IHtmlDocument documentForSession = await GetWebsiteDOMAsync(new Dictionary<string, string>());
                RaiseEvent(LottoWebScrapingStages.SESSION_CREATION);
                Dictionary<string, string> sessionParam = GetSessionBasedParameters(lotteryDetails, documentForSession);
                RaiseEvent(LottoWebScrapingStages.SEARCHING_DATA);
                IHtmlDocument document = await GetWebsiteDOMAsync(sessionParam);
                RaiseEvent(LottoWebScrapingStages.SCRAPING);
                List<LotteryDrawResult> lotteryDrawResultArr = GetScrapeResults(lotteryDetails, document);

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
                    RaiseEvent(LottoWebScrapingStages.INSERT, ConverterUtils.GetPercentageFloored(countCtr++, lotteryDrawResultArr.Count), scrapeResult.GetExtractedDrawnResultDetails());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                RaiseEvent(LottoWebScrapingStages.ERROR,0,ex.Message);
            }
            finally
            {
                RaiseEvent(LottoWebScrapingStages.FINISH);
            }
        }

        private List<LotteryDrawResult> GetScrapeResults(LotteryDetails lotteryDetails, IHtmlDocument document)
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
                            setup.PutNumberSequence(tr.ChildNodes[2].TextContent);
                            setup.DrawDate = DateTime.ParseExact(tr.ChildNodes[3].TextContent, "M/d/yyyy", CultureInfo.InvariantCulture);
                            setup.JackpotAmt = double.Parse(tr.ChildNodes[4].TextContent);
                            setup.Winners = int.Parse(tr.ChildNodes[5].TextContent);
                            setup.GameCode = lotteryDetails.GameCode;
                            lotteryDrawResultArr.Add(setup);
                        }
                    }
                }
            }
            return lotteryDrawResultArr;
        }

        private void RaiseEvent(LottoWebScrapingStages stage, int progress = 0, String addedInfo="")
        {
            if (WebScrapingStatus == null) return;
            lottoWebScraperEvent.LottoWebScrapingStage = stage;
            lottoWebScraperEvent.GameMode = currentLotteryDetailsProcess.GameMode;
            lottoWebScraperEvent.Progress = progress;
            lottoWebScraperEvent.NewRecordsCount = newRecordsCount;

            if (stage == LottoWebScrapingStages.INIT)
            {
                lottoWebScraperEvent.CustomStatusMessage = String.Format(ResourcesUtils.GetMessage("pcso_scrape_cls_msg_1"), currentLotteryDetailsProcess.Description);
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
