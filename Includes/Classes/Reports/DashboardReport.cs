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
            GetTotalBetsMade();
            GetTotalClaimsCount();
            GetTotalLuckypickWinAndLoose();
            GetTotalMoneyBetted();
            GetTotalMoneyBettedLastYear();
            GetTotalYearsOfBetting();
            GetTotalMoneyBettedYearlyAverage();
            GetNumberOfTimeWonADigitSequence();
            GetLastTimeYouWon();
            GetMinMaxWinningBetAmount();
            return dashboardReportList;
        }
        
        private void GetTotalBetsMade()
        {
            String key = ResourcesUtils.GetMessage("drpt_how_many_bet_you_made");
            String value = reportDataServices.GetTotalBetMade().ToString();
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
        private void GetTotalClaimsCount()
        {
            int[] result = reportDataServices.GetTotalClaimsCount();
            dashboardReportList.Add(new KeyValuePair<string, string>(
                ResourcesUtils.GetMessage("drpt_total_num_claims"), result[0].ToString()));
            dashboardReportList.Add(new KeyValuePair<string, string>(
                ResourcesUtils.GetMessage("drpt_total_claims_to_pick_up"), result[1].ToString()));
        }
        private void GetTotalLuckypickWinAndLoose()
        {
            double[] result = reportDataServices.GetTotalLuckyPickWinAndLoose();
            dashboardReportList.Add(new KeyValuePair<string, string>(
                ResourcesUtils.GetMessage("drpt_lp_total_wins"), result[0].ToString("C")));
            dashboardReportList.Add(new KeyValuePair<string, string>(
                ResourcesUtils.GetMessage("drpt_lp_total_loose"), result[1].ToString("C")));
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
        private void GetNumberOfTimeWonADigitSequence()
        {
            int[] result = this.reportDataServices.GetWinningBetTally();

            for(int ctr=0; ctr < result.Length; ctr++)
            {
                String key = ResourcesUtils.GetMessage(String.Format("drpt_x_time_{0}_won", ctr + 1));
                String value = result[ctr].ToString();
                dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
            }
        }
        private void GetLastTimeYouWon()
        {
            String key = ResourcesUtils.GetMessage("drpt_last_time_won");
            String value = DateTimeConverterUtils.ConvertToFormat(this.reportDataServices.GetLastTimeYouWon(), DateTimeConverterUtils.DATE_FORMAT_LONG);
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
        private void GetMinMaxWinningBetAmount()
        {
            int[] result = this.reportDataServices.GetMinMaxWinningBetAmount();
            String key = ResourcesUtils.GetMessage("drpt_low_amt_money_won");
            String value = result[0].ToString();
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));

            key = ResourcesUtils.GetMessage("drpt_high_amt_money_won");
            value = result[1].ToString();
            dashboardReportList.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
