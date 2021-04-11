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


            //DEBUGGING
            for(int x=3;x<=60; x++)
            {
                Console.WriteLine(String.Format("lott_app_config_msg{0}=", x));
            }
            //DEBUGGING END


            SplashScreenFrm splash = SplashScreenFrm.GetIntance();
            splash.Show();
            if(splash.DialogResult == DialogResult.Abort)
            {
                Application.ExitThread();
            }
            else
            {
                Application.Run(new MainForm());
                //Application.Run(new ModifyBetFrm(null));
                //Application.Run(new AddBetFrm());
                //Application.Run(new DrawAndBetMatchFrm(null, DateTime.Now));
                //Application.Run(new ModifyClaimsFrm(null));
                //Application.Run(new PickGeneratorFrm(null));
                //Application.Run(new AboutFrm());
                //Application.Run(new SplashScreenFrm());
                //Application.Run(new MachineLearningFrm(null));
                //Application.Run(new LotterySettingsFrm(null));
                //Application.Run(new ModifyBetDateFrm(null));
                //splash.DisposeInstance();
                //Application.Run(new ProfitAndLossFrm(null));
            }
        }
    }
}
