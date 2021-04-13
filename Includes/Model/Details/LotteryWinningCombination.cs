using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryWinningCombination: ICloneable
    {
        double GetMatch0();
        double GetMatch1();
        double GetMatch2();
        double GetMatch3();
        double GetMatch4();
        double GetMatch5();
        double GetMatch6();
        double GetWinningAmount(int matchingCount);
        int GetID();
        GameMode GetGameMode();
        
    }
}
