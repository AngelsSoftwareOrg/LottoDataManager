using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

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
        private int Id;
        private GameMode gameMode;

        public bool Monday { get => monday; set => monday = value; }
        public bool Tuesday { get => tuesday; set => tuesday = value; }
        public bool Wednesday { get => wednesday; set => wednesday = value; }
        public bool Thursday { get => thursday; set => thursday = value; }
        public bool Friday { get => friday; set => friday = value; }
        public bool Saturday { get => saturday; set => saturday = value; }
        public bool Sunday { get => sunday; set => sunday = value; }
        public int ID { get => Id; set => Id = value; }
        public GameMode GameMode { get => gameMode; set => gameMode = value; }

        public bool IsFriday()
        {
            return this.Friday;
        }
        public bool IsMonday()
        {
            return this.Monday;
        }
        public bool IsSaturday()
        {
            return this.Saturday;
        }
        public bool IsSunday()
        {
            return this.Sunday;
        }
        public bool IsThursday()
        {
            return this.Thursday;
        }
        public bool IsTuesday()
        {
            return this.Tuesday;
        }
        public bool IsWednesday()
        {
            return this.Wednesday;
        }
        public bool IsDrawDateMatchLotterySchedule(DateTime drawDate)
        {
            DayOfWeek dow = drawDate.Date.DayOfWeek;
            if (dow == DayOfWeek.Monday && IsMonday()) { return true; }
            else if (dow == DayOfWeek.Tuesday && IsTuesday()) { return true; }
            else if (dow == DayOfWeek.Wednesday && IsWednesday()) { return true; }
            else if (dow == DayOfWeek.Thursday && IsThursday()) { return true; }
            else if (dow == DayOfWeek.Friday && IsFriday()) { return true; }
            else if (dow == DayOfWeek.Saturday && IsSaturday()) { return true; }
            else if (dow == DayOfWeek.Sunday && IsSunday()) { return true; }
            return false;
        }
        public String DrawDateEvery()
        {
            String concat = "";
            if (IsMonday()) { concat += "Monday, "; }
            if (IsTuesday()) { concat += "Tuesday, "; }
            if (IsWednesday()) { concat += "Wednesday, "; }
            if (IsThursday()) { concat += "Thursday, "; }
            if (IsFriday()) { concat += "Friday, "; }
            if (IsSaturday()) { concat += "Saturday, "; }
            if (IsSunday()) { concat += "Sunday, "; }
            return concat.Substring(0, concat.Length - 2);
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
        public int GetID()
        {
            return ID;
        }
        public GameMode GetGameMode()
        {
            return GameMode;
        }
        public bool IsEqualSchedule(LotterySchedule compareTo)
        {
            if(this.IsMonday() == compareTo.IsMonday() &&
                this.IsTuesday() == compareTo.IsTuesday() &&
                this.IsWednesday() == compareTo.IsWednesday() &&
                this.IsThursday() == compareTo.IsThursday() &&
                this.IsFriday() == compareTo.IsFriday() &&
                this.IsSaturday() == compareTo.IsSaturday() &&
                this.IsSunday() == compareTo.IsSunday() &&
                this.GetGameMode().Equals(compareTo.GetGameMode()))
            {
                return true;
            }
            return false;
        }
    }
}
