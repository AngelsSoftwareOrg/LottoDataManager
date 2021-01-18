using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes
{
    public class LotteryDataServices
    {
        private LotteryDetails lotteryDetails;
        private LotteryDataDerivation lotteryDataDerivation;
        private UserSettingDao userSettingDao;
        private LotteryTicketPanelDao lotteryTicketPanelDao;
        private LotteryOutletDao lotteryOutletDao;
        private LotteryBetDao lotteryBetDao;

        public LotteryDataServices(LotteryDetails lotteryDetails)
        {
            this.lotteryDetails = lotteryDetails;
            this.lotteryDataDerivation = new LotteryDataDerivation(this.LotteryDetails.GameMode);
            this.lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryOutletDao = LotteryOutletDaoImpl.GetInstance();
            this.lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            userSettingDao = UserSettingDaoImpl.GetInstance();
        }
        private GameMode GameMode {

            get
            {
                return this.LotteryDetails.GameMode;
            }
        }
        public LotteryDetails LotteryDetails { get => lotteryDetails; }
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
        public List<Lottery> GetLotteries()
        {
            LotteryDao lotteryDao = LotteryDaoImpl.GetInstance();
            return lotteryDao.GetLotteries();
        }
        public DateTime GetNextDrawDate()
        {
            return lotteryDataDerivation.GetNextDrawDate();
        }
        public void SaveLastOpenedLottery()
        {
            this.userSettingDao.SaveLastOpenedLottery(this.LotteryDetails.GameCode);
        }
        public String GetNextDrawDateFormatted()
        {
            String result = "";
            DateTime nextScheduledDate = GetNextDrawDate();
            if (nextScheduledDate.Date == DateTime.Today) result = "Today! ";
            return (result + nextScheduledDate.ToString(DateTimeConverterUtils.DATE_FORMAT_LONG));
        }
        public LotteryTicketPanel GetLotteryTicketPanel()
        {
            return lotteryTicketPanelDao.GetLotteryTicketPanel(GameMode);
        }
        public List<LotteryOutlet> GetLotteryOutlets()
        {
            return lotteryOutletDao.GetLotteryOutlets();
        }
        public void SaveLotteryBets(List<LotteryBet> lotteryBets)
        {
            this.lotteryBetDao.InsertLotteryBet(lotteryBets);
        }
    }
}
