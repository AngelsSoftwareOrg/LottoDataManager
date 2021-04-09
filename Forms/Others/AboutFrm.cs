using LottoDataManager.Includes;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoDataManager.Forms
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutFrm_Load(object sender, EventArgs e)
        {
            txtAboutCnt.AppendText("\r\n");
            txtAboutCnt.AppendText(ResourcesUtils.GetMessage("about_title"));
            txtAboutCnt.AppendText("\r\n\r\n");
            txtAboutCnt.AppendText(ResourcesUtils.GetMessage("about_author"));
            txtAboutCnt.AppendText("\r\n\r\n");
            txtAboutCnt.AppendText(ResourcesUtils.GetMessage("about_email"));
            txtAboutCnt.AppendText("\r\n\r\n");
            txtAboutCnt.AppendText(ResourcesUtils.GetMessage("about_github_title"));
            txtAboutCnt.AppendText("\r\n");
            txtAboutCnt.AppendText(ResourcesUtils.GetMessage("about_github_proj_link"));
            txtAboutCnt.AppendText("\r\n\r\n");
            txtAboutCnt.AppendText(ResourcesUtils.GetMessage("about_proj_version"));
            txtAboutCnt.AppendText("   ");
            txtAboutCnt.AppendText(AppSettings.GetAppVersion());
            txtAboutCnt.AppendText("\r\n\r\n");
        }
    }
}
