using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class LotteryBetDaoImpl : LotteryBetDao
    {
        private static LotteryBetDaoImpl lotteryBetDaoImpl;
        private LotteryBetDaoImpl() { }
        public static LotteryBetDao GetInstance()
        {
            if (lotteryBetDaoImpl == null)
            {
                lotteryBetDaoImpl = new LotteryBetDaoImpl();
            }
            return lotteryBetDaoImpl;
        }
        public List<LotteryBet> GetDashboardLatestBets(GameMode gameMode, DateTime sinceWhen)
        {
            List<LotteryBet> lotteryBet = new List<LotteryBet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM lottery_bet " +
                                      " WHERE game_cd = @game_cd " +
                                      "   AND target_draw_date >= CDATE(@sinceWhen) " +
                                      "   AND active = true " +
                                      " ORDER BY target_draw_date DESC";
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = gameMode;
                command.Parameters.AddWithValue("@sinceWhen", OleDbType.DBDate).Value = sinceWhen.ToString();
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryBet.Add(GetInstanceDeriveLotteryBetSetup(reader));
                    }
                }
            }
            return lotteryBet;
        }
        public List<LotteryBet> ExtractLotteryBetsCheckWinningNumber(GameMode gameMode)
        {
            List<LotteryBet> lotteryBet = new List<LotteryBet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP 10 a.* " +
                                      "  FROM lottery_bet a " + 
                                      "  LEFT OUTER JOIN lottery_winning_bet b " +
                                      "    ON (a.ID = b.bet_id) " +
                                      " WHERE b.bet_id IS NULL " +
                                      "   AND a.active = true " +
                                      "   AND b.active IS NULL " +
                                      "   AND a.game_cd = @game_cd " +
                                      " ORDER BY a.target_draw_date DESC ";
                command.Parameters.AddWithValue("@game_cd", gameMode);
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryBet.Add(GetInstanceDeriveLotteryBetSetup(reader));
                    }
                }
            }
            return lotteryBet;
        }
        public void UpdateTargetDrawDate(long id, DateTime newTargetDrawDate)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_bet SET target_draw_date = CDATE(@new_target_draw_date) " +
                                      " WHERE ID = @id AND active = true";
                command.Parameters.AddWithValue("@new_target_draw_date", OleDbType.DBDate).Value = newTargetDrawDate.ToString();
                command.Parameters.AddWithValue("@id", OleDbType.BigInt).Value = (long)id;
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception("Updating Target Bet ID: " + id + " | Error updating data into Lottery Bet Database! ");
                }
                transaction.Commit();
            }
        }

        private LotteryBetSetup GetInstanceDeriveLotteryBetSetup(OleDbDataReader reader)
        {
            LotteryBetSetup bet = new LotteryBetSetup();
            bet.BetAmount = double.Parse(reader["bet_amt"].ToString());
            bet.GameCode = int.Parse(reader["game_cd"].ToString());
            bet.Id = long.Parse(reader["ID"].ToString());
            bet.OutletCode = int.Parse(reader["outlet_cd"].ToString());
            bet.TargetDrawDate = DateTime.Parse(reader["target_draw_date"].ToString());
            bet.Num1 = int.Parse(reader["num1"].ToString());
            bet.Num2 = int.Parse(reader["num2"].ToString());
            bet.Num3 = int.Parse(reader["num3"].ToString());
            bet.Num4 = int.Parse(reader["num4"].ToString());
            bet.Num5 = int.Parse(reader["num5"].ToString());
            bet.Num6 = int.Parse(reader["num6"].ToString());
            bet.SortNumbers();
            return bet;
        }
        
    }
}
