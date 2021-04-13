using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class UserSettingDaoImpl: UserSettingDao
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
                command.CommandText = "SELECT ID, config_name, value FROM user_setting WHERE config_name = 'last_opened_lottery'";
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
        public void SaveLastOpenedLottery(int game_cd)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE user_setting SET [value] = @value WHERE config_name='last_opened_lottery'";
                command.Parameters.AddWithValue("@value", game_cd);
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(ResourcesUtils.GetMessage("lot_dao_impl_msg13"));
                }
                transaction.Commit();
            }
        }
        public String GetMLDataSetDirectoryPath()
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, config_name, value FROM user_setting WHERE config_name = 'ml_data_set'";
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
        public void SaveMLDataSetDirectoryPath(String filePath)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE user_setting SET [value] = @value WHERE config_name='ml_data_set'";
                command.Parameters.AddWithValue("@value", filePath);
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(ResourcesUtils.GetMessage("lot_dao_impl_msg14"));
                }
                transaction.Commit();
            }
        }

    }
}
