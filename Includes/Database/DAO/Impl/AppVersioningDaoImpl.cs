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
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class AppVersioningDaoImpl: LotteryDaoImplCommon, AppVersioningDao
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
        public AppVersioning GetVersion(AppVersioning appVersion)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT * " +
                                      "   FROM `app_versioning`  " +
                                      "  WHERE major = @major " +
                                      "    AND minor = @minor " +
                                      "    AND patch = @patch " +
                                      "    AND `releaseversion` = @rversion ";
                command.Parameters.AddWithValue("@major", appVersion.GetMajor());
                command.Parameters.AddWithValue("@minor", appVersion.GetMinor());
                command.Parameters.AddWithValue("@patch", appVersion.GetPatch());
                command.Parameters.AddWithValue("@rversion", appVersion.GetReleaseCycle());
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
        public int InsertAppVersioning(AppVersioning appVersion)
        {
            int modified = 0;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO `app_versioning` " + 
                                      " (`major`, `minor`, `patch`, `releaseversion`, `remarks`, `datetimeapplied`) " +
                                      " VALUES(@major, @minor, @patch, @releaseversion, @remarks, @datetimeapplied); ";
                command.Connection = conn;
                command.Parameters.AddWithValue("@major", appVersion.GetMajor());
                command.Parameters.AddWithValue("@minor", appVersion.GetMinor());
                command.Parameters.AddWithValue("@patch", appVersion.GetPatch());
                command.Parameters.AddWithValue("@releaseversion", appVersion.GetReleaseCycle());
                command.Parameters.AddWithValue("@remarks", appVersion.GetRemarks());
                command.Parameters.AddWithValue("@datetimeapplied", appVersion.GetDateTimeApplied().ToString());
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(ResourcesUtils.GetMessage("lot_dao_impl_msg14"));
                }
                else
                {
                    transaction.Commit();
                    modified = base.GetLastInsertedID(command);
                }
            }
            return modified;
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
