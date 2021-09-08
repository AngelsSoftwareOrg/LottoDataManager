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
    public class DashboardReportItemSetup : DashboardReportItem
    {
        private String value;
        private String description;
        private ReportItemDecoration reportItemDecoration;
        private String groupKeyName;
        private DashboardReportItemActions dashboardReportItemAction;
        private Object tag;
        private String groupTaskLabel;

        public DashboardReportItemSetup()
        {
            Value = "";
            description = "";
            DashboardReportItemAction = DashboardReportItemActions.NONE;
            reportItemDecoration = new ReportItemDecoration();
        }
        public string Value { get => value; set => this.value = value; }
        public string Description { get => description; set => description = value; }
        public DashboardReportItemActions DashboardReportItemAction { get => dashboardReportItemAction; set => dashboardReportItemAction = value; }
        public string GroupKeyName { get => groupKeyName; set => groupKeyName = value; }
        public ReportItemDecoration ReportItemDecoration { get => reportItemDecoration; set => reportItemDecoration = value; }
        public object Tag { get => tag; set => tag = value; }
        public string GroupTaskLabel { get => groupTaskLabel; set => groupTaskLabel = value; }
        public string GetDescription()
        {
            return Description;
        }
        public string GetValue()
        {
            return Value;
        }
        public DashboardReportItemActions GetDashboardReportItemActions()
        {
            return DashboardReportItemAction;
        }
        public string GetGroupKeyName()
        {
            return GroupKeyName;
        }
        public ReportItemDecoration GetReportItemDecoration()
        {
            return ReportItemDecoration;
        }
        public object GetTag()
        {
            return Tag;
        }
        public string GetGroupTaskLabel()
        {
            return GroupTaskLabel;
        }
    }
}