using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Classes.ML;
using LottoDataManager.Includes.Classes.ML.FastTree;
using LottoDataManager.Includes.Classes.ML.SDCARegression;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using LottoDataManagerML;

namespace LottoDataManager.Forms
{
    public partial class MachineLearningFrm : Form
    {
        private bool isUpdateProcessingStarted = false;
        private LotteryDataServices lotteryDataServices;
        private MachineLearningModelBuilderFastTree machineLearningModelBuilderFastTree;
        private MachineLearningModelBuilderSDCARegression machineLearningModelBuilderSDCARegression;
        public MachineLearningFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;
            this.machineLearningModelBuilderFastTree = new MachineLearningModelBuilderFastTree();
            machineLearningModelBuilderSDCARegression = new MachineLearningModelBuilderSDCARegression();
            machineLearningModelBuilderFastTree.ProcessingStatus += MachineLearningModelBuilder_ProcessingStatus;
            machineLearningModelBuilderSDCARegression.ProcessingStatus += MachineLearningModelBuilder_ProcessingStatus;
        }
        private void MachineLearningModelBuilder_ProcessingStatus(object sender, string e)
        {
            log(e);
            Application.DoEvents();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(!isUpdateProcessingStarted) this.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsUpdateStarted(true);
            txtStatus.Text = "";
            StartUpdate();
            IsUpdateStarted(false);
        }
        private void StartUpdate()
        {
            log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
            log(ResourcesUtils.GetMessage("mac_lrn_log_11"));
            ConsumeFastTreeTrainerModel();
            log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
            log(ResourcesUtils.GetMessage("mac_lrn_log_12"));
            ConsumeSDCATrainerModel();
            log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
        }
        private void ConsumeFastTreeTrainerModel()
        {
            log(ResourcesUtils.GetMessage("mac_lrn_log_1"));
            String fileName = FileUtils.GetCSVTempFilePathName();

            log(ResourcesUtils.GetMessage("mac_lrn_log_2") + fileName  + "\r\n");
            using (FileStream fs = File.Create(fileName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("draw_date,num1,num2,num3,num4,num5,num6,game_cd,RESULT\r\n");
                fs.Write(info, 0, info.Length);

                foreach (Lottery lottery in this.lotteryDataServices.GetLotteries())
                {
                    log(ResourcesUtils.GetMessage("mac_lrn_log_3") + lottery.GetDescription());

                    DateTime startingDateTime = DateTimeConverterUtils.GetYear2011();
                    while (true)
                    {
                        List<LotteryDrawResult> lotteryDrawResults = lotteryDataServices.GetMachineLearningDataSetFastTree(lottery.GetGameMode(), startingDateTime);
                        if (lotteryDrawResults.Count > 0) log(ResourcesUtils.GetMessage("mac_lrn_log_4") + lotteryDrawResults.Count);

                        int ctrEvent = 0;
                        foreach (LotteryDrawResult result in lotteryDrawResults)
                        {
                            String content = result.GetMachineLearningDataSetEntryFastTree() + "\r\n";
                            fs.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
                            if (startingDateTime.CompareTo(result.GetDrawDate()) <0) 
                            {
                                startingDateTime = result.GetDrawDate();
                            }
                            //log("Adding >>> " + result.GetMachineLearningDataSetEntry());
                            if (ctrEvent++%500 ==0) Application.DoEvents();
                            if (!isUpdateProcessingStarted) break;
                        }

                        if (lotteryDrawResults.Count <= 0) break;
                        Application.DoEvents();
                        if (!isUpdateProcessingStarted) break;
                    }
                    log(ResourcesUtils.GetMessage("mac_lrn_log_5"));
                    log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                    fs.Flush();
                }
            }
            try
            {
                log(ResourcesUtils.GetMessage("mac_lrn_log_7") + "\r\n\r\n");
                machineLearningModelBuilderFastTree.CreateModel(fileName);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_8") + fileName + "\r\n\r\n");
                if (fileName.Contains(FileUtils.TEMP_FILE_MARKED)) File.Delete(fileName);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_9") + "\r\n\r\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                log(e.StackTrace);
            }
        }
        private void ConsumeSDCATrainerModel()
        {
            log(ResourcesUtils.GetMessage("mac_lrn_log_1"));
            String fileName = FileUtils.GetCSVTempFilePathName();

            log(ResourcesUtils.GetMessage("mac_lrn_log_2") + fileName + "\r\n");
            using (FileStream fs = File.Create(fileName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("draw_date,num1,num2,num3,num4,num5,num6,PREDICT,winners,game_cd\r\n");
                fs.Write(info, 0, info.Length);

                foreach (Lottery lottery in this.lotteryDataServices.GetLotteries())
                {
                    log(ResourcesUtils.GetMessage("mac_lrn_log_3") + lottery.GetDescription());

                    DateTime startingDateTime = DateTimeConverterUtils.GetYear2011();
                    while (true)
                    {
                        List<LotteryDrawResult> lotteryDrawResults = lotteryDataServices.GetMachineLearningDataSetSDCA(lottery.GetGameMode(), startingDateTime);
                        if (lotteryDrawResults.Count > 0) log(ResourcesUtils.GetMessage("mac_lrn_log_4") + lotteryDrawResults.Count);

                        int ctrEvent = 0;
                        foreach (LotteryDrawResult result in lotteryDrawResults)
                        {
                            String content = result.GetMachineLearningDataSetEntrySDCA() + "\r\n";
                            fs.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
                            if (startingDateTime.CompareTo(result.GetDrawDate()) < 0)
                            {
                                startingDateTime = result.GetDrawDate();
                            }
                            //log("Adding >>> " + result.GetMachineLearningDataSetEntry());
                            if (ctrEvent++ % 500 == 0) Application.DoEvents();
                            if (!isUpdateProcessingStarted) break;
                        }

                        if (lotteryDrawResults.Count <= 0) break;
                        Application.DoEvents();
                        if (!isUpdateProcessingStarted) break;
                    }
                    log(ResourcesUtils.GetMessage("mac_lrn_log_5"));
                    log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                    fs.Flush();
                }
            }
            try
            {
                log(ResourcesUtils.GetMessage("mac_lrn_log_7") + "\r\n\r\n");
                machineLearningModelBuilderSDCARegression.CreateModel(fileName);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_8") + fileName + "\r\n\r\n");
                if (fileName.Contains(FileUtils.TEMP_FILE_MARKED)) File.Delete(fileName);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_9") + "\r\n\r\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                log(e.StackTrace);
            }
        }
        private void log(String msg)
        {
            txtStatus.AppendText("\r\n" + msg);
        }
        private void IsUpdateStarted(bool isUpdateStarted = false)
        {
            if (isUpdateStarted)
            {
                btnExit.Visible = false;
                btnUpdate.Visible = false;
                btnStop.Visible = true;
                isUpdateProcessingStarted = true;
            }
            else
            {
                btnExit.Visible = true;
                btnUpdate.Visible = true;
                btnStop.Visible = false;
                isUpdateProcessingStarted = false;
            }
            Application.DoEvents();
        }
        private void MachineLearningFrm_Load(object sender, EventArgs e)
        {
            IsUpdateStarted(false);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            IsUpdateStarted(false);
        }
    }
}
