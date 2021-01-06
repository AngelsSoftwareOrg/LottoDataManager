using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotterySchedule
    {
        bool IsMonday();
        bool IsTuesday();
        bool IsWednesday();
        bool IsThursday();
        bool IsFriday();
        bool IsSaturday();
        bool IsSunday();
    }
}
