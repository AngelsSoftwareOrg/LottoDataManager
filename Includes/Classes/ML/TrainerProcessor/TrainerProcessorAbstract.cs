using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.TrainerProcessor
{
    public abstract class TrainerProcessorAbstract
    {
        private String dataTableHeaders;
        private LotteryDataServices lotteryDataServices;
        public event EventHandler<String> TrainerProcessorProcessingStatus;

        protected TrainerProcessorAbstract(String dataTableHeaders)
        {
            this.dataTableHeaders = dataTableHeaders;
        }

        protected void CommonTrainerInstanceEvent_ProcessingStatus(object sender, string e)
        {
            InvokeTrainerProcessorProcessingStatus(sender, e);
        }
        protected void InvokeTrainerProcessorProcessingStatus(object sender, String statusMessage)
        {
            if (TrainerProcessorProcessingStatus == null) return;
            TrainerProcessorProcessingStatus.Invoke(sender, statusMessage);
        }
        protected void log(String statusMessage)
        {
            InvokeTrainerProcessorProcessingStatus(this, statusMessage);
        }
        public abstract void StartUpdate();
        protected abstract List<Object> GetTrainerDataSets(TrainerDataIntakeModel trainerDataIntakeModel);
        protected abstract void CreateTrainerModel(String fileName);
        protected abstract String GetDataSetEntry(Object lotteryModel);
        protected abstract DateTime GetDrawDateEquivalent(Object lotteryObject);

        protected void CommonTrainerModelDrawResults()
        {
            //if (!isUpdateProcessingStarted) return;

            log(ResourcesUtils.GetMessage("mac_lrn_log_1"));
            String fileName = FileUtils.GetCSVTempFilePathName();
            TrainerDataIntakeModel intakeModel = new TrainerDataIntakeModel();
            
            log(ResourcesUtils.GetMessage("mac_lrn_log_2") + fileName + "\r\n");
            using (FileStream fs = File.Create(fileName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(DataTableHeader);
                fs.Write(info, 0, info.Length);

                foreach (Lottery lottery in this.lotteryDataServices.GetLotteries())
                {
                    log(ResourcesUtils.GetMessage("mac_lrn_log_3") + lottery.GetDescription());

                    DateTime startingDateTime = DateTimeConverterUtils.GetYear2011();
                    while (true)
                    {
                        intakeModel.GameMode = lottery.GetGameMode();
                        intakeModel.StartingDateTime = startingDateTime;

                        List<Object> lotteryObjResults = GetTrainerDataSets(intakeModel);
                        if (lotteryObjResults.Count > 0) log(ResourcesUtils.GetMessage("mac_lrn_log_4") + lotteryObjResults.Count);

                        foreach (Object result in lotteryObjResults)
                        {
                            String content = GetDataSetEntry(result) + "\r\n";
                            fs.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
                            if (startingDateTime.CompareTo(GetDrawDateEquivalent(result)) < 0)
                            {
                                startingDateTime = GetDrawDateEquivalent(result);
                            }
                            //if (!isUpdateProcessingStarted) break;
                        }

                        if (lotteryObjResults.Count <= 0) break;
                        //if (!isUpdateProcessingStarted) break;
                    }
                    log(ResourcesUtils.GetMessage("mac_lrn_log_5"));
                    log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                    fs.Flush();
                }
            }
            CreateTrainerModel(fileName);
        }
        protected void CommonCreateTrainerModel(MLModelBuilderAbstract modelBuilderAbstract, String fileName)
        {
            try
            {
                //if (!isUpdateProcessingStarted) return;
                log(ResourcesUtils.GetMessage("mac_lrn_log_7") + "\r\n\r\n");
                modelBuilderAbstract.CreateModel(fileName);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_8") + fileName + "\r\n\r\n");
                if (fileName.Contains(FileUtils.TEMP_FILE_MARKED)) File.Delete(fileName);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_9") + "\r\n\r\n");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public String DataTableHeader
        {
            get { return this.dataTableHeaders;  }
        }
        protected LotteryDataServices LotteryDataServices { get => lotteryDataServices; set => lotteryDataServices = value; }
    }
}
