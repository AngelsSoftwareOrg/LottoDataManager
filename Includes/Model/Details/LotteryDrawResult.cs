using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryDrawResult
    {
        DateTime GetDrawDate();
        String GetDrawDateFormatted();
        int GetGameCode();
        int GetNum1();
        int GetNum2();
        int GetNum3();
        int GetNum4();
        int GetNum5();
        int GetNum6();
        double GetJackpotAmt();
        String GetJackpotAmtFormatted();
        int GetWinners();
    }
}
