using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model;

namespace LottoDataManager.Includes.Classes.Reports
{
    public abstract class ReportAbstract
    {
        private LotteryDataServices lotteryDataServices;
        protected ReportDataServices reportDataServices;

        protected ReportAbstract(LotteryDataServices lotteryDataServices)
        {
            this.LotteryDataServices = lotteryDataServices;
        }

        protected LotteryDataServices LotteryDataServices 
        { 
            get => lotteryDataServices; 
            set 
            {
                lotteryDataServices = value;
                if(value != null) this.reportDataServices = new ReportDataServices(lotteryDataServices.LotteryDetails);
            }
        }
    }
}
