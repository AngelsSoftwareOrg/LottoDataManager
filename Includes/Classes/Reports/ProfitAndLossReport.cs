using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Game;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Reports
{
    public class ProfitAndLossReport: ReportAbstract
    {
        private List<int> gameCodeList;
        private String reportTitle;
        private String reportTitleGameList;
        private double lifeTimeWinnings;
        private double totalMoneyWinSoFar;
        private double totalMoneyLooseSoFar;
        private double highestAmountWon;
        private double lowestAmountWon;
        private double totalMoneySpentSoFar;
        private int totalMoneyBettedAverageYear;
        private double totalMoneyBettedAverageAmount;
        private int totalNumberOfClaims;
        private int totalNumberOfClaimsToRedeem;
        private Dictionary<String, object> claimDetailsList;
        private int totalBetsMade;
        private DateTime earliestBetTimeYouMade;
        private DateTime latestBetTimeYouMade;
        private Dictionary<String, object> timesWonPerBetCombinationDict;
        private DateTime whenWasLastTimeYouWon;
        private List<double[]> allBetsInTabularMode;
        private List<String[]> allBetsInTabularModeDaysOfWeek;
        private List<String[]> allBetsInTabularModePickGen;
        private List<String[]> allBetsInTabularModeOutlet;
        private List<String[]> allBetsInTabularModeWinningBet;

        public ProfitAndLossReport(List<int> gameCodes) : base(null)
        {
            this.gameCodeList = gameCodes;
            this.claimDetailsList = new Dictionary<string, object>();
            this.earliestBetTimeYouMade = DateTime.Now;
            this.latestBetTimeYouMade = DateTime.Now;
            this.whenWasLastTimeYouWon = DateTimeConverterUtils.GetYear2011();
            this.timesWonPerBetCombinationDict = new Dictionary<string, object>();
            this.allBetsInTabularMode = new List<double[]>();
            this.allBetsInTabularModeDaysOfWeek = new List<String[]>();
            this.allBetsInTabularModePickGen = new List<String[]>();
            this.allBetsInTabularModeOutlet = new List<String[]>();
            this.allBetsInTabularModeWinningBet = new List<String[]>();
            foreach (int gameCode in this.gameCodeList)
            {
                InitializesAllValues(new LotteryDataServices(GameFactory.GetInstance(gameCode)));
            }
            GetTallyAllBetsInTabularMode(this.gameCodeList);
            GetDaysOfWeekTallyAllBetsInTabularMode(this.gameCodeList);
            GetDaysOfWeekTallyPickGen(this.gameCodeList);
            GetOutletTally(this.gameCodeList);
            GetWinningBetDigitTally(this.gameCodeList);
        }
        private void InitializesAllValues(LotteryDataServices lotteryDataServices)
        {
            base.LotteryDataServices = lotteryDataServices;
            SetupReportTitle();
            SetupLifeTimeWinnings();
            GetTotalMoneyYouWinAndLooseSoFar();
            GetMinMaxAmountOfMoneyWon();
            GetTotalMoneySpentSoFar();
            GetTotalMoneyBettedYearlyAverage();
            GetTotalClaimsCount();
            GetAllClaimDetails();
            GetTotalBetsMade();
            TimeSinceTheFirstTimeYouBet();
            GetNumberOfTimesWonPerBetCombination();
            GetWhenWasLastTimeYouWon();
        }
        
        #region Initialization Region
        private void SetupReportTitle()
        {
            if (gameCodeList.Count > 1)
            {
                this.reportTitle = "Combine Game Mode";
                if (String.IsNullOrEmpty(reportTitleGameList)) reportTitleGameList = "";
                if (this.reportTitleGameList.Length > 0) this.reportTitleGameList += ", ";
                this.reportTitleGameList += LotteryDataServices.LotteryDetails.Description;
            }
            else
            {
                this.reportTitle = LotteryDataServices.LotteryDetails.Description;
                this.reportTitleGameList = "";
            }
        }
        private void SetupLifeTimeWinnings()
        {
            lifeTimeWinnings += LotteryDataServices.GetTotalWinningsAmount();
        }
        private void GetTotalMoneyYouWinAndLooseSoFar()
        {
            double[] result = reportDataServices.GetTotalLuckyPickWinAndLoose();
            totalMoneyWinSoFar += result[0];
            totalMoneyLooseSoFar += result[1];
        }
        private void GetMinMaxAmountOfMoneyWon()
        {
            int[] result = this.reportDataServices.GetMinMaxWinningBetAmount();
            if (result[0] > highestAmountWon) highestAmountWon = result[0];
            if (lowestAmountWon > result[1] && result[1] > 0) lowestAmountWon = result[1];
            if (lowestAmountWon <=0) lowestAmountWon = result[1];
        }
        private void GetTotalMoneySpentSoFar()
        {
            totalMoneySpentSoFar += reportDataServices.GetTotalMoneyBetted();
        }
        private void GetTotalMoneyBettedYearlyAverage()
        {
            int years = reportDataServices.GetTotalYearsBetting();
            double totalMoney = reportDataServices.GetTotalMoneyBetted();
            if (years > totalMoneyBettedAverageYear) totalMoneyBettedAverageYear = years;
            totalMoneyBettedAverageAmount += totalMoney;
        }
        private void GetTotalClaimsCount()
        {
            int[] result = reportDataServices.GetTotalClaimsCount();
            totalNumberOfClaims += result[0];
            totalNumberOfClaimsToRedeem += result[1];
        }
        private void GetAllClaimDetails()
        {
            List<LotteryBet> claimDetails = this.reportDataServices.GetAllClaims();
            claimDetailsList.Add(this.LotteryDataServices.LotteryDetails.Description, claimDetails);
        }
        private void GetTotalBetsMade()
        {
            totalBetsMade += reportDataServices.GetTotalBetMade();
        }
        private void TimeSinceTheFirstTimeYouBet()
        {
            DateTime[] datetime = this.reportDataServices.GetMinMaxYearsOfBetting();
            DateTime minDate = datetime[0];
            DateTime maxDate = datetime[1];
            if (minDate.CompareTo(earliestBetTimeYouMade) < 0) earliestBetTimeYouMade = minDate;
            if (maxDate.CompareTo(latestBetTimeYouMade) > 0) latestBetTimeYouMade = maxDate;
        }
        private void GetNumberOfTimesWonPerBetCombination()
        {
            int[] result = this.reportDataServices.GetWinningBetTally();

            for (int ctr = 0; ctr < result.Length; ctr++)
            {
                String key = ResourcesUtils.GetMessage(String.Format("drpt_x_time_{0}_won", ctr + 1));
                if (TimesWonPerBetCombinationDict.ContainsKey(key))
                {
                    int keyValue = (int) TimesWonPerBetCombinationDict[key];
                    keyValue += result[ctr];
                    TimesWonPerBetCombinationDict[key] = keyValue;
                }
                else
                {
                    TimesWonPerBetCombinationDict[key] = result[ctr];
                }
            }
        }
        private void GetWhenWasLastTimeYouWon()
        {
            DateTime won = this.reportDataServices.GetLastTimeYouWon();
            if (won.Date.CompareTo(this.whenWasLastTimeYouWon) > 0) this.whenWasLastTimeYouWon = won;
        }
        private void GetTallyAllBetsInTabularMode(List<int> gameCodes)
        {
            this.allBetsInTabularMode = this.reportDataServices.GetTabularAllBetsSpending(gameCodes);
        }
        private void GetDaysOfWeekTallyAllBetsInTabularMode(List<int> gameCodes)
        {
            this.allBetsInTabularModeDaysOfWeek = this.reportDataServices.GetDaysOfWeekTally(gameCodes);
        }
        private void GetDaysOfWeekTallyPickGen(List<int> gameCodes)
        {
            this.allBetsInTabularModePickGen = this.reportDataServices.GetPickGeneratorsTally(gameCodes);
        }
        private void GetOutletTally(List<int> gameCodes)
        {
            this.allBetsInTabularModeOutlet = this.reportDataServices.GetOutletTally(gameCodes);
        }
        private void GetWinningBetDigitTally(List<int> gameCodes)
        {
            this.allBetsInTabularModeWinningBet = this.reportDataServices.GetWinningBetDigitTally(gameCodes);
        }
        #endregion

        #region Setter and Getter
        public string LifeTimeWinnings { get => lifeTimeWinnings.ToString("C"); }
        public string TotalMoneyWinSoFar { get => totalMoneyWinSoFar.ToString("C"); }
        public string TotalMoneyLooseSoFar { get => totalMoneyLooseSoFar.ToString("C"); }
        public string ReportTitle { get => reportTitle; }
        public string ReportTitleGameList { get => reportTitleGameList; }
        public string HighestAmountWon { get => highestAmountWon.ToString("C"); }
        public string LowestAmountWon { get => lowestAmountWon.ToString("C"); }
        public string TotalMoneySpentSoFar { get => totalMoneySpentSoFar.ToString("C");  }
        public string TotalMoneyBettedYearlyAverage { get => (totalMoneyBettedAverageAmount / totalMoneyBettedAverageYear).ToString("C"); }
        public int TotalNumberOfClaims { get => totalNumberOfClaims;  }
        public int TotalNumberOfClaimsToRedeem { get => totalNumberOfClaimsToRedeem;  }
        public Dictionary<string, object> ClaimDetailsList { get => claimDetailsList; }
        public int TotalBetsMade { get => totalBetsMade;}
        public DateTime EarliestBetTimeYouMade { get => earliestBetTimeYouMade;}
        public DateTime LatestBetTimeYouMade { get => latestBetTimeYouMade;  }
        public String ElapseTimeSinceEaliestBet { get => DateTimeConverterUtils.DateDifferencePeriod(EarliestBetTimeYouMade, LatestBetTimeYouMade); }
        public Dictionary<string, object> TimesWonPerBetCombinationDict { get => timesWonPerBetCombinationDict; }
        public String WhenWasLastTimeYouWon { get => DateTimeConverterUtils.ConvertToFormat(whenWasLastTimeYouWon, DateTimeConverterUtils.DATE_FORMAT_LONG); }
        public List<double[]> AllBetsInTabularMode { get => allBetsInTabularMode;  }
        public List<string[]> AllBetsInTabularModeDaysOfWeek { get => allBetsInTabularModeDaysOfWeek; }
        public List<string[]> AllBetsInTabularModePickGen { get => allBetsInTabularModePickGen;  }
        public List<string[]> AllBetsInTabularModeOutlet { get => allBetsInTabularModeOutlet; }
        public List<string[]> AllBetsInTabularModeWinningBet { get => allBetsInTabularModeWinningBet; }
        #endregion
    }
}
