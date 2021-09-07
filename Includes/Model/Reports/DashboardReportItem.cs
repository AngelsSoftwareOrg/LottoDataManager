using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Reports
{
    public interface DashboardReportItem
    {
        String GetDescription();
        String GetValue();
        bool IsHighlight();
        Color GetHighlightColor();
        DashboardReportItemActions GetDashboardReportItemActions();
        Color GetFontColor();
        string GetGroupKeyName();
    }
}
