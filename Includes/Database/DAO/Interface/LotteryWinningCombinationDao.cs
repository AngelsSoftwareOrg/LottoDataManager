using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO
{
    public interface LotteryWinningCombinationDao
    {
        LotteryWinningCombination GetLotteryWinningCombination(GameMode gameMode);
    }
}