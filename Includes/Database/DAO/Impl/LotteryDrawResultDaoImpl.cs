using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO
{
    public class LotteryDrawResultDaoImpl: LotteryDrawResultDao
    {
        private static LotteryDrawResultDaoImpl lotteryDrawResultDaoImpl;

        private LotteryDrawResultDaoImpl() { }

        public static LotteryDrawResultDao GetInstance()
        {
            if (lotteryDrawResultDaoImpl == null)
            {
                lotteryDrawResultDaoImpl = new LotteryDrawResultDaoImpl();
            }
            return lotteryDrawResultDaoImpl;
        }

        private DataTable GetStandardDrawResultTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Draw Date", typeof(DateTime));
            dt.Columns.Add("Num 1", typeof(int));
            dt.Columns.Add("Num 2", typeof(int));
            dt.Columns.Add("Num 3", typeof(int));
            dt.Columns.Add("Num 4", typeof(int));
            dt.Columns.Add("Num 5", typeof(int));
            dt.Columns.Add("Num 6", typeof(int));
            dt.Columns.Add("Jackpot Amount", typeof(double));
            dt.Columns.Add("Winners", typeof(int));
            return dt;
        }

        public DataTable GetLotteryDrawResult(GameMode gameMode, DateTime drawDate)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = GetDrawResultCommandByRange(gameMode, drawDate, drawDate))
            {
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader _dr = command.ExecuteReader())
                {
                    dt.Load(_dr);
                }
            }
            return dt;
        }

        public LotteryDrawResult GetLotteryDrawResultByDrawDate(GameMode gameMode, DateTime drawDate)
        {
            LotteryDrawResultSetup lotteryDrawResult = null;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = GetStandardSelectQuery() + " AND draw_date = CDATE(@drawDate)";
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = (int)gameMode;
                command.Parameters.AddWithValue("@drawDate", OleDbType.DBDate).Value = drawDate.ToString();
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return lotteryDrawResult;
                    lotteryDrawResult = new LotteryDrawResultSetup();
                    while (reader.Read())
                    {
                        lotteryDrawResult.Id = long.Parse(reader["ID"].ToString());
                        lotteryDrawResult.Num1 = int.Parse(reader["num1"].ToString());
                        lotteryDrawResult.Num2 = int.Parse(reader["num2"].ToString());
                        lotteryDrawResult.Num3 = int.Parse(reader["num3"].ToString());
                        lotteryDrawResult.Num4 = int.Parse(reader["num4"].ToString());
                        lotteryDrawResult.Num5 = int.Parse(reader["num5"].ToString());
                        lotteryDrawResult.Num6 = int.Parse(reader["num6"].ToString());
                        lotteryDrawResult.JackpotAmt = double.Parse(reader["jackpot_amt"].ToString());
                        lotteryDrawResult.Winners = int.Parse(reader["winners"].ToString());
                        lotteryDrawResult.DrawDate = DateTime.Parse(reader["draw_date"].ToString());
                        lotteryDrawResult.GameCode = (int)gameMode;
                    }
                }
            }
            return lotteryDrawResult;
        }

        public List<LotteryDrawResult> GetAllDrawResults(GameMode gameMode)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM (" + GetStandardSelectQuery() + " ORDER BY draw_date DESC)";
                command.Parameters.AddWithValue("@game_cd", gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LotteryDrawResultSetup dr = new LotteryDrawResultSetup();
                        dr.DrawDate = DateTime.Parse(reader["draw_date"].ToString());
                        dr.GameCode = (int) gameMode;
                        dr.Id = long.Parse(reader["ID"].ToString());

                        dr.Num1 = int.Parse(reader["num1"].ToString());
                        dr.Num2 = int.Parse(reader["num2"].ToString());
                        dr.Num3 = int.Parse(reader["num3"].ToString());
                        dr.Num4 = int.Parse(reader["num4"].ToString());
                        dr.Num5 = int.Parse(reader["num5"].ToString());
                        dr.Num6 = int.Parse(reader["num6"].ToString());
                        dr.SortNumbers();
                        dr.JackpotAmt = double.Parse(reader["jackpot_amt"].ToString());
                        dr.Winners = int.Parse(reader["winners"].ToString());
                        dr.Id = long.Parse(reader["ID"].ToString());
                        results.Add(dr);
                    }
                }
            }
            return results;
        }

        public List<LotteryDrawResult> GetDrawResultsFromStartingDate(GameMode gameMode, DateTime startingDrawDate)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = GetStandardSelectQuery() +
                                      " AND draw_date >= CDATE(@startingDrawDate) " +
                                      " ORDER BY draw_date DESC";
                command.Parameters.AddWithValue("@game_cd", (int) gameMode);
                command.Parameters.AddWithValue("@startingDrawDate", startingDrawDate.ToString());
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LotteryDrawResultSetup dr = new LotteryDrawResultSetup();
                        dr.DrawDate = DateTime.Parse(reader["draw_date"].ToString());
                        dr.GameCode = (int)gameMode;
                        dr.Id = long.Parse(reader["ID"].ToString());

                        dr.Num1 = int.Parse(reader["num1"].ToString());
                        dr.Num2 = int.Parse(reader["num2"].ToString());
                        dr.Num3 = int.Parse(reader["num3"].ToString());
                        dr.Num4 = int.Parse(reader["num4"].ToString());
                        dr.Num5 = int.Parse(reader["num5"].ToString());
                        dr.Num6 = int.Parse(reader["num6"].ToString());
                        dr.SortNumbers();
                        dr.JackpotAmt = double.Parse(reader["jackpot_amt"].ToString());
                        dr.Winners = int.Parse(reader["winners"].ToString());
                        dr.Id = long.Parse(reader["ID"].ToString());
                        results.Add(dr);
                    }
                }
            }
            return results;
        }

        public DateTime GetNextDrawDate(GameMode gameMode, DateTime betDate)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT TOP 1 * FROM draw_results " +
                                      "  WHERE game_cd = @game_cd " +
                                      "    AND draw_date > CDATE(@betDate) " +
                                      "  ORDER BY draw_date ASC ";
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = (int)gameMode;
                command.Parameters.AddWithValue("@betDate", OleDbType.DBDate).Value = betDate.ToString();
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return DateTime.Parse(reader["draw_date"].ToString());
                        }
                    }
                }
            }
            return DateTime.Now.AddDays(-13000);
        }

        public void InsertDrawDate(LotteryDrawResult lotteryDrawResult)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO draw_results (draw_date,jackpot_amt,winners,game_cd,num1,num2,num3,num4,num5,num6) " +
                                      " VALUES (@draw_date,@jackpot_amt,@winners,@game_cd,@num1,@num2,@num3,@num4,@num5,@num6)";
                command.Parameters.AddWithValue("@draw_date", lotteryDrawResult.GetDrawDate());
                command.Parameters.AddWithValue("@jackpot_amt", lotteryDrawResult.GetJackpotAmt());
                command.Parameters.AddWithValue("@winners", lotteryDrawResult.GetWinners());
                command.Parameters.AddWithValue("@game_cd", lotteryDrawResult.GetGameCode());
                command.Parameters.AddWithValue("@num1", lotteryDrawResult.GetNum1());
                command.Parameters.AddWithValue("@num2", lotteryDrawResult.GetNum2());
                command.Parameters.AddWithValue("@num3", lotteryDrawResult.GetNum3());
                command.Parameters.AddWithValue("@num4", lotteryDrawResult.GetNum4());
                command.Parameters.AddWithValue("@num5", lotteryDrawResult.GetNum5());
                command.Parameters.AddWithValue("@num6", lotteryDrawResult.GetNum6());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception("Error inserting data into Lottery result database!");
                }
                transaction.Commit();
            }
        }

        public DateTime GetLatestDrawDate(GameMode gameMode)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT TOP 1 draw_date " +
                                      "   FROM draw_results " +
                                      "  WHERE game_cd = @game_cd" +
                                      "  ORDER BY draw_date DESC ";
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = (int)gameMode;
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return DateTime.Parse(reader["draw_date"].ToString());
                        }
                    }
                }
            }
            return DateTime.Now.AddDays(-13000);
        }

        private OleDbCommand GetDrawResultCommandByRange(GameMode gameMode, DateTime fromDate, DateTime toDate)
        {
            OleDbCommand command = new OleDbCommand(
                GetStandardSelectQuery() +
                "   AND (draw_date " +
                "       BETWEEN CDate(@date_from) " +
                "           AND CDate(@date_to))");
            command.Parameters.AddWithValue("@game_cd", gameMode);
            command.Parameters.AddWithValue("@date_from", fromDate);
            command.Parameters.AddWithValue("@date_to", (toDate == null) ? fromDate : toDate);
            return command;
        }

        private String GetStandardSelectQuery()
        {
            return "SELECT ID, draw_date, num1, num2, num3, num4, num5, num6, jackpot_amt, winners " +
                "  FROM draw_results " +
                " WHERE game_cd = @game_cd ";
        }

    }
}
