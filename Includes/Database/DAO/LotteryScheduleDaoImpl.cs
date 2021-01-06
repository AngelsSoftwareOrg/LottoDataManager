using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO
{
    public class LotteryScheduleDaoImpl : LotteryScheduleDao
    {
        private static LotteryScheduleDaoImpl lotteryScheduleDaoImpl;

        private LotteryScheduleDaoImpl() { }

        public static LotteryScheduleDao GetInstance()
        {
            if(lotteryScheduleDaoImpl == null)
            {
                lotteryScheduleDaoImpl = new LotteryScheduleDaoImpl();
            }
            return lotteryScheduleDaoImpl;
        }


        public LotterySchedule GetLotterySchedule(GameMode gameMode)
        {
            LotteryScheduleSetup lotterySched = new LotteryScheduleSetup();
            using(OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using(OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_schedule WHERE game_cd = ? AND active = true", conn)) {
                command.Parameters.AddWithValue("game_cd", gameMode);
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotterySched.Monday = Boolean.Parse(reader["mon"].ToString());
                        lotterySched.Tuesday = Boolean.Parse(reader["tues"].ToString());
                        lotterySched.Wednesday = Boolean.Parse(reader["wed"].ToString());
                        lotterySched.Thursday = Boolean.Parse(reader["thurs"].ToString());
                        lotterySched.Friday = Boolean.Parse(reader["fri"].ToString());
                        lotterySched.Saturday = Boolean.Parse(reader["sat"].ToString());
                        lotterySched.Sunday = Boolean.Parse(reader["sun"].ToString());               
                    }
                }
            }
            return lotterySched;
        }
    }
}
