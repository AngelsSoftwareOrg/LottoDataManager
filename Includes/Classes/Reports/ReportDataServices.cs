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

namespace LottoDataManager.Includes.Classes.Reports
{
    public class ReportDataServices
    {
        private LotteryDetails lotteryDetails;
        private LotteryDataDerivation lotteryDataDerivation;
        private UserSettingDao userSettingDao;
        private LotteryTicketPanelDao lotteryTicketPanelDao;
        private LotteryOutletDao lotteryOutletDao;
        private LotteryBetDao lotteryBetDao;
        private LotteryScheduleDao lotteryScheduleDao;
        private LotteryWinningBetDao lotteryWinningBetDao;
        private LotteryDataWorker lotteryDataWorker;
        private LotteryDrawResultDao lotteryDrawResultDao;
        public ReportDataServices(LotteryDetails lotteryDetails)
        {
            this.lotteryDetails = lotteryDetails;
            this.lotteryDataDerivation = new LotteryDataDerivation(GameMode);
            this.lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryOutletDao = LotteryOutletDaoImpl.GetInstance();
            this.lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            this.userSettingDao = UserSettingDaoImpl.GetInstance();
            this.lotteryScheduleDao = LotteryScheduleDaoImpl.GetInstance();
            this.lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            this.lotteryDataWorker = new LotteryDataWorker();
            this.lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
        }
        private GameMode GameMode { get { return this.lotteryDetails.GameMode; } }
        public double GetTotalMoneyBetted()
        {
            return lotteryBetDao.GetTotalAmountBetted(GameMode, DateTimeConverterUtils.GetYear2000(), DateTime.Now);
        }
        public double GetTotalMoneyBettedLastYear()
        {
            DateTime lastYearFrom = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
            DateTime lastYearTo = lastYearFrom.AddYears(1).AddDays(-1);
            return lotteryBetDao.GetTotalAmountBetted(GameMode, lastYearFrom, lastYearTo);
        }
        public int GetTotalYearsBetting()
        {
            return lotteryBetDao.GetTotalYearsOfBetting(GameMode);
        }
        public int[] GetWinningBetTally()
        {
            return this.lotteryWinningBetDao.GetWinningBetNumbersTally(GameMode);
        }
        public DateTime GetLastTimeYouWon()
        {
            return this.lotteryBetDao.GetLastTimeWon(GameMode);
        }
        public int[] GetMinMaxWinningBetAmount()
        {
            return this.lotteryWinningBetDao.GetMinMaxWinningBetAmount(GameMode);
        }
        public int GetTotalBetMade()
        {
            return this.lotteryBetDao.GetTotalBetMade(GameMode);
        }
        public int[] GetTotalClaimsCount()
        {
            return this.lotteryBetDao.GetTotalNumberOfClaims(GameMode);
        }
        public double[] GetTotalLuckyPickWinAndLoose()
        {
            return this.lotteryBetDao.GetTotalLuckyPickWinAndLoose(GameMode);
        }
    }
}
