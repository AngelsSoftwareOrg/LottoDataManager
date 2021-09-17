using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Reports
{
    public class DashboardReportEvent : EventArgs
    {
        public String ModuleName { get; set; }
        public String ReportLogs { get; set; }
    }
}
