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
        protected LotteryDetails lotteryDetails;
        protected ReportDataServices reportDataServices;
        protected ReportAbstract(LotteryDetails lotteryDetails)
        {
            this.lotteryDetails = lotteryDetails;
            this.reportDataServices = new ReportDataServices(lotteryDetails);
        }
    }
}
