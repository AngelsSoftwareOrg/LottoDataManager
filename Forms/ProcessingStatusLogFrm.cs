using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class ProcessingStatusLogFrm : Form
    {
        private readonly int PROCESS_LOGS_MAXIMUM_LINE_CONTENT = ResourcesUtils.ProcessLogsMaximumLineContent;

        public ProcessingStatusLogFrm()
        {
            InitializeComponent();
            ClearLogs();
            FormSetup();
        }

        #region Forms
        private void FormSetup()
        {
            this.Text = ResourcesUtils.GetMessage("procs_stat_log_frm_msg_1");
            this.btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
            this.btnClear.Text = ResourcesUtils.GetMessage("common_btn_clear");
        }
        #endregion

        #region Logging Functions
        
        public void AddStatusLogs(String moduleName, String logs)
        {
            AddRichtextMessage(DateTimeConverterUtils.GetDateTimeNowStandardFormat() + " : ", Color.Yellow);
            AddRichtextMessage(moduleName + " : ", Color.LightBlue);
            AddRichtextMessage(logs, Color.White);
            richtbLogs.AppendText(Environment.NewLine);
            MaintainStatusLogsContent();
        }
        private void AddRichtextMessage(String message, Color color)
        {
            richtbLogs.SelectionStart = richtbLogs.TextLength;
            richtbLogs.SelectionLength = 0;
            richtbLogs.SelectionColor = color;
            richtbLogs.AppendText(message);
            richtbLogs.SelectionColor = richtbLogs.ForeColor;
            richtbLogs.ScrollToCaret();
            richtbLogs.Refresh();
        }
        public void ClearLogs()
        {
            richtbLogs.Clear();
        }
        private void MaintainStatusLogsContent()
        {
            int logsLength = richtbLogs.Lines.Length;

            //if the content of the process log reaches the maximum content limit, remove the first line
            if(logsLength > PROCESS_LOGS_MAXIMUM_LINE_CONTENT)
            {
                //this clearing implementation or below
                richtbLogs.Select(0, richtbLogs.GetFirstCharIndexFromLine(logsLength - PROCESS_LOGS_MAXIMUM_LINE_CONTENT));  // Give your line number

                //or this implementation
                //richtbLogs.SelectionStart = 0;
                //richtbLogs.SelectionLength = richtbLogs.Text.IndexOf("\n", 0) + 1;

                richtbLogs.ReadOnly = false;
                richtbLogs.SelectedText = "";
                richtbLogs.ReadOnly = true;
            }
        }
        #endregion

        #region Buttons
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearLogs();
        }
        #endregion
    }
}
