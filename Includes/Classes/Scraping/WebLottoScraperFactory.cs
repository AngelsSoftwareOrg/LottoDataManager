﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public class WebLottoScraperFactory
    {
        public static LottoWebScraper GetLottoScraper()
        {
            //DEFAULT SCRAPER
            return new LottoPCSOScraper();
        }
    }
}