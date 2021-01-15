using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryOutlet
    {
        long GetId();
        int GetOutletCode();
        string GetDescription();
    }
}
