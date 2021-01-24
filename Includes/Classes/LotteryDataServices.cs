﻿using System;
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
        private LotteryScheduleDao lotteryScheduleDao;
        private LotteryWinningBetDao lotteryWinningBetDao;
        private LotteryDataWorker lotteryDataWorker;
        private LotteryDrawResultDao lotteryDrawResultDao;

        public LotteryDataServices(LotteryDetails lotteryDetails)
        {
            this.lotteryDetails = lotteryDetails;
            this.lotteryDataDerivation = new LotteryDataDerivation(this.LotteryDetails.GameMode);
            this.lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryOutletDao = LotteryOutletDaoImpl.GetInstance();
            this.lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            this.userSettingDao = UserSettingDaoImpl.GetInstance();
            this.lotteryScheduleDao = LotteryScheduleDaoImpl.GetInstance();
            this.lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            this.lotteryDataWorker = LotteryDataWorker.GetInstance();
            this.lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
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
            return lotteryDrawResultDao.GetDrawResultsFromStartingDate(GameMode, startingDate);
        }
        public LotteryDrawResult GetLotteryDrawResultByDrawDate(DateTime drawDate)
        {
            return lotteryDrawResultDao.GetLotteryDrawResultByDrawDate(GameMode, drawDate);
        }
        public List<LotteryBet> GetLottoBets(DateTime sinceWhen)
        {
            if (sinceWhen >= DateTime.Now) throw new Exception("Date should be backdated when getting new Draw Bets!");
            LotteryBetDao betDao = LotteryBetDaoImpl.GetInstance();
            return betDao.GetDashboardLatestBets(GameMode, sinceWhen);
        }
        public List<LotteryBet> GetLottoBetsByDrawDate(DateTime betDrawDate)
        {
            LotteryBetDao betDao = LotteryBetDaoImpl.GetInstance();
            return betDao.GetLotteryBets(GameMode, betDrawDate);
        }
        public double GetTotalWinningsAmount()
        {
            return lotteryWinningBetDao.GetTotalWinningsAmount(this.GameMode);
        }
        public double GetTotalWinningsAmountThisMonth()
        {
            return lotteryWinningBetDao.GetTotalWinningsAmountThisMonth(this.GameMode);
        }
        public List<LotteryWinningBet> GetLotteryWinningBets(DateTime sinceWhen)
        {
            return lotteryWinningBetDao.GetLotteryWinningBet(this.GameMode, sinceWhen);
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
        public LotterySchedule GetLotterySchedule()
        {
            return this.lotteryScheduleDao.GetLotterySchedule(this.GameMode);
        }
        public void DeleteLotteryBet(List<LotteryBet> lotteryBets)
        {
            foreach(LotteryBet lotteryBet in lotteryBets)
            {
                DeleteLotteryBet(lotteryBet);
            }
        }
        public void DeleteLotteryBet(LotteryBet lotteryBet)
        {
            this.lotteryBetDao.RemoveLotteryBet(lotteryBet.GetId());
            this.lotteryWinningBetDao.RemoveLotteryWinningBet(lotteryBet.GetId());
        }
        public void SaveLotteryBetChange(LotteryBet lotteryBet)
        {
            if (lotteryBetDao.IsBetExisting(lotteryBet)) return;
            DeleteLotteryBet(lotteryBet);
            int newId = lotteryBetDao.InsertLotteryBet(lotteryBet);
            LotteryBetSetup lotteryBetSetup = (LotteryBetSetup) lotteryBet;
            lotteryBetSetup.Id = newId;
            this.lotteryDataWorker.ProcessWinningBet(lotteryBetSetup);
        }
        public void UpdateClaimStatus(LotteryWinningBet winBet)
        {
            lotteryWinningBetDao.UpdateClaimStatus(winBet);
        }
    }
}