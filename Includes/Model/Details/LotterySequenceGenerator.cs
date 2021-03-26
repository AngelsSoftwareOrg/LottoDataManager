using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotterySequenceGenerator
    {

        int GetID();
        int GetSeqGenCode();
        string GetDescription();

    }
}
