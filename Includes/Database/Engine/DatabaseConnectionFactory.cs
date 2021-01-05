using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Database
{
    public class DatabaseConnectionFactory
    {
        public static OleDbConnection GetDataSource()
        {
            ConnectionDetails connDetails = GetConnectionDetails();
            OleDbConnection conn = new OleDbConnection(connDetails.ConnectionString);
            return conn;
        }
        private static ConnectionDetails GetConnectionDetails()
        {
            if(AppSettings.GetDatabaseType() == Engine.DatabaseType.MS_ACCESS)
            {
                return GetMsAccessConnDetails();
            }
            return GetMsAccessConnDetails();
        }
        private static ConnectionDetails GetMsAccessConnDetails()
        {
            return new ConnectionDetails("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppSettings.GetMsAccessDatabasePath);
        }
    }
}
