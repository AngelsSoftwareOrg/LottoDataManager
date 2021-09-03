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
        private LotteryScheduleDao lotteryScheduleDao;
        private LotteryWinningBetDao lotteryWinningBetDao;
        private LotteryDataWorker lotteryDataWorker;
        private LotteryDrawResultDao lotteryDrawResultDao;
        private LotterySequenceGenDao lotterySeqGenDao;
        private LotteryWinningCombinationDao lotteryWinningCombinationDao;
        private UserSettings userSetting;
        public LotteryDataServices(LotteryDetails lotteryDetails)
        {
            this.lotteryDetails = lotteryDetails;
            this.userSetting = new UserSettings();
            this.lotteryDataDerivation = new LotteryDataDerivation(this.LotteryDetails.GameMode);
            this.lotteryTicketPanelDao = LotteryTicketPanelDaoImpl.GetInstance();
            this.lotteryOutletDao = LotteryOutletDaoImpl.GetInstance();
            this.lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            this.userSettingDao = UserSettingDaoImpl.GetInstance();
            this.lotteryScheduleDao = LotteryScheduleDaoImpl.GetInstance();
            this.lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            this.lotteryDataWorker = new LotteryDataWorker();
            this.lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            this.lotterySeqGenDao = LotterySequenceGenDaoImpl.GetInstance();
            this.lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
        }
        private GameMode GameMode {

            get
            {
                return this.LotteryDetails.GameMode;
            }
        }
        public LotteryDetails LotteryDetails { get => lotteryDetails; }
        public List<LotteryDrawResult> GetLotteryDrawResults(DateTime startingDate, DateTime endingDate)
        {
            //if later than
            if (startingDate.Date.CompareTo(endingDate.Date) > 0) throw new Exception(ResourcesUtils.GetMessage("lot_data_srv_cls_msg_4"));

            //earlier than
            if (endingDate.Date.CompareTo(startingDate.Date) < 0) throw new Exception(ResourcesUtils.GetMessage("lot_data_srv_cls_msg_4"));
            return lotteryDrawResultDao.GetDrawResultsFromStartingDate(GameMode, startingDate, endingDate);
        }
        public LotteryDrawResult GetLotteryDrawResultByDrawDate(DateTime drawDate)
        {
            return lotteryDrawResultDao.GetLotteryDrawResultByDrawDate(GameMode, drawDate);
        }
        public List<LotteryBet> GetLottoBets(DateTime sinceWhen, DateTime dateTo)
        {
            //if later than
            if (sinceWhen.Date.CompareTo(dateTo.Date)>0) throw new Exception(ResourcesUtils.GetMessage("lot_data_srv_cls_msg_4"));
            
            //earlier than
            if (dateTo.Date.CompareTo(sinceWhen.Date)<0) throw new Exception(ResourcesUtils.GetMessage("lot_data_srv_cls_msg_4"));

            return lotteryBetDao.GetDashboardLatestBets(GameMode, sinceWhen, dateTo);
        }
        public List<LotteryBet> GetLottoBetsByDrawDate(DateTime betDrawDate)
        {
            return lotteryBetDao.GetLotteryBets(GameMode, betDrawDate);
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
            bool isPastCutoff = IsPastTicketSellingCutoffTime();
            DateTime basisDate = DateTime.Now;
            if (isPastCutoff) basisDate = basisDate.AddDays(1);
            return lotteryDataDerivation.GetNextDrawDate(basisDate);
        }
        public void SaveLastOpenedLottery()
        {
            this.userSetting.SaveLastOpenedLottery(this.lotteryDetails.GameCode);
        }
        public void SaveTicketCutoffTime(DateTime newCutoffTime)
        {
            this.userSetting.SaveTicketCutoffTime(newCutoffTime);
        }
        public DateTime GetTicketCutoffTime(bool useDateToday=false)
        {
            if(useDateToday)
            {
                return this.userSetting.GetTicketCutoffTimeUsingCurrentDate();
            }

            return this.userSetting.GetTicketCutoffTime();
        }
        public int GetTicketCutoffNotifyTime()
        {
            return this.userSetting.GetTicketCutoffNotifyTime();
        }
        public void SaveTicketCutoffNotifyTime(int newValue)
        {
            this.userSetting.SaveTicketCutoffNotifyTime(newValue);
        }
        public bool IsUserToNotifyTicketCutoffIsNear()
        {
            int totalMinutesBeforeCutoff = GetTicketCutoffNotifyTime();
            DateTime cutoffTime = GetTicketCutoffTime(true);

            if (this.userSetting.IsPastTicketSellingCutoffTime(cutoffTime)) return false;

            DateTime dateNow = DateTime.Now;
            TimeSpan ts = cutoffTime - dateNow;

            //DEBUGGING
            //Console.WriteLine("No. of Minutes (Difference) = {0}, {1}, {2}", ts.TotalMinutes, totalMinutesBeforeCutoff, (totalMinutesBeforeCutoff > ts.TotalMinutes));

            if (totalMinutesBeforeCutoff > ts.TotalMinutes) return true;
            return false;
        }
        public String GetTicketCutOffTimeOnly()
        {
            return GetTicketCutoffTime().ToString(DateTimeConverterUtils.DT_TICKET_CUTOFF_TIME_FORMAT_TIME_ONLY_FOR_UI).ToUpper();
        }
        public bool IsPastTicketSellingCutoffTime()
        {
            return this.userSetting.IsPastTicketSellingCutoffTime(GetTicketCutoffTime(true));
        }
        public String GetNextDrawDateFormatted()
        {
            String result = "";
            DateTime nextScheduledDate = GetNextDrawDate();
            if (nextScheduledDate.Date == DateTime.Today) result = ResourcesUtils.GetMessage("lot_data_srv_cls_msg_3");
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
        public LotteryOutlet GetDefaultLotteryOutlet()
        {
            return lotteryOutletDao.GetDefaultLotteryOutlet();
        }
        public void SaveLotteryBets(List<LotteryBet> lotteryBets)
        {
            this.lotteryBetDao.InsertLotteryBet(lotteryBets);
        }
        public LotterySchedule GetLotterySchedule()
        {
            return this.lotteryScheduleDao.GetLotterySchedule(this.GameMode);
        }
        public LotterySchedule GetLotterySchedule(GameMode gameMode)
        {
            return this.lotteryScheduleDao.GetLotterySchedule(gameMode);
        }
        public int AddNewLotterySchedule(LotterySchedule lotterySchedule)
        {
            LotterySchedule original = this.lotteryScheduleDao.GetLotterySchedule(lotterySchedule.GetGameMode());
            if(original.IsEqualSchedule(lotterySchedule)){
                throw new Exception(ResourcesUtils.GetMessage("lott_sched_msg1"));
            }
            this.lotteryScheduleDao.RemoveLotterySchedule(lotterySchedule);
            return this.lotteryScheduleDao.InsertLotterySchedule(lotterySchedule);
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
            this.lotteryWinningBetDao.RemoveLotteryWinningBetByBetId(lotteryBet.GetId());
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
        public bool IsLotteryBetExist(LotteryBet lotteryBet)
        {
            return (lotteryBetDao.IsBetExisting(lotteryBet));
        }
        public void UpdateClaimStatus(LotteryWinningBet winBet)
        {
            lotteryWinningBetDao.UpdateClaimStatus(winBet);
        }
        public List<int> GetTopDrawnResultDigits()
        {
            return this.lotteryDrawResultDao.GetTopDrawnDigitResults(GameMode);
        }
        public List<int> GetTopDrawnPreviousSeasonDigitResults()
        {
            return this.lotteryDrawResultDao.GetTopDrawnPreviousSeasonDigitResults(GameMode);
        }
        public List<int> GetTopDrawnDigitFromJackpotsResults()
        {
            return this.lotteryDrawResultDao.GetTopDrawnDigitFromJackpotsResults(GameMode);
        }
        public List<int> GetTopDrawnDigitFromDateRange(DateTime dateFrom, DateTime dateTo)
        {
            return this.lotteryDrawResultDao.GetTopDrawnDigitFromDateRange(GameMode, dateFrom, dateTo);
        }
        public List<int[]> GetTopDrawnDigitToSequenceFromDateRange(DateTime dateFrom, DateTime dateTo)
        {
            return this.lotteryDrawResultDao.GetTopDrawnDigitToSequenceFromDateRange(GameMode, dateFrom, dateTo);
        }
        public List<LotteryBet> GetLotteryBetsCurrentSeason()
        {
            return this.lotteryBetDao.GetLotteryBetsCurrentSeason(GameMode);
        }
        public List<LotterySequenceGenerator> GetAllSequenceGenerators()
        {
            return lotterySeqGenDao.GetAllSeqGenerators();
        }
        public void UpdateDescriptionLotterySequenceGenerator(LotterySequenceGenerator updatedModel)
        {
            if (this.lotterySeqGenDao.IsDescriptionExisting(updatedModel.GetDescription()))
            {
                throw new Exception(ResourcesUtils.GetMessage("lott_seq_gen_msg1"));
            }
            this.lotterySeqGenDao.UpdateDescription(updatedModel);
        }
        public List<LotteryDrawResult> GetLatestLotteryResult(int howManyDraws)
        {
            return this.lotteryDrawResultDao.GetLatestLotteryResult(this.lotteryDetails.GameMode, howManyDraws);
        }
        public List<LotteryDrawResult> GetMachineLearningDataSetFastTree(GameMode gameMode, DateTime startingDate)
        {
            return this.lotteryDrawResultDao.GetMachineLearningDataSetFastTree(gameMode, startingDate);
        }
        public List<LotteryDrawResult> GetMachineLearningDataSetSDCA(GameMode gameMode, DateTime startingDate)
        {
            return this.lotteryDrawResultDao.GetMachineLearningDataSetSDCA(gameMode, startingDate);
        }
        public void UpdateLotteryOutletDescription(LotteryOutlet updatedModel)
        {
            this.lotteryOutletDao.UpdateDescription(updatedModel);
        }
        public void RemoveLotteryOutlet(LotteryOutlet removeModel)
        {
            if(removeModel.GetId() == ResourcesUtils.LotteryOutletDefaultCode)
            {
                throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_sett_val_lot_out_msg5"), removeModel.GetDescription()));
            }
            this.lotteryOutletDao.RemoveOutlet(removeModel);
        }
        public int AddLotteryOutlet(String outletDescription)
        {
            return this.lotteryOutletDao.InsertLotteryOutlet(outletDescription);
        }
        public LotteryWinningCombination GetLotteryWinningCombinations(GameMode gameMode)
        {
            return this.lotteryWinningCombinationDao.GetLotteryWinningCombination(gameMode);
        }
        public void SaveWinningCombination(LotteryWinningCombination lotteryUpdated)
        {
            this.lotteryWinningCombinationDao.RemoveWinningCombination(lotteryUpdated);
            this.lotteryWinningCombinationDao.InsertWinningCombination(lotteryUpdated);
        }
    }
}
