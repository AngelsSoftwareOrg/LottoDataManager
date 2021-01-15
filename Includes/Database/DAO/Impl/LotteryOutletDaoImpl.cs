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
    public class LotteryOutletDaoImpl: LotteryOutletDao
    {
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
                        LotteryOutletSetup lotteryOutletSetup = new LotteryOutletSetup();
                        lotteryOutletSetup.Id = long.Parse(reader["ID"].ToString());
                        lotteryOutletSetup.Description = reader["description"].ToString();
                        lotteryOutletSetup.OutletCode = int.Parse(reader["outlet_cd"].ToString());
                        lotteryOutletArr.Add(lotteryOutletSetup);
                    }
                }
            }
            return lotteryOutletArr;
        }



    }
}
