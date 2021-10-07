using LottoDataManager.Includes.Classes.Generator;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Updates
{
    public class ApplicationUpdateProcessor
    {
        private static ApplicationUpdateProcessor updateProcessor;
        private AppVersioningDao appVersioningDaoObj;
        private LotteryDataServices lotteryDataServicesObj;
        public event EventHandler<String> PatchingProcessingLogs;

        private bool isUpdateFinish = false;
        private ApplicationUpdateProcessor() 
        {
            this.AppVersioningDaoObj = AppVersioningDaoImpl.GetInstance();
        }
        public static ApplicationUpdateProcessor GetInstance()
        {
            if (updateProcessor == null)
            {
                updateProcessor = new ApplicationUpdateProcessor();
            }
            return updateProcessor;
        }

        public void StartUpdate(LotteryDataServices lotteryDataServices)
        {
            this.LotteryDataServicesObj = lotteryDataServices;
            IsUpdateFinish = false;
            Task.Run(() =>
            {
                //updates should be in sequence. If not, might be mess up
                RaiseEvent(ResourcesUtils.GetMessage("app_ver_notify_0"));
                UpdateFor1006();
                UpdateFor1008();
                RaiseEvent(ResourcesUtils.GetMessage("app_ver_notify_2"));
                IsUpdateFinish = true;
            });
        }

        private void UpdateFor1006()
        {
            //version 1.0.6.r1 update
            AppVersioningSetup appVersion = new AppVersioningSetup()
            {
                Major = 1,
                Minor = 0,
                Patch = 0,
                ReleaseVersion = "6",
                DateTimeApplied = DateTime.Now,
                Remarks = ResourcesUtils.GetMessage("app_ver_1006_remarks")
            };
            AppVersioning appVersionInDB = AppVersioningDaoObj.GetVersion(appVersion);
            if (appVersionInDB == null)
            {
                RaiseNewEntryEvent(appVersion);
                LotterySequenceGeneratorSetup genModel = new LotterySequenceGeneratorSetup();
                genModel.SeqGenCode = (int) GeneratorType.LOTTO_MATCH_COUNT_PREDICTION_FAST_TREE_REGRESSION;
                genModel.Description = ResourcesUtils.GetMessage("app_ver_1006_pick_gen_desc");
                lotteryDataServicesObj.InsertLotterySequenceGenerator(genModel);
                AppVersioningDaoObj.InsertAppVersioning(appVersion);
            }
            else
            {
                RaiseSkippedVersionEvent(appVersion);
            }
        }

        private void UpdateFor1008()
        {
            //version 1.0.0.8 update
            AppVersioningSetup appVersion = new AppVersioningSetup()
            {
                Major = 1,
                Minor = 0,
                Patch = 0,
                ReleaseVersion = "8",
                DateTimeApplied = DateTime.Now,
                Remarks = ResourcesUtils.GetMessage("app_ver_1008_remarks")
            };
            AppVersioning appVersionInDB = AppVersioningDaoObj.GetVersion(appVersion);
            if (appVersionInDB == null)
            {
                RaiseNewEntryEvent(appVersion);
                LotterySequenceGeneratorSetup genModel = new LotterySequenceGeneratorSetup();
                genModel.SeqGenCode = (int)GeneratorType.DRAW_RESULT_WIN_COUNT_PREDICTION_FAST_TREE_REGRESSION;
                genModel.Description = ResourcesUtils.GetMessage("app_ver_1008_pick_gen_desc");
                lotteryDataServicesObj.InsertLotterySequenceGenerator(genModel);
                AppVersioningDaoObj.InsertAppVersioning(appVersion);
            }
            else
            {
                RaiseSkippedVersionEvent(appVersion);
            }
        }

        private void RaiseNewEntryEvent(AppVersioningSetup appVersion)
        {
            RaiseEvent(ResourcesUtils.GetMessage("app_ver_notify_1", appVersion.GetAppVersionLbl()));
        }
        private void RaiseSkippedVersionEvent(AppVersioningSetup appVersion)
        {
            RaiseEvent(ResourcesUtils.GetMessage("app_ver_notify_3", appVersion.GetAppVersionLbl()));
        }
        private void RaiseEvent(String processingMessage)
        {
            PatchingProcessingLogs.Invoke(this, processingMessage);
        }
        public bool IsFinishUpdating { get { return IsUpdateFinish; } }
        private AppVersioningDao AppVersioningDaoObj { get => appVersioningDaoObj; set => appVersioningDaoObj = value; }
        private LotteryDataServices LotteryDataServicesObj { get => lotteryDataServicesObj; set => lotteryDataServicesObj = value; }
        private bool IsUpdateFinish { get => isUpdateFinish; set => isUpdateFinish = value; }
    }
}
