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
using LottoDataManager.Includes.Classes.ML.FastTreeRegression.LottoMatchCount;
using LottoDataManager.Includes.Classes.ML.SDCARegression;
using LottoDataManager.Includes.Classes.ML.TrainerProcessor;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class MachineLearningFrm : Form
    {
        private delegate void SetTextCallback(string text);
        private delegate void SetFormsAvailabilityOnRun(Boolean isUpdateStarted = false);
        private delegate void StopRun();
        private bool isUpdateProcessingStarted = false;
        private LotteryDataServices lotteryDataServices;
        private FastTreeTrainer machineLearningModelBuilderFastTree;
        private SDCARegressionTrainer machineLearningModelBuilderSDCARegression;
        private List<TrainerProcessorAbstract> trainerProcessorAbstractList;

        public MachineLearningFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();

            this.lotteryDataServices = lotteryDataServices;
            this.machineLearningModelBuilderFastTree = new FastTreeTrainer();
            this.machineLearningModelBuilderSDCARegression = new SDCARegressionTrainer();
            this.trainerProcessorAbstractList = new List<TrainerProcessorAbstract>();

            trainerProcessorAbstractList.Add(new FastTreeTrainerDataIntake(this.lotteryDataServices));
            trainerProcessorAbstractList.Add(new SDCARegressionTrainerDataIntake(this.lotteryDataServices));
            trainerProcessorAbstractList.Add(new LottoMatchCountTrainerDataIntake(this.lotteryDataServices));

            machineLearningModelBuilderFastTree.ProcessingStatus += MachineLearningModelBuilder_ProcessingStatus;
            machineLearningModelBuilderSDCARegression.ProcessingStatus += MachineLearningModelBuilder_ProcessingStatus;
            log(ResourcesUtils.GetMessage("mac_lrn_log_13"));
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
            txtStatus.Text = "";
            StartUpdate();
        }
        internal async void StartUpdate()
        {
            await Task.Run(() =>
            {
                IsUpdateStarted(true);
                log(ResourcesUtils.GetMessage("mac_lrn_log_6"));
                log(ResourcesUtils.GetMessage("mac_lrn_log_11"));
                foreach(TrainerProcessorAbstract trainer in trainerProcessorAbstractList)
                {
                    if (IsProcessingStop()) break; ;
                    trainer.TrainerProcessorProcessingStatus += Trainer_TrainerProcessorProcessingStatus; //bind
                    trainer.StartUpdate();
                    trainer.TrainerProcessorProcessingStatus -= Trainer_TrainerProcessorProcessingStatus; //unbind
                }
                
                if (!isUpdateProcessingStarted) log(ResourcesUtils.GetMessage("mac_lrn_log_14"));
                IsUpdateStarted(false);
            });
        }

        private void Trainer_TrainerProcessorProcessingStatus(object sender, string e)
        {
            log(e);
        }

        private bool IsProcessingStop()
        {
            if (!isUpdateProcessingStarted)
            {
                IsUpdateStarted(false);
                return true; ;
            }
            return false;
        }

        private void log(String msg)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(log);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                txtStatus.AppendText("\r\n" + msg);
            }
        }
        private void IsUpdateStarted(bool isUpdateStarted = false)
        {
            if (this.btnStop.InvokeRequired)
            {
                SetFormsAvailabilityOnRun d = new SetFormsAvailabilityOnRun(IsUpdateStarted);
                this.Invoke(d, new object[] { isUpdateStarted });
                return;
            }

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
            StopRunNow();
        }
        private void StopRunNow()
        {
            if (this.btnStop.InvokeRequired)
            {
                StopRun d = new StopRun(StopRunNow);
                this.Invoke(d, new object[] { });
                return;
            }
            isUpdateProcessingStarted = false;
        }
    }
}
