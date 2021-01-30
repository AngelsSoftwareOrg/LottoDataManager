using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO
{
    public interface LotteryDrawResultDao
    {
        DataTable GetLotteryDrawResult(GameMode gameMode, DateTime drawDate);
        List<LotteryDrawResult> GetAllDrawResults(GameMode gameMode);
        LotteryDrawResult GetLotteryDrawResultByDrawDate(GameMode gameMode, DateTime drawDate);
        DateTime GetNextDrawDate(GameMode gameMode, DateTime betDate);
        void InsertDrawDate(LotteryDrawResult lotteryDrawResult);
        DateTime GetLatestDrawDate(GameMode gameMode);
        List<LotteryDrawResult> GetDrawResultsFromStartingDate(GameMode gameMode, DateTime startingDrawDate);
        List<int> GetTopDrawnDigitResults(GameMode gameMode);
        List<LotteryDrawResult> GetJackpotDrawResults(GameMode gameMode);
        List<int> GetTopDrawnPreviousSeasonDigitResults(GameMode gameMode);
    }
}
