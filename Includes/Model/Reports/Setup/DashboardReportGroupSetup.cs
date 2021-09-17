using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Reports.Setup
{
    public class DashboardReportGroupSetup : DashboardReportGroup
    {
        private String groupName;
        private List<DashboardReportItemSetup> dashboardReportItemSetupList;

        public DashboardReportGroupSetup(String groupName)
        {
            this.groupName = groupName;
            this.dashboardReportItemSetupList = new List<DashboardReportItemSetup>();
        }

        public string GroupName { get => groupName; set => groupName = value; }
        public List<DashboardReportItemSetup> DashboardReportItemSetupList 
        { 
            get => dashboardReportItemSetupList.ToList<DashboardReportItemSetup>(); 
            set => dashboardReportItemSetupList = value; 
        }

        public String GetGroupName()
        {
            return GroupName;
        }
        public List<DashboardReportItemSetup> DashboardReportItemList()
        {
            return DashboardReportItemSetupList;
        }

        public void ClearDashboardItems()
        {
            dashboardReportItemSetupList.Clear();
        }

        public void AddDashboardItem(DashboardReportItemSetup item)
        {
            if (item == null) return;
            dashboardReportItemSetupList.Add(item);
        }
        public void AddDashboardItems(List<DashboardReportItemSetup> items)
        {
            if (items == null) return;
            dashboardReportItemSetupList.AddRange(items);
        }
    }
}
