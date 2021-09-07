using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Reports
{
    public interface DashboardReportGroup
    {
        String GetGroupName();
        List<DashboardReportItemSetup> DashboardReportItemList();
        void ClearDashboardItems();
        void AddDashboardItem(DashboardReportItemSetup item);
        void AddDashboardItems(List<DashboardReportItemSetup> items);
    }
}
