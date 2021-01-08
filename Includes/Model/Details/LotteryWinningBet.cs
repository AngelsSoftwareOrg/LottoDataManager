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
        long GetLotteryBetId();
        double GetWinningAmount();
    }
}
