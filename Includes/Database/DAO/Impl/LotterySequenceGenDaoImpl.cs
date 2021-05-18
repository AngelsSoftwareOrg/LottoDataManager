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
    public class LotterySequenceGenDaoImpl: LotterySequenceGenDao
    {
        public static int MAX_LEN_DESCRIPTION = 255;
        private static LotterySequenceGenDaoImpl lotterySequenceGenDaoImpl;
        private LotterySequenceGenDaoImpl() { }
        public static LotterySequenceGenDao GetInstance()
        {
            if (lotterySequenceGenDaoImpl == null)
            {
                lotterySequenceGenDaoImpl = new LotterySequenceGenDaoImpl();
            }
            return lotterySequenceGenDaoImpl;
        }
        public List<LotterySequenceGenerator> GetAllSeqGenerators()
        {
            List<LotterySequenceGenerator> lotterySeqGenList = new List<LotterySequenceGenerator>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_seq_gen WHERE active = true ORDER BY description ASC", conn))
            {
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotterySeqGenList.Add(GetModel(reader));
                    }
                }
            }
            return lotterySeqGenList;
        }
        public LotterySequenceGenerator GetSeqGenerators(int seqGenId)
        {
            LotterySequenceGeneratorSetup lotterySeqGen = null;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_seq_gen WHERE seqGenId = @seqGenId AND active = true", conn))
            {
                command.Parameters.AddWithValue("@seqGenId", seqGenId);
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotterySeqGen = GetModel(reader);
                    }
                }
            }
            return lotterySeqGen;
        }
        public void UpdateDescription(LotterySequenceGenerator updatedModel)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_seq_gen SET description= @description " +
                                      " WHERE ID = @id AND seqgencd = @seqgencd AND active = true";
                command.Parameters.AddWithValue("@description", StringUtils.Truncate(updatedModel.GetDescription(), MAX_LEN_DESCRIPTION));
                command.Parameters.AddWithValue("@id", updatedModel.GetID());
                command.Parameters.AddWithValue("@seqgencd", updatedModel.GetSeqGenCode());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg2"), updatedModel.GetDescription()));
                }
                transaction.Commit();
            }
        }
        public bool IsDescriptionExisting(String seqGenDescription)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT count(ID) AS [total] FROM lottery_seq_gen " +
                                      " WHERE description = @description " +
                                      "   AND active = true ";
                command.Parameters.AddWithValue("@description", seqGenDescription);
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
        private LotterySequenceGeneratorSetup GetModel(OleDbDataReader reader)
        {
            LotterySequenceGeneratorSetup lotterySeqGen = new LotterySequenceGeneratorSetup();
            lotterySeqGen.ID = int.Parse(reader["ID"].ToString());
            lotterySeqGen.SeqGenCode = int.Parse(reader["seqgencd"].ToString());
            lotterySeqGen.Description = reader["description"].ToString();
            return lotterySeqGen;
        }
    }
}
