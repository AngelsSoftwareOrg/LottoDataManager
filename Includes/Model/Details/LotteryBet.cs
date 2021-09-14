using LottoDataManager.Includes.Classes.ML.FastTreeRegression;
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
        String GetTargetDrawDateLongFormat();
        double GetBetAmount();
        int GetOutletCode();
        int[] GetBetNumbersAsArray();
        String GetSimpleContentDetails();
        int GetMatchNumCount();
        LotteryOutlet GetLotteryOutlet();
        LotterySequenceGenerator GetLotterySequenceGenerator();
        String GetGNUFormat();
        LotteryWinningBet GetLotteryWinningBet();
        LottoMatchCountInputModel GetLottoMatchCountInputModel();
        String GetLottoMatchCountTrainerModelDataIntake();
    }
}
