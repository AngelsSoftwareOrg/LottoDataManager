using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Reports
{
    public class DashboardReport: ReportAbstract
    {
        private List<KeyValuePair<String, String>> dashboardReportList = new List<KeyValuePair<string, string>>();

        public DashboardReport(LotteryDetails lotteryDetails): base(lotteryDetails)
        {
        }

        public List<KeyValuePair<String, String>> GetDashboardReport()
        {
            dashboardReportList = new List<KeyValuePair<string, string>>();
            GetTotalMoneyBetted();
            GetTotalMoneyBettedLastYear();
            GetTotalYearsOfBetting();
            GetTotalMoneyBettedYearlyAverage();
            return dashboardReportList;
        }

        private void GetTotalMoneyBetted()
        {
            String key = ResourcesUtils.GetMessage("drpt_total_money_betted");
            String value = reportDataServices.GetTotalMoneyBetted().ToString("C");
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
        private void GetTotalMoneyBettedLastYear()
        {
            String key = ResourcesUtils.GetMessage("drpt_total_money_betted_last_year");
            String value = reportDataServices.GetTotalMoneyBettedLastYear().ToString("C");
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
        private void GetTotalMoneyBettedYearlyAverage()
        {
            int years = reportDataServices.GetTotalYearsBetting();
            double totalMoney = reportDataServices.GetTotalMoneyBetted();
            if(years > 0) totalMoney = totalMoney / years;
            String key = ResourcesUtils.GetMessage("drpt_total_money_betted_yearly");
            String value = totalMoney.ToString("C");
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
        private void GetTotalYearsOfBetting()
        {
            String key = ResourcesUtils.GetMessage("drpt_total_years_betting");
            String value = reportDataServices.GetTotalYearsBetting().ToString();
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
