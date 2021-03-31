using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Database.Engine;

namespace LottoDataManager.Includes
{
    public class AppSettings
    {
        public static String GetMsAccessDatabasePath
        {
            get
            {
                LotteryAppConfiguration lotteryAppConfiguration = LotteryAppConfiguration.GetInstance();
                if (String.IsNullOrEmpty(lotteryAppConfiguration.DBSourcePath) || !File.Exists(lotteryAppConfiguration.DBSourcePath))
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.." + Properties.Settings.Default.msaccess_datasource_path);
                }
                return lotteryAppConfiguration.DBSourcePath;
            }
        }
        public static String GetMLModelSourcePath()
        {
            LotteryAppConfiguration lotteryAppConfiguration = LotteryAppConfiguration.GetInstance();
            if (String.IsNullOrEmpty(lotteryAppConfiguration.MLModelPath) || !Directory.Exists(lotteryAppConfiguration.MLModelPath))
            {
                throw new Exception(String.Format("ML Model source path does not exist -> {0}", lotteryAppConfiguration.MLModelPath));
            }
            return lotteryAppConfiguration.MLModelPath;
        }
        public static String GetLottoScrapeSite
        {
            get
            {
                return Properties.Settings.Default.lotto_scrape_site;
            }
        }

        public static DatabaseType GetDatabaseType()
        {
            String db = Properties.Settings.Default.db_type;
            
            if(db.Equals("MSACCESS",StringComparison.OrdinalIgnoreCase))
            {
                return DatabaseType.MS_ACCESS;
            }
            return DatabaseType.MS_ACCESS;
        }

        public static String GetAppVersion()
        {
            return String.Format("{0}.{1}.{2}.{3}",
                Properties.Settings.Default.version_major,
                Properties.Settings.Default.version_minor,
                Properties.Settings.Default.version_patch,
                Properties.Settings.Default.version_release);
        }
        public static String GetAppVersionWithPrefix()
        {
            return String.Format("v{0}", GetAppVersion());
        }

    }
}
