using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    public class LotteryDetails
    {
        private GameMode gameCode;
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
            this.lottery = lotteryDao.GetLottery(gameCode);
        }
        internal void SetupLotterySchedule()
        {
            LotteryScheduleDao lotterySchedDao = LotteryScheduleDaoImpl.GetInstance();
            this.lotterySchedule = lotterySchedDao.GetLotterySchedule(GameCode);
        }
        internal void SetupLotteryTicketPanel()
        {
            LotteryTicketPanelDao lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryTicketPanel = lotteryTicketPanelDao.GetLotteryTicketPanel(GameCode);
        }
        internal void SetupLotteryWinningCombination()
        {
            LotteryWinningCombinationDao lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
            this.lotteryWinningCombination = lotteryWinningCombinationDao.GetLotteryWinningCombination(GameCode);
        }
        protected void SetGameCode(GameMode gameCode) 
        { 
            this.gameCode = gameCode; 
        }
        protected void SetDescription(String description)
        {
            this.description = description;
        }
        public GameMode GameCode { get => gameCode; }
        public string Description { get => description; }
        public LotteryDataDerivation LotteryDataDerivation { get => lotteryDataDerivation; }
        public List<LotteryDrawResult> GetAllLotteryDrawResults()
        {
            LotteryDrawResultDao drDao = LotteryDrawResultDaoImpl.GetInstance();
            return drDao.GetAllDrawResults(GameCode);
        }
        public List<LotteryBet> GetLottoBets(DateTime sinceWhen)
        {
            LotteryBetDao betDao = LotteryBetDaoImpl.GetInstance();
            return betDao.GetDashboardLatestBets(GameCode, sinceWhen);
        }

    }
}
