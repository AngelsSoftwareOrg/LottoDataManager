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
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class LotteryOutletDaoImpl: LotteryDaoImplCommon, LotteryOutletDao
    {
        public static int MAX_LEN_DESCRIPTION = 255;

        private static LotteryOutletDaoImpl lotteryOutletDaoImpl;
        private LotteryOutletDaoImpl() { }
        public static LotteryOutletDao GetInstance()
        {
            if (lotteryOutletDaoImpl == null)
            {
                lotteryOutletDaoImpl = new LotteryOutletDaoImpl();
            }
            return lotteryOutletDaoImpl;
        }
        public List<LotteryOutlet> GetLotteryOutlets()
        {
            List<LotteryOutlet> lotteryOutletArr = new List<LotteryOutlet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM lottery_outlet WHERE active = true";
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryOutletArr.Add(CreateModel(reader));
                    }
                }
            }
            return lotteryOutletArr;
        }
        public void UpdateDescription(LotteryOutlet updatedModel)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_outlet SET description = @description " +
                                      " WHERE ID = @id AND outlet_cd = @outlet_cd AND active = true";
                command.Parameters.AddWithValue("@description", StringUtils.Truncate(updatedModel.GetDescription(), MAX_LEN_DESCRIPTION));
                command.Parameters.AddWithValue("@id", updatedModel.GetId());
                command.Parameters.AddWithValue("@outlet_cd", updatedModel.GetOutletCode());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg2"),  updatedModel.GetDescription()));
                }
                transaction.Commit();
            }
        }
        public bool IsLotteryOutletUsed(int outletCd)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT count(ID) AS [total] FROM lottery_bet " +
                                      " WHERE outlet_cd = @outlet_cd " +
                                      "   AND active = true ";
                command.Parameters.AddWithValue("@outlet_cd", outletCd);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int total = int.Parse(reader["total"].ToString());
                            return (total > 0);
                        }
                    }
                }
            }
            return false;
        }
        public void RemoveOutlet(LotteryOutlet modelToRemove)
        {
            if (IsLotteryOutletUsed(modelToRemove.GetOutletCode()))
            {
                throw new Exception(ResourcesUtils.GetMessage("lot_dao_impl_msg1"));
            }
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_outlet SET active = false " +
                                      "  WHERE ID = @id AND outlet_cd = @outlet_cd " +
                                      "    AND description = @outlet_desc AND active = true ";
                command.Parameters.AddWithValue("@id", modelToRemove.GetId());
                command.Parameters.AddWithValue("@outlet_cd", modelToRemove.GetOutletCode());
                command.Parameters.AddWithValue("@outlet_desc", modelToRemove.GetDescription());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg2"), modelToRemove.GetDescription()));
                }
                transaction.Commit();
            }
        }
        public bool IsDescriptionExisting(String outletDescription)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT count(ID) AS [total] FROM lottery_outlet " +
                                      " WHERE description = @outletDescription " +
                                      "   AND active = true ";
                command.Parameters.AddWithValue("@outletDescription", outletDescription);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int total = int.Parse(reader["total"].ToString());
                            return (total > 0);
                        }
                    }
                }
            }
            return false;
        }
        public int InsertLotteryOutlet(String outletDescription)
        {
            if (IsDescriptionExisting(outletDescription.Trim()))
            {
                throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg4"), outletDescription));
            }

            int modified = 0;
            int nextOutletCode = this.GetNextOutletCode();
            if (nextOutletCode <= 0) throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg5"), outletDescription));

            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO `lottery_outlet` (`outlet_cd`, `description`, `active`) " +
                                      " VALUES(@nextOutletCode, @outletDescription, true)";
                command.Parameters.AddWithValue("@nextOutletCode", nextOutletCode);
                command.Parameters.AddWithValue("@outletDescription", StringUtils.Truncate(outletDescription, MAX_LEN_DESCRIPTION));

                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg3"), outletDescription));
                }
                else
                {
                    transaction.Commit();
                    modified = base.GetLastInsertedID(command);
                }
            }
            return modified;
        }
        public int GetNextOutletCode()
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT (MAX(`outlet_cd`) + 1) AS [NEXT_OUTLET_CODE] FROM `lottery_outlet`";
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int next = int.Parse(reader["NEXT_OUTLET_CODE"].ToString());
                            return next;
                        }
                    }
                }
            }
            return -1;
        }
        private LotteryOutletSetup CreateModel(OleDbDataReader reader)
        {
            LotteryOutletSetup lotteryOutletSetup = new LotteryOutletSetup();
            lotteryOutletSetup.Id = long.Parse(reader["ID"].ToString());
            lotteryOutletSetup.Description = reader["description"].ToString();
            lotteryOutletSetup.OutletCode = int.Parse(reader["outlet_cd"].ToString());
            return lotteryOutletSetup;
        }
    }
}
