using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Reports
{
    public class DashboardReportItemSetup : DashboardReportItem
    {
        private String value;
        private String description;
        private Color highlightColor;
        private bool isHighlightColor;
        private DashboardReportItemActions dashboardReportItemAction;
        public DashboardReportItemSetup()
        {
            Value = "";
            description = "";
            HighlightColor = Color.Empty;
            isHighlightColor = false;
            DashboardReportItemAction = DashboardReportItemActions.NONE;
        }
        public string Value { get => value; set => this.value = value; }
        public string Description { get => description; set => description = value; }
        public Color HighlightColor { get => highlightColor; set => highlightColor = value; }
        public bool IsHighlightColor { get => isHighlightColor; set => isHighlightColor = value; }
        public DashboardReportItemActions DashboardReportItemAction { get => dashboardReportItemAction; set => dashboardReportItemAction = value; }
        public string GetDescription()
        {
            return Description;
        }
        public Color GetHighlightColor()
        {
            return highlightColor;
        }
        public bool IsHighlight()
        {
            return IsHighlightColor;
        }
        public string GetValue()
        {
            return Value;
        }
        public DashboardReportItemActions GetDashboardReportItemActions()
        {
            return DashboardReportItemAction;
        }
    }
}