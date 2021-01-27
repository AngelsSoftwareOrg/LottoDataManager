using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public class LottoWebScraperEvent : EventArgs
    {
        public GameMode GameMode { get; set; }
        public LottoWebScrapingStages LottoWebScrapingStage { get; set; }
        public int Progress { get; set; }
        public String CustomStatusMessage { get; set; }
    }
}
