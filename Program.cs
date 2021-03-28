using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Forms;

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

            SplashScreenFrm.GetIntance().Show();
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
        }
    }
}
