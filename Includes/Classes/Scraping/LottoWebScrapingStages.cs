using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Scraping
{
    public enum LottoWebScrapingStages
    {
        INIT=0,
        CONNECTING=1,
        SESSION_CREATION=2,
        SEARCHING_DATA=3,
        SCRAPING=4,
        INSERT=5,
        ERROR=6,
        FINISH=7
    }
}
