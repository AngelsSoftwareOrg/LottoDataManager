using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryDataDerivation
    {
        private GameMode gameMode;
        private LotteryScheduleDao lotteryScheduleDao;
        public LotteryDataDerivation(GameMode gameMode)
        {
            this.gameMode = gameMode;
            this.lotteryScheduleDao = LotteryScheduleDaoImpl.GetInstance();
        }
        public DateTime GetNextDrawDate()
        {
            DateTime nextScheduledDate = DateTime.Now;
            LotterySchedule lotterySchedule = this.lotteryScheduleDao.GetLotterySchedule(gameMode);
            int breaker = 0;
            while (true)
            {
                if (nextScheduledDate.DayOfWeek == DayOfWeek.Monday && lotterySchedule.IsMonday()) { break; }
                else if (nextScheduledDate.DayOfWeek == DayOfWeek.Tuesday && lotterySchedule.IsTuesday()) { break; }
                else if (nextScheduledDate.DayOfWeek == DayOfWeek.Wednesday && lotterySchedule.IsWednesday()) { break; }
                else if (nextScheduledDate.DayOfWeek == DayOfWeek.Thursday && lotterySchedule.IsThursday()) { break; }
                else if (nextScheduledDate.DayOfWeek == DayOfWeek.Friday && lotterySchedule.IsFriday()) { break; }
                else if (nextScheduledDate.DayOfWeek == DayOfWeek.Saturday && lotterySchedule.IsSaturday()) { break; }
                else if (nextScheduledDate.DayOfWeek == DayOfWeek.Sunday && lotterySchedule.IsSunday()) { break; }
                if (breaker > 1000) break;
                breaker++;
                nextScheduledDate = nextScheduledDate.AddDays(1);
            }
            return nextScheduledDate;
        }
    }
}
