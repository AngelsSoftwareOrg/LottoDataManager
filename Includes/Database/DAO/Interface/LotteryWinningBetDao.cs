using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface LotteryWinningBetDao
    {
        LotteryWinningBet GetLotteryWinningBet(long lotteryBetID);
        void InsertWinningBet(LotteryWinningBet lotteryWinningBet);
        double GetTotalWinningsAmount(GameMode gameMode);
        double GetTotalWinningsAmountThisMonth(GameMode gameMode);
        void RemoveLotteryWinningBet(long betId);
        void RemoveLotteryWinningBetByBetId(long betId);
        List<LotteryWinningBet> GetLotteryWinningBet(GameMode gameMode, DateTime sinceWhen);
        void UpdateClaimStatus(LotteryWinningBet winBet);
        int[] GetWinningBetNumbersTally(GameMode gameMode);
        int[] GetMinMaxWinningBetAmount(GameMode gameMode);
        List<String[]> GetDaysOfWeekTally(List<int> gameCodes);
        List<String[]> GetPickGeneratorsTally(List<int> gameCodes);
        List<String[]> GetOutletTally(List<int> gameCodes);
        List<String[]> GetWinningBetDigitTally(List<int> gameCodes);
    }
}
