using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryWinningBet: LotteryNumbersAndOperations
    {
        long GetID();
        long GetLotteryBetId();
        double GetWinningAmount();
        bool IsClaimed();
        int GetOutletCd();
        string GetOutletDesc();
        DateTime GetTargetDrawDate();
        String GetTargetDrawDateFormatted();
        String GetTargetDrawDateLongFormat();
        String GetWinningAmountInCurrency();
        bool IsWinningNum(int num);
    }
}
