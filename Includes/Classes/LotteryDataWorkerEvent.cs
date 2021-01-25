using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Classes
{
    public class LotteryDataWorkerEvent : EventArgs
    {
        public GameMode GameMode { get; set; }
        public LotteryDataWorkerEventStages LotteryDataWorkerEventStages { get; set; }
        public String CustomStatusMessage { get; set; }
    }
}
