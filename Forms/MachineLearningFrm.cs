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
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using LottoDataManagerML;

namespace LottoDataManager.Forms
{
    public partial class MachineLearningFrm : Form
    {
        private bool isUpdateProcessingStarted = false;
        private LotteryDataServices lotteryDataServices;

        public MachineLearningFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();

            //debugging
            lotteryDataServices = new LotteryDataServices(new Includes.Model.LotteryDetails(Includes.Model.Structs.GameMode.Mode_642));
            //debugging end

            this.lotteryDataServices = lotteryDataServices;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(!isUpdateProcessingStarted) this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsUpdateStarted(true);
            StartUpdate();
            IsUpdateStarted(false);
        }

        private void StartUpdate()
        {
            log("Getting data sets from the database.");
            String fileName = FileUtils.GetCSVTempFilePathName();

            log("Creating temporary data set file: " + fileName);
            using (FileStream fs = File.Create(fileName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("draw_date,num1,num2,num3,num4,num5,num6,game_cd,RESULT\r\n");
                fs.Write(info, 0, info.Length);

                foreach (Lottery lottery in this.lotteryDataServices.GetLotteries())
                {
                    log("Getting datasets for " + lottery.GetDescription());

                    DateTime startingDateTime = DateTimeConverterUtils.GetYear2011();
                    while (true)
                    {
                        List<LotteryDrawResult> lotteryDrawResults = lotteryDataServices.GetMachineLearningDataSet(lottery.GetGameMode(), startingDateTime);
                        if (lotteryDrawResults.Count > 0) log("Processing record count of: " + lotteryDrawResults.Count);

                        int ctrEvent = 0;
                        foreach (LotteryDrawResult result in lotteryDrawResults)
                        {
                            String content = result.GetMachineLearningDataSetEntry() + "\r\n";
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
                    log("Done writing datasets ");
                    log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    fs.Flush();
                }
            }
            try
            {
                log("Feeding data sets to Machine Learning Trainer...");
                ModelBuilder.CreateModel(fileName);
                log("Deleting data sets >>> " + fileName);
                if (fileName.Contains(FileUtils.TEMP_FILE_MARKED)) File.Delete(fileName);
                log("Completed successfully....");
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
