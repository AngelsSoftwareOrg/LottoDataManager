using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class LotterySequenceGenDaoImpl: LotterySequenceGenDao
    {
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
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_seq_gen WHERE active = true;", conn))
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
