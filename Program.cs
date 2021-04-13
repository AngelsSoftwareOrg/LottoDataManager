using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Forms;
using LottoDataManager.Forms.Reports;

namespace LottoDataManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreenFrm splash = SplashScreenFrm.GetIntance();
            splash.Show();
            if(splash.DialogResult == DialogResult.Abort)
            {
                Application.ExitThread();
            }
            else
            {
                Application.Run(new MainForm());
                //splash.DisposeInstance();
                //Application.Run(new ProfitAndLossFrm(null));
                //Application.Run(new ProcessingStatusLogFrm());
            }
        }
    }
}
