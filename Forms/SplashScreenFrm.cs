using LottoDataManager.Includes;
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
    public partial class SplashScreenFrm : Form
    {
        private static SplashScreenFrm splashScreenFrm;

        public SplashScreenFrm()
        {
            InitializeComponent();
        }

        public static SplashScreenFrm GetIntance()
        {
            if (splashScreenFrm == null) splashScreenFrm = new SplashScreenFrm();
            return splashScreenFrm;
        }
        public void DisposeInstance()
        {
            System.Threading.Thread.Sleep(1000);
            Hide();
            if (splashScreenFrm != null) splashScreenFrm.Dispose(true);
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "v" + AppSettings.GetAppVersion();
        }
    }
}
