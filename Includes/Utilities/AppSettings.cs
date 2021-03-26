using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.Engine;

namespace LottoDataManager.Includes
{
    public class AppSettings
    {
        public static String GetMsAccessDatabasePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.." + Properties.Settings.Default.msaccess_datasource_path);
            }
        }

        public static String GetLootoScrapeSite
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

    }
}
