using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryScheduleSetup: LotterySchedule
    {
        private bool monday;
        private bool tuesday;
        private bool wednesday;
        private bool thursday;
        private bool friday;
        private bool saturday;
        private bool sunday;
        public bool Monday { get => monday; set => monday = value; }
        public bool Tuesday { get => tuesday; set => tuesday = value; }
        public bool Wednesday { get => wednesday; set => wednesday = value; }
        public bool Thursday { get => thursday; set => thursday = value; }
        public bool Friday { get => friday; set => friday = value; }
        public bool Saturday { get => saturday; set => saturday = value; }
        public bool Sunday { get => sunday; set => sunday = value; }
        bool LotterySchedule.IsFriday()
        {
            return this.Friday;
        }
        bool LotterySchedule.IsMonday()
        {
            return this.Monday;
        }
        bool LotterySchedule.IsSaturday()
        {
            return this.Saturday;
        }
        bool LotterySchedule.IsSunday()
        {
            return this.Sunday;
        }
        bool LotterySchedule.IsThursday()
        {
            return this.Thursday;
        }
        bool LotterySchedule.IsTuesday()
        {
            return this.Tuesday;
        }
        bool LotterySchedule.IsWednesday()
        {
            return this.Wednesday;
        }
        override
        public String ToString()
        {
#if DEBUG
            return String.Format("Lottery Schedule: Monday: {0}, Tuesday: {1}, Wednesday: {2}, " +
                "Thursday: {3}, Friday: {4}, Saturday: {5}, Sunday: {6}",
                this.Monday, this.Tuesday, this.Wednesday, this.Thursday, this.Friday, this.Saturday, this.Sunday);
#else
            return base.ToString();
#endif
        }
    }
}
