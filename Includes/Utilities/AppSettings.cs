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

        public static DatabaseType GetDatabaseType()
        {
            String db = Properties.Settings.Default.db_type;
            
            if(db.Equals("MSACCESS",StringComparison.OrdinalIgnoreCase))
            {
                return DatabaseType.MS_ACCESS;
            }
            return DatabaseType.MS_ACCESS;
        }


    }
}
