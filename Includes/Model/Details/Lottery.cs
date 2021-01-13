using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details
{
    public interface Lottery
    {
        GameMode GetGameCode();
        String GetDescription();
        double GetPricePerBet();
        int GetWebScrapeGameCode();
    }
}
