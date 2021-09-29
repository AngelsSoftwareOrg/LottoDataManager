using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details.Options;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class UserSettingDaoImpl : LotteryDaoImplCommon, UserSettingDao
    {
        private static UserSettingDaoImpl userSettingDaoImpl;
        private UserSettingDaoImpl() { }
        public static UserSettingDao GetInstance()
        {
            if (userSettingDaoImpl == null)
            {
                userSettingDaoImpl = new UserSettingDaoImpl();
            }
            return userSettingDaoImpl;
        }
        public int GetLastOpenedLottery()
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, config_name, value FROM user_setting WHERE config_name = @last_opened_lottery";
                command.Parameters.AddWithValue("@last_opened_lottery", UserSettingsConfig.CFG_LAST_OPENED_DIRECTORY);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return int.Parse(reader["value"].ToString());
                        }
                    }
                }
            }
            return -1;
        }
        public void UpdateSetting(String configName, String value)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE user_setting SET [value] = @value WHERE config_name = @configName";
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@configName", configName);
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("user_sett_dao_impl_msg1"), configName));
                }
                transaction.Commit();
            }
        }
        public String GetSetting(String configName)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, config_name, value FROM user_setting WHERE config_name = @configName";
                command.Parameters.AddWithValue("@configName", configName);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return reader["value"].ToString();
                        }
                    }
                }
            }
            return null;
        }
        public int InsertSetting(String configName, String value)
        {
            int lastInsertID = 0;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO user_setting (config_name, `value`) VALUES (@configName, @value) ";
                command.Parameters.AddWithValue("@configName", configName);
                command.Parameters.AddWithValue("@value", value);
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("user_sett_dao_impl_msg2"), configName, value));
                }
                else
                {
                    transaction.Commit();
                    lastInsertID = base.GetLastInsertedID(command);
                }
            }
            return lastInsertID;
        }
        public void SaveLastOpenedLottery(int game_cd)
        {
            UpdateSetting(UserSettingsConfig.CFG_LAST_OPENED_DIRECTORY, game_cd.ToString());
        }
        public String GetMLDataSetDirectoryPath()
        {
            return GetSetting(UserSettingsConfig.CFG_ML_DATA_SET);
        }
        public void SaveMLDataSetDirectoryPath(String filePath)
        {
            UpdateSetting(UserSettingsConfig.CFG_ML_DATA_SET, filePath);
        }
    }
}
