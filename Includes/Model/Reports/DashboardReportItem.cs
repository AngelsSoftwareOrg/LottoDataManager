using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Reports.Setup;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Reports
{
    public interface DashboardReportItem
    {
        String GetDescription();
        String GetValue();
        DashboardReportItemActions GetDashboardReportItemActions();
        string GetGroupKeyName();
        ReportItemDecoration GetReportItemDecoration();
        Object GetTag();
        String GetGroupTaskLabel();
    }
}
