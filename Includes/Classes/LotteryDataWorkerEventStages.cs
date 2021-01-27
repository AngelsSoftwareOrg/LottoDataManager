using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes
{
    public enum LotteryDataWorkerEventStages
    {
        INIT = 0,
        EXTRACTING=1,
        INSERT = 2,
        FINISH = 3
    }
}
