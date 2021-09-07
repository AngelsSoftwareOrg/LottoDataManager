using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Reports;
using LottoDataManager.Includes.Model.Reports.Setup;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Reports
{
    public class DashboardReport : ReportAbstract
    {
        private List<DashboardReportItemSetup> dashboardReportList = new List<DashboardReportItemSetup>();
        public DashboardReport(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
        }
        public List<DashboardReportItemSetup> GetDashboardReport()
        {
            dashboardReportList = new List<DashboardReportItemSetup>();
            dashboardReportList.AddRange(GetPreviousDrawDates());
            dashboardReportList.AddRange(GetNextDrawDates());
            dashboardReportList.Add(GetTotalBetsMade());
            dashboardReportList.AddRange(GetTotalClaimsCount());
            dashboardReportList.AddRange(GetTotalLuckypickWinAndLoose());
            dashboardReportList.Add(GetTotalMoneyBetted());
            dashboardReportList.Add(GetTotalMoneyBettedLastYear());
            dashboardReportList.Add(GetTotalYearsOfBetting());
            dashboardReportList.Add(GetTotalMoneyBettedYearlyAverage());
            dashboardReportList.AddRange(GetNumberOfTimeWonADigitSequence());
            dashboardReportList.Add(GetLastTimeYouWon());
            dashboardReportList.AddRange(GetMinMaxWinningBetAmount());
            dashboardReportList.AddRange(GetMonthlyAndAnnualSpending());
            return dashboardReportList;
        }
        public List<DashboardReportGroup> GetDashboardReportInGroup()
        {
            List<DashboardReportGroup> dbGroup = new List<DashboardReportGroup>();

            DashboardReportGroup previousDatesGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_lottery_schedules"));
            previousDatesGroup.AddDashboardItems(GetPreviousDrawDates());
            dbGroup.Add(previousDatesGroup);

            DashboardReportGroup nxtDrawDatesGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_lottery_schedules"));
            nxtDrawDatesGroup.AddDashboardItems(GetNextDrawDates());
            dbGroup.Add(nxtDrawDatesGroup);

            DashboardReportGroup totalBetsMadeGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_how_many_bet_you_made_value"));
            totalBetsMadeGroup.AddDashboardItem(GetTotalBetsMade());
            dbGroup.Add(totalBetsMadeGroup);

            DashboardReportGroup totalClaimsCountGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_total_claims_related"));
            totalClaimsCountGroup.AddDashboardItems(GetTotalClaimsCount());
            dbGroup.Add(totalClaimsCountGroup);

            DashboardReportGroup totalLuckypickWinAndLooseGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_lp_related"));
            totalLuckypickWinAndLooseGroup.AddDashboardItems(GetTotalLuckypickWinAndLoose());
            dbGroup.Add(totalLuckypickWinAndLooseGroup);

            DashboardReportGroup totalMoneyBettedGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_total_money_betted_related"));
            totalMoneyBettedGroup.AddDashboardItem(GetTotalMoneyBetted());
            dbGroup.Add(totalMoneyBettedGroup);

            DashboardReportGroup totalMoneyBettedLastYearGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_total_money_betted_related"));
            totalMoneyBettedLastYearGroup.AddDashboardItem(GetTotalMoneyBettedLastYear());
            dbGroup.Add(totalMoneyBettedLastYearGroup);

            DashboardReportGroup totalYearsOfBettingGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_total_money_betted_related"));
            totalYearsOfBettingGroup.AddDashboardItem(GetTotalYearsOfBetting());
            dbGroup.Add(totalYearsOfBettingGroup);

            DashboardReportGroup totalMoneyBettedYearlyAverageGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_total_money_betted_related"));
            totalMoneyBettedYearlyAverageGroup.AddDashboardItem(GetTotalMoneyBettedYearlyAverage());
            dbGroup.Add(totalMoneyBettedYearlyAverageGroup);

            DashboardReportGroup numberOfTimeWonADigitSequenceGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_winning_stats_related"));
            numberOfTimeWonADigitSequenceGroup.AddDashboardItems(GetNumberOfTimeWonADigitSequence());
            dbGroup.Add(numberOfTimeWonADigitSequenceGroup);

            DashboardReportGroup lastTimeYouWonGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_money_won"));
            lastTimeYouWonGroup.AddDashboardItem(GetLastTimeYouWon());
            dbGroup.Add(lastTimeYouWonGroup);

            DashboardReportGroup minMaxWinningBetAmountGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_money_won"));
            minMaxWinningBetAmountGroup.AddDashboardItems(GetMinMaxWinningBetAmount());
            dbGroup.Add(minMaxWinningBetAmountGroup);

            DashboardReportGroup monthlyAndAnnualSpendingGroup = new DashboardReportGroupSetup(ResourcesUtils.GetMessage("drpt_spending_details"));
            monthlyAndAnnualSpendingGroup.AddDashboardItems(GetMonthlyAndAnnualSpending());
            dbGroup.Add(monthlyAndAnnualSpendingGroup);

            return dbGroup;
        }

        private DashboardReportItemSetup GetTotalBetsMade()
        {
            String key = ResourcesUtils.GetMessage("drpt_how_many_bet_you_made_value");
            String value = reportDataServices.GetTotalBetMade().ToString();

            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_how_many_bet_you_made");
            return itm;
        }
        private List<DashboardReportItemSetup> GetTotalClaimsCount()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            String groupKeyName = ResourcesUtils.GetMessage("drpt_total_claims_related");
            int[] result = reportDataServices.GetTotalClaimsCount();
            DashboardReportItemSetup dshSetup0 = GenModel(ResourcesUtils.GetMessage("drpt_total_num_claims"), result[0].ToString());
            DashboardReportItemSetup dshSetup1 = GenModel(ResourcesUtils.GetMessage("drpt_total_claims_to_pick_up"), result[1].ToString());
            if (result[1] > 0)
            {
                dshSetup1.IsHighlightColor = true;
                dshSetup1.HighlightColor = Color.GreenYellow;
                dshSetup1.DashboardReportItemAction = DashboardReportItemActions.OPEN_CLAIM_FORM;
            }
            dshSetup0.GroupKeyName = groupKeyName;
            dshSetup1.GroupKeyName = groupKeyName;
            itemsList.Add(dshSetup0);
            itemsList.Add(dshSetup1);
            return itemsList;
        }
        private List<DashboardReportItemSetup> GetTotalLuckypickWinAndLoose()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            double[] result = reportDataServices.GetTotalLuckyPickWinAndLoose();
            itemsList.Add(GenModel(
                ResourcesUtils.GetMessage("drpt_lp_total_wins"), result[0].ToString("C")));
            itemsList.Add(GenModel(
                ResourcesUtils.GetMessage("drpt_lp_total_loose"), result[1].ToString("C")));
            
            foreach(DashboardReportItemSetup itm in itemsList)
            {
                itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_lp_related");
            }
            return itemsList;
        }
        private DashboardReportItemSetup GetTotalMoneyBetted()
        {
            String key = ResourcesUtils.GetMessage("drpt_total_money_betted");
            String value = reportDataServices.GetTotalMoneyBetted().ToString("C");
            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_total_money_betted_related");
            return itm;
        }
        private DashboardReportItemSetup GetTotalMoneyBettedLastYear()
        {
            String key = ResourcesUtils.GetMessage("drpt_total_money_betted_last_year");
            String value = reportDataServices.GetTotalMoneyBettedLastYear().ToString("C");
            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_total_money_betted_related");
            return itm;
        }
        private DashboardReportItemSetup GetTotalMoneyBettedYearlyAverage()
        {
            int years = reportDataServices.GetTotalYearsBetting();
            double totalMoney = reportDataServices.GetTotalMoneyBetted();
            if (years > 0) totalMoney = totalMoney / years;
            String key = ResourcesUtils.GetMessage("drpt_total_money_betted_yearly");
            String value = totalMoney.ToString("C");
            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_total_money_betted_related");
            return itm;
        }
        private DashboardReportItemSetup GetTotalYearsOfBetting()
        {
            String key = ResourcesUtils.GetMessage("drpt_total_years_betting");
            String value = reportDataServices.GetTotalYearsBetting().ToString();
            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_total_money_betted_related");
            return itm;
        }
        private List<DashboardReportItemSetup> GetNumberOfTimeWonADigitSequence()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            int[] result = this.reportDataServices.GetWinningBetTally();

            for (int ctr = 0; ctr < result.Length; ctr++)
            {
                String key = ResourcesUtils.GetMessage(String.Format("drpt_x_time_{0}_won", ctr + 1));
                String value = result[ctr].ToString();
                DashboardReportItemSetup itm = GenModel(key, value);
                itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_winning_stats_related");
                itemsList.Add(itm);
            }
            return itemsList;
        }
        private DashboardReportItemSetup GetLastTimeYouWon()
        {
            String key = ResourcesUtils.GetMessage("drpt_last_time_won");
            String value = DateTimeConverterUtils.ConvertToFormat(this.reportDataServices.GetLastTimeYouWon(), DateTimeConverterUtils.DATE_FORMAT_LONG);
            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_money_won");
            return itm;
        }
        private List<DashboardReportItemSetup> GetMinMaxWinningBetAmount()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            int[] result = this.reportDataServices.GetMinMaxWinningBetAmount();
            String key = ResourcesUtils.GetMessage("drpt_low_amt_money_won");
            String value = result[0].ToString("C");
            DashboardReportItemSetup itm = GenModel(key, value);
            itm.GroupKeyName = ResourcesUtils.GetMessage("drpt_money_won");
            itemsList.Add(itm);

            key = ResourcesUtils.GetMessage("drpt_high_amt_money_won");
            value = result[1].ToString("C");
            DashboardReportItemSetup itm2 = GenModel(key, value);
            itm2.GroupKeyName = ResourcesUtils.GetMessage("drpt_money_won");
            itemsList.Add(itm2);
            return itemsList;
        }
        private List<DashboardReportItemSetup> GetMonthlyAndAnnualSpending()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            int thisyear = DateTime.Now.Year;
            int lastyear = thisyear - 1;

            double[] resultLastYear = this.reportDataServices.GetMonthlySpending(lastyear);
            double[] resultThisYear = this.reportDataServices.GetMonthlySpending(thisyear);

            //monthly
            for (int ctr = 0; ctr < resultLastYear.Length - 1; ctr++)
            {
                String msg = ResourcesUtils.GetMessage(String.Format("drpt_monthly_spending_{0}", ctr + 1));
                String key = String.Format(msg, thisyear, lastyear);
                String value = String.Format("{0} / {1}", resultThisYear[ctr].ToString("C"), resultLastYear[ctr].ToString("C"));

                DashboardReportItemSetup mntly = GenModel(key, value);
                mntly.GroupKeyName = ResourcesUtils.GetMessage("drpt_spending_details");
                itemsList.Add(mntly);
            }

            //annual
            String msg2 = ResourcesUtils.GetMessage("drpt_annual_spending");
            String key2 = String.Format(msg2, thisyear, lastyear);
            String value2 = String.Format("{0} / {1}", resultThisYear[12].ToString("C"), resultLastYear[12].ToString("C"));
            DashboardReportItemSetup mntly1 = GenModel(key2, value2);
            mntly1.GroupKeyName = ResourcesUtils.GetMessage("drpt_spending_details");
            itemsList.Add(mntly1);

            return itemsList;
        }
        private List<DashboardReportItemSetup> GetNextDrawDates()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            int ctrDays = 14;
            LotterySchedule lotterySchedule = LotteryDataServices.GetLotterySchedule();
            DateTime dateStartingTommorow = DateTime.Now.AddDays(1);
            int idxLabel = 1;
            for (int ctr = 1; ctr <= ctrDays; ctr++)
            {
                if (lotterySchedule.IsDrawDateMatchLotterySchedule(dateStartingTommorow)) {
                    String key = String.Format("{0} ({1})", ResourcesUtils.GetMessage("drpt_next_lottery_sched"), idxLabel++);
                    String value = DateTimeConverterUtils.ConvertToFormat(dateStartingTommorow, DateTimeConverterUtils.DATE_FORMAT_LONG);

                    DashboardReportItemSetup itm2 = GenModel(key, value);
                    itm2.GroupKeyName = ResourcesUtils.GetMessage("drpt_lottery_schedules");
                    itemsList.Add(itm2);
                }
                dateStartingTommorow = dateStartingTommorow.AddDays(1);
            }
            return itemsList;
        }
        private List<DashboardReportItemSetup> GetPreviousDrawDates()
        {
            List<DashboardReportItemSetup> itemsList = new List<DashboardReportItemSetup>();
            int ctrDays = 14;
            LotterySchedule lotterySchedule = LotteryDataServices.GetLotterySchedule();
            DateTime dateLastXDays = DateTime.Now.AddDays(-ctrDays);
            int idxLabel = 1;
            //for one week schedule only
            for (int ctr = 1; ctr <= ctrDays; ctr++)
            {
                if (lotterySchedule.IsDrawDateMatchLotterySchedule(dateLastXDays))
                {
                    String key = String.Format("{0} ({1})", ResourcesUtils.GetMessage("drpt_prev_lottery_sched"), idxLabel++);
                    String value = DateTimeConverterUtils.ConvertToFormat(dateLastXDays, DateTimeConverterUtils.DATE_FORMAT_LONG);
                    DashboardReportItemSetup dshSetup = GenModel(key, value);
                    dshSetup.FontColor = Color.Gray;
                    dshSetup.GroupKeyName = ResourcesUtils.GetMessage("drpt_lottery_schedules");
                    itemsList.Add(dshSetup);
                }
                dateLastXDays = dateLastXDays.AddDays(1);
            }
            return itemsList;
        }
        public String ReportTitle
        {
            get
            {
                return this.LotteryDataServices.LotteryDetails.Description;
            }
        }
        private DashboardReportItemSetup GenModel(String key, String value)
        {
            return new DashboardReportItemSetup() { Description = key, Value = value };
        }
    }
}
