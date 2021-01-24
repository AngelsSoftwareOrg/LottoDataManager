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
        List<LotteryWinningBet> GetLotteryWinningBet(GameMode gameMode, DateTime sinceWhen);
        void UpdateClaimStatus(LotteryWinningBet winBet);
    }
}
