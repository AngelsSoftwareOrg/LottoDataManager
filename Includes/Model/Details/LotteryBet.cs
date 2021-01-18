using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryBet: LotteryNumbersAndOperations
    {
        int GetGameCode();
        long GetId();
        DateTime GetTargetDrawDate();
        String GetTargetDrawDateFormatted();
        double GetBetAmount();
        int GetOutletCode();
        int[] GetBetNumbersAsArray();
        bool IsLuckyPick();
    }
}
