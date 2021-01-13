﻿using System;
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
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public class LottoScraper
    {
        private List<LotteryDetails> lotteriesDetailsArr;
        private DateTime sinceWhenToScrape;
        private readonly string webUrlToScrape = AppSettings.GetLootoScrapeSite;

        public void StartScraping(List<LotteryDetails> lotteriesDetailsArr)
        {
            this.lotteriesDetailsArr = lotteriesDetailsArr;
            LotteryDrawResultDao lotteryDao = LotteryDrawResultDaoImpl.GetInstance();
            foreach (LotteryDetails lotteryDetails in this.lotteriesDetailsArr)
            {
                this.sinceWhenToScrape = lotteryDao.GetLatestDrawDate(lotteryDetails.GameMode);
                ScrapeWebsite(lotteryDetails, GenerateParameters(lotteryDetails));
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
                HttpResponseMessage request = await httpClient.PostAsync(webUrlToScrape, encodedContent);
                cancellationToken.Token.ThrowIfCancellationRequested();
                Stream response = await request.Content.ReadAsStreamAsync();
                cancellationToken.Token.ThrowIfCancellationRequested();
                HtmlParser parser = new HtmlParser();
                IHtmlDocument document = parser.ParseDocument(response);
                return document;
            }
        }

        internal async void ScrapeWebsite(LotteryDetails lotteryDetails, Dictionary<string, string> parameters)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                IHtmlDocument documentForSession = await GetWebsiteDOMAsync(GenerateParameters(lotteryDetails));
                IHtmlDocument document = await GetWebsiteDOMAsync(GetSessionBasedParameters(lotteryDetails, documentForSession));
                List<LotteryDrawResult> lotteryDrawResultArr = GetScrapeResults(lotteryDetails, document);
                LotteryDrawResultDao lotteryDao = LotteryDrawResultDaoImpl.GetInstance();
                foreach (LotteryDrawResult scrapeResult in lotteryDrawResultArr.ToList())
                {
                    LotteryDrawResult result = lotteryDao.GetLotteryDrawResultByDrawDate(lotteryDetails.GameMode, scrapeResult.GetDrawDate());
                    if (result == null && !scrapeResult.IsDrawResulSequenceEmpty())
                    {
                        lotteryDao.InsertDrawDate(scrapeResult);
                    }
                }
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
                        }
                        lotteryDrawResultArr.Add(setup);
                    }
                }
            }
            return lotteryDrawResultArr;
        }
    }
}
