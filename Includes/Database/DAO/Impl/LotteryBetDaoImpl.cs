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
                command.CommandText = "SELECT a.* " + //TOP 10 
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
        public bool IsBetExisting(LotteryBet lotteryBet)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(ID) AS [DUPLICATE_COUNT] FROM lottery_bet " +
                                      " WHERE game_cd = @game_cd " +
                                      "   AND target_draw_date = CDATE(@draw_date) " +
                                      "   AND active = true " +
                                      "   AND ( " +
                                      "     @num1 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num2 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num3 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num4 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num5 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num6 IN(num1, num2, num3, num4, num5, num6)) ";
                command.Parameters.AddWithValue("@game_cd", lotteryBet.GetGameCode());
                command.Parameters.AddWithValue("@draw_date", lotteryBet.GetTargetDrawDate().Date.ToString());
                command.Parameters.AddWithValue("@num1", lotteryBet.GetNum1());
                command.Parameters.AddWithValue("@num2", lotteryBet.GetNum2());
                command.Parameters.AddWithValue("@num3", lotteryBet.GetNum3());
                command.Parameters.AddWithValue("@num4", lotteryBet.GetNum4());
                command.Parameters.AddWithValue("@num5", lotteryBet.GetNum5());
                command.Parameters.AddWithValue("@num6", lotteryBet.GetNum6());
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long duplicateCount= long.Parse(reader["DUPLICATE_COUNT"].ToString());
                        return (duplicateCount > 0);
                    }
                }
            }
            return false;
        }
        public void InsertLotteryBet(List<LotteryBet> lotteryBetArr)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO lottery_bet (game_cd,target_draw_date, " +
                                      "                          bet_amt,active,outlet_cd,luckypick, " +
                                      "                          num1,num2,num3,num4,num5,num6) " +
                                      " VALUES (@game_cda, CDATE(@target_draw_datea), " +
                                      "         @bet_amta, 1, @outlet_cda, @luckypicka, " +
                                      "         @num1a, @num2a, @num3a, @num4a, @num5a, @num6a) ";
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();

                foreach (LotteryBet item in lotteryBetArr)
                {
                    if (IsBetExisting(item)) continue;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@game_cda", item.GetGameCode());
                    command.Parameters.AddWithValue("@target_draw_datea", item.GetTargetDrawDate().Date.ToString());
                    command.Parameters.AddWithValue("@bet_amta", item.GetBetAmount());
                    command.Parameters.AddWithValue("@outlet_cda", item.GetOutletCode());
                    command.Parameters.AddWithValue("@luckypicka", item.IsLuckyPick());
                    command.Parameters.AddWithValue("@num1a", item.GetNum1());
                    command.Parameters.AddWithValue("@num2a", item.GetNum2());
                    command.Parameters.AddWithValue("@num3a", item.GetNum3());
                    command.Parameters.AddWithValue("@num4a", item.GetNum4());
                    command.Parameters.AddWithValue("@num5a", item.GetNum5());
                    command.Parameters.AddWithValue("@num6a", item.GetNum6());

                    command.Transaction = transaction;
                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        transaction.Rollback();
                        throw new Exception("Error in inserting data into Lottery Bet Database! ");
                    }
                    else
                    {
                        transaction.Commit();
                        transaction.Dispose();
                        transaction = null;
                        transaction = conn.BeginTransaction();
                    }
                }
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
            bet.LuckyPick = bool.Parse(reader["luckypick"].ToString());
            bet.SortNumbers();
            return bet;
        }
    }
}
