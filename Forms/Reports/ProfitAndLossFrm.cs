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
using LottoDataManager.Includes.Classes.Reports;
using LottoDataManager.Includes.Classes.Reports.Templates;
using LottoDataManager.Includes.Classes.Reports.Templates.Fragments;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms.Reports
{
    public partial class ProfitAndLossFrm : Form
    {
        private LotteryDataServices lotteryDataServices;

        public ProfitAndLossFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;

            //Debugging
            if(lotteryDataServices==null) this.lotteryDataServices = new LotteryDataServices(new Game642());
            //End Debugging

        }

        #region Main Form
        private void ProfitAndLossFrm_Load(object sender, EventArgs e)
        {
            FormSetup();
        }
        #endregion

        #region Forms Initialization
        private void FormSetup()
        {
            btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
            btnRunReport.Text = ResourcesUtils.GetMessage("pal_form_labels_run");
            this.Text = ResourcesUtils.GetMessage("pal_form_labels_title");
        }
        #endregion

        #region Generates Report
        private void RunReport()
        {
            String fileName = FileUtils.GetHtmlTempFilePathName();

            //debugging
            Console.WriteLine(fileName);
            List<int> gameList = new List<int>();
            gameList.Add(1);
            //gameList.Add(2);
            //gameList.Add(3);
            //gameList.Add(4);
            //gameList.Add(5);
            //end

            ProfitAndLossReport profitAndLossReport = new ProfitAndLossReport(gameList);
            IndividualGameHtmlReport htmlReport = new IndividualGameHtmlReport();
            htmlReport.ProfitAndLossReport = profitAndLossReport;
            String content = htmlReport.TransformText();

            using (FileStream fs = File.Create(fileName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
                fs.Flush();
            }
            System.Diagnostics.Process.Start(fileName);
        }


        #endregion

        #region Buttons
            private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRunReport_Click(object sender, EventArgs e)
        {
            RunReport();
        }
        #endregion

    }
}
