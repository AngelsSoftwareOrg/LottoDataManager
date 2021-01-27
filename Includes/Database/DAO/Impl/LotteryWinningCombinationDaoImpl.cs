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
    public class LotteryWinningCombinationDaoImpl : LotteryWinningCombinationDao
    {
        private static LotteryWinningCombinationDaoImpl lotteryWinningCombinationDaoImpl;

        private LotteryWinningCombinationDaoImpl() { }

        public static LotteryWinningCombinationDao GetInstance()
        {
            if (lotteryWinningCombinationDaoImpl == null)
            {
                lotteryWinningCombinationDaoImpl = new LotteryWinningCombinationDaoImpl();
            }
            return lotteryWinningCombinationDaoImpl;
        }

        public LotteryWinningCombination GetLotteryWinningCombination(GameMode gameMode)
        {
            LotteryWinningCombinationSetup lotteryWinningCombinationSetup = new LotteryWinningCombinationSetup();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_winning_combination WHERE game_cd = ? AND active = true;", conn))
            {
                command.Parameters.AddWithValue("game_cd", gameMode);
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryWinningCombinationSetup.Match0 = double.Parse(reader["match_0"].ToString());
                        lotteryWinningCombinationSetup.Match1 = double.Parse(reader["match_1"].ToString());
                        lotteryWinningCombinationSetup.Match2 = double.Parse(reader["match_2"].ToString());
                        lotteryWinningCombinationSetup.Match3 = double.Parse(reader["match_3"].ToString());
                        lotteryWinningCombinationSetup.Match4 = double.Parse(reader["match_4"].ToString());
                        lotteryWinningCombinationSetup.Match5 = double.Parse(reader["match_5"].ToString());
                        lotteryWinningCombinationSetup.Match6 = double.Parse(reader["match_6"].ToString());
                    }
                }
            }
            return lotteryWinningCombinationSetup;
        }
    }
}
