using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO
{
    public interface LotteryScheduleDao
    {
        LotterySchedule GetLotterySchedule(GameMode gameMode);
        void RemoveLotterySchedule(LotterySchedule lsched);
        int InsertLotterySchedule(LotterySchedule lsched);
    }
}
