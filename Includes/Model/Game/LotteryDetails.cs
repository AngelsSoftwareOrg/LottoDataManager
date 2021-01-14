using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes.Scraping;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    public class LotteryDetails
    {
        private GameMode gameMode;
        private String description;
        private Lottery lottery;
        private LotterySchedule lotterySchedule;
        private LotteryTicketPanel lotteryTicketPanel;
        private LotteryWinningCombination lotteryWinningCombination;

        private LotteryDataDerivation lotteryDataDerivation;
        public LotteryDetails(GameMode gameCode, String description = "")
        {
            SetGameCode(gameCode);
            SetupLottery();
            SetupLotterySchedule();
            SetupLotteryTicketPanel();
            SetupLotteryWinningCombination();
            lotteryDataDerivation = new LotteryDataDerivation(gameCode);
            if (String.IsNullOrWhiteSpace(lottery.GetDescription()))
            {
                SetDescription(description);
            }
            else
            {
                SetDescription(lottery.GetDescription());
            }
        }
        internal void SetupLottery()
        {
            LotteryDao lotteryDao = LotteryDaoImpl.GetInstance();
            this.lottery = lotteryDao.GetLottery(gameMode);
        }
        internal void SetupLotterySchedule()
        {
            LotteryScheduleDao lotterySchedDao = LotteryScheduleDaoImpl.GetInstance();
            this.lotterySchedule = lotterySchedDao.GetLotterySchedule(GameMode);
        }
        internal void SetupLotteryTicketPanel()
        {
            LotteryTicketPanelDao lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryTicketPanel = lotteryTicketPanelDao.GetLotteryTicketPanel(GameMode);
        }
        internal void SetupLotteryWinningCombination()
        {
            LotteryWinningCombinationDao lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
            this.lotteryWinningCombination = lotteryWinningCombinationDao.GetLotteryWinningCombination(GameMode);
        }
        protected void SetGameCode(GameMode gameCode) 
        { 
            this.gameMode = gameCode; 
        }
        protected void SetDescription(String description)
        {
            this.description = description;
        }
        public GameMode GameMode { get => gameMode; }
        public int GameCode { get => (int) GameMode; }
        public string Description { get => description; }
        public LotteryDataDerivation LotteryDataDerivation { get => lotteryDataDerivation; }
        public List<LotteryDrawResult> GetLotteryDrawResults(DateTime startingDate)
        {
            if (startingDate >= DateTime.Now) throw new Exception("Date should be backdated when getting new Draw Results!");
            LotteryDrawResultDao drDao = LotteryDrawResultDaoImpl.GetInstance();
            return drDao.GetDrawResultsFromStartingDate(GameMode, startingDate);
        }
        public List<LotteryBet> GetLottoBets(DateTime sinceWhen)
        {
            if (sinceWhen >= DateTime.Now) throw new Exception("Date should be backdated when getting new Draw Bets!");
            LotteryBetDao betDao = LotteryBetDaoImpl.GetInstance();
            return betDao.GetDashboardLatestBets(GameMode, sinceWhen);
        }
        public Lottery Lottery
        {
            get
            {
                return this.lottery;
            }
        }
        public double GetTotalWinningsAmount()
        {
            LotteryWinningBetDao lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            return lotteryWinningBetDao.GetTotalWinningsAmount(this.GameMode);
        }
        public double GetTotalWinningsAmountThisMonth()
        {
            LotteryWinningBetDao lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            return lotteryWinningBetDao.GetTotalWinningsAmountThisMonth(this.GameMode);
        }
    }
}
