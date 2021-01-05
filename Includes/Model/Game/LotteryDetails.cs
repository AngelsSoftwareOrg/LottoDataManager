using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Model.Settings;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    public class LotteryDetails
    {
        private GameMode gameCode;
        private String description;
        private LotterySchedule lotterySchedule;
        private LotteryTicketPanel lotteryTicketPanel;
        private LotteryWinningCombination lotteryWinningCombination;

        public LotteryDetails(GameMode gameCode, String description="")
        {
            SetGameCode(gameCode);
            SetDescription(description);
            SetupLotterySchedule();
            SetupLotteryTicketPanel();
            SetupLotteryWinningCombination();
        }

        private void SetupLotterySchedule()
        {
            LotteryScheduleDao lotterySchedDao = LotteryScheduleDaoImpl.GetInstance();
            this.lotterySchedule = lotterySchedDao.GetLotterySchedule(GameCode);
        }
        private void SetupLotteryTicketPanel()
        {
            LotteryTicketPanelDao lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryTicketPanel = lotteryTicketPanelDao.GetLotteryTicketPanel(GameCode);
        }
        private void SetupLotteryWinningCombination()
        {

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
    }
}
