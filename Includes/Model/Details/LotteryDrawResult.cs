using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryDrawResult: LotteryNumbersAndOperations
    {
        DateTime GetDrawDate();
        String GetDrawDateFormatted();
        int GetGameCode();
        long GetID();
        double GetJackpotAmt();
        String GetJackpotAmtFormatted();
        int GetWinners();
        bool isWithinDrawResult(int numberToLookFor);
        bool isDrawResulDetailsEmpty();

    }
}
