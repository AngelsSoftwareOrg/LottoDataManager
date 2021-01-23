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

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class LotteryWinningBetDaoImpl : LotteryWinningBetDao
    {
        private static LotteryWinningBetDaoImpl lotteryWinningBetDaoImpl;
        private LotteryWinningBetDaoImpl() { }
        public static LotteryWinningBetDao GetInstance()
        {
            if (lotteryWinningBetDaoImpl == null)
            {
                lotteryWinningBetDaoImpl = new LotteryWinningBetDaoImpl();
            }
            return lotteryWinningBetDaoImpl;
        }
        public LotteryWinningBet GetLotteryWinningBet(long lotteryBetID)
        {
            LotteryWinningBetSetup lotteryWinningBet = new LotteryWinningBetSetup();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM lottery_winning_bet WHERE bet_id = @lotteryBetID AND active = true";
                command.Parameters.AddWithValue("@lotteryBetID", lotteryBetID);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryWinningBet.LotteryBetId = long.Parse(reader["bet_id"].ToString());
                        lotteryWinningBet.WinningAmount = double.Parse(reader["winning_amt"].ToString());
                        lotteryWinningBet.Num1 = int.Parse(reader["num1"].ToString());
                        lotteryWinningBet.Num2 = int.Parse(reader["num2"].ToString());
                        lotteryWinningBet.Num3 = int.Parse(reader["num3"].ToString());
                        lotteryWinningBet.Num4 = int.Parse(reader["num4"].ToString());
                        lotteryWinningBet.Num5 = int.Parse(reader["num5"].ToString());
                        lotteryWinningBet.Num6 = int.Parse(reader["num6"].ToString());
                        lotteryWinningBet.ClaimStatus = bool.Parse(reader["claim_status"].ToString());
                    }
                }
            }
            return lotteryWinningBet;
        }
        public void InsertWinningBet(LotteryWinningBet lotteryWinningBet)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO lottery_winning_bet (bet_id, winning_amt, active, claim_status,num1, num2, num3, num4, num5, num6) " +
                                      " VALUES (@lotteryBetID,@winningAmt,true,@claimStatus,@num1,@num2,@num3,@num4,@num5,@num6)";
                command.Parameters.AddWithValue("@lotteryBetID", lotteryWinningBet.GetLotteryBetId());
                command.Parameters.AddWithValue("@winningAmt", lotteryWinningBet.GetWinningAmount());
                command.Parameters.AddWithValue("@num1", lotteryWinningBet.GetNum1());
                command.Parameters.AddWithValue("@num2", lotteryWinningBet.GetNum2());
                command.Parameters.AddWithValue("@num3", lotteryWinningBet.GetNum3());
                command.Parameters.AddWithValue("@num4", lotteryWinningBet.GetNum4());
                command.Parameters.AddWithValue("@num5", lotteryWinningBet.GetNum5());
                command.Parameters.AddWithValue("@num6", lotteryWinningBet.GetNum6());
                command.Parameters.AddWithValue("@claimStatus", lotteryWinningBet.IsClaimed());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception("Target Bet ID: " + lotteryWinningBet.GetLotteryBetId()
                        + " | Error inserting data into Lottery Winning Bet Database! ");
                }
                transaction.Commit();
            }
        }
        public double GetTotalWinningsAmount(GameMode gameMode)
        {
            LotteryWinningBetSetup lotteryWinningBet = new LotteryWinningBetSetup();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT SUM(winning_amt) AS [WINNING_AMOUNT] " + 
                                      "  FROM lottery_winning_bet a " +
                                      " INNER JOIN lottery_bet b on a.bet_id = b.id " +
                                      " WHERE a.active = true " +
                                      "   AND b.game_cd = @game_cd";
                command.Parameters.AddWithValue("@game_cd", (int) gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return double.Parse(reader["WINNING_AMOUNT"].ToString());
                        }
                    }
                }
            }
            return 0.00;
        }
        public double GetTotalWinningsAmountThisMonth(GameMode gameMode)
        {
            LotteryWinningBetSetup lotteryWinningBet = new LotteryWinningBetSetup();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT SUM(winning_amt) AS [WINNING_AMOUNT] " +
                                      "  FROM lottery_winning_bet a " +
                                      " INNER JOIN lottery_bet b on a.bet_id = b.id " +
                                      " WHERE a.active = true " +
                                      "   AND b.game_cd = @game_cd " +
                                      "   AND MONTH(target_draw_date) = MONTH(NOW()) ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return double.Parse(reader["WINNING_AMOUNT"].ToString());
                        }
                    }
                }
            }
            return 0.00;
        }
        public void RemoveLotteryWinningBet(long betId)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_winning_bet SET active = 0 " +
                                      " WHERE ID = @id";
                command.Parameters.AddWithValue("@id", OleDbType.BigInt).Value = (long)betId;
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception("Removing Lottery Winning Bet ID: " + betId + " | Error updating data into Lottery Bet Database! ");
                }
                transaction.Commit();
            }
        }
    }
}
