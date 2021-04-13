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
        public List<LotteryDrawResult> GetLotteryDrawResults(DateTime startingDate)
        {
            if (startingDate >= DateTime.Now) throw new Exception(ResourcesUtils.GetMessage("lot_data_srv_cls_msg_1"));
            return lotteryDrawResultDao.GetDrawResultsFromStartingDate(GameMode, startingDate);
        }
        public LotteryDrawResult GetLotteryDrawResultByDrawDate(DateTime drawDate)
        {
            return lotteryDrawResultDao.GetLotteryDrawResultByDrawDate(GameMode, drawDate);
        }
        public List<LotteryBet> GetLottoBets(DateTime sinceWhen)
        {
            if (sinceWhen >= DateTime.Now) throw new Exception(ResourcesUtils.GetMessage("lot_data_srv_cls_msg_2"));
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
            this.userSetting.SaveLastOpenedLottery(this.lotteryDetails.GameCode);
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
