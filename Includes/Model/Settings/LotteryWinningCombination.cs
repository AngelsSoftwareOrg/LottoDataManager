using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Settings
{
    public interface LotteryWinningCombination
    {
        int GetMatch0();
        int GetMatch1();
        int GetMatch2();
        int GetMatch3();
        int GetMatch4();
        int GetMatch5();
        int GetMatch6();
    }
}
