using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface LotteryBetDao
    {
        List<LotteryBet> GetDashboardLatestBets(GameMode gameMode, DateTime sinceWhen);
        List<LotteryBet> ExtractLotteryBetsCheckWinningNumber(GameMode gameMode);
        void UpdateTargetDrawDate(long id, DateTime newTargetDrawDate);
        void InsertLotteryBet(List<LotteryBet> lotteryBetArr);
    }
}
