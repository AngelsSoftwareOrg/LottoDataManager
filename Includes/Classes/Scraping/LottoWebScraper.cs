using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public interface LottoWebScraper
    {
        event EventHandler<LottoWebScraperEvent> WebScrapingStatus;
        void StartScraping(List<LotteryDetails> lotteriesDetailsArr);
    }
}
