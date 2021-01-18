﻿using System;
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
            /*
                *** Connection Pooling ***
                All services(the default)
                OLE DB Services = -1;
                All services except pooling
                OLE DB Services = -2;
                All services except pooling and auto-enlistment
                OLE DB Services = -4;
                All services except client cursor
                OLE DB Services = -5;
                All services except client cursor and pooling
                OLE DB Services = -6;
                No services
                OLE DB Services = 0;
            */
            return new ConnectionDetails("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services = -1;Data Source=" + AppSettings.GetMsAccessDatabasePath);
        }
    }
}
