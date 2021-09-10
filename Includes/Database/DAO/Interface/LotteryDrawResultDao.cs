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
        List<LotteryDrawResult> GetDrawResultsFromStartingDate(GameMode gameMode, DateTime startingDrawDate, DateTime endingDate);
        List<int> GetTopDrawnDigitResults(GameMode gameMode);
        List<LotteryDrawResult> GetJackpotDrawResults(GameMode gameMode);
        List<int> GetTopDrawnPreviousSeasonDigitResults(GameMode gameMode);
        List<int> GetTopDrawnDigitFromJackpotsResults(GameMode gameMode);
        List<int> GetTopDrawnDigitFromDateRange(GameMode gameMode, DateTime dateFrom, DateTime dateTo);
        List<int[]> GetTopDrawnDigitToSequenceFromDateRange(GameMode gameMode, DateTime dateFrom, DateTime dateTo);
        List<LotteryDrawResult> GetLatestLotteryResult(GameMode gameMode, int howManyDraws);
        List<LotteryDrawResult> GetMachineLearningDataSetFastTree(GameMode gameMode, DateTime startingDate);
        List<LotteryDrawResult> GetMachineLearningDataSetSDCA(GameMode gameMode, DateTime startingDate);
        LotteryDrawResult GetLatestDrawResults(int gameCd);
    }
}
