using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class AppVersioningDaoImpl: AppVersioningDao
    {
        private static AppVersioningDaoImpl appVersioningDaoImpl;
        private AppVersioningDaoImpl() { }
        public static AppVersioningDao GetInstance()
        {
            if (appVersioningDaoImpl == null)
            {
                appVersioningDaoImpl = new AppVersioningDaoImpl();
            }
            return appVersioningDaoImpl;
        }
        public AppVersioning GetLatestVersion()
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT TOP 1 * FROM `app_versioning` ORDER BY `datetimeapplied` DESC ";
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return GetModel(reader);
                    }
                }
            }
            return null;
        }
        private AppVersioning GetModel(OleDbDataReader reader)
        {
            AppVersioningSetup v = new AppVersioningSetup();
            v.ID = int.Parse(reader["ID"].ToString());
            v.Major = int.Parse(reader["major"].ToString());
            v.Minor = int.Parse(reader["minor"].ToString());
            v.Patch = int.Parse(reader["patch"].ToString());
            v.ReleaseVersion = reader["releaseversion"].ToString();
            v.DateTimeApplied = DateTime.Parse(reader["datetimeapplied"].ToString());
            v.Remarks = reader["remarks"].ToString();
            return v;
        }
    }
}
