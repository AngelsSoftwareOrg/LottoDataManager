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
        protected LotteryDataServices lotteryDataServices;
        protected ReportDataServices reportDataServices;
        protected ReportAbstract(LotteryDataServices lotteryDataServices)
        {
            this.lotteryDataServices = lotteryDataServices;
            this.reportDataServices = new ReportDataServices(lotteryDataServices.LotteryDetails);
        }
    }
}
