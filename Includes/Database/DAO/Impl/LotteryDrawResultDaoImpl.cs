using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

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
                        return GetLotteryDrawResultSetup(reader, gameMode);
                        
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
                        results.Add(GetLotteryDrawResultSetup(reader, gameMode));
                    }
                }
            }
            return results;
        }
        public List<LotteryDrawResult> GetLatestLotteryResult(GameMode gameMode, int howManyDraws)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP " + howManyDraws.ToString() + " * FROM (" + GetStandardSelectQuery() + " ORDER BY draw_date DESC)";
                //command.Parameters.AddWithValue("@draws", howManyDraws);
                command.Parameters.AddWithValue("@game_cd", gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(GetLotteryDrawResultSetup(reader, gameMode));
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
                        results.Add(GetLotteryDrawResultSetup(reader, gameMode));
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
            return DateTimeConverterUtils.GetYear2011();
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
                    throw new Exception(ResourcesUtils.GetMessage("lot_dao_impl_msg9"));
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
            return DateTimeConverterUtils.GetYear2011();
        }
        public List<int> GetTopDrawnDigitResults(GameMode gameMode)
        {
            List<int> merge = new List<int>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT a.num1, a.num2, a.num3, a.num4, a.num5, a.num6 " +
                                      "   FROM draw_results a " +
                                      "  WHERE a.game_cd = @game_cd1 " +
                                      "    AND a.draw_date > (SELECT TOP 1 d.draw_date " +
                                      "                         FROM draw_results d " +
                                      "                        WHERE d.winners > 0 " +
                                      "                          AND d.game_cd = @game_cd2 " +
                                      "                        ORDER BY d.draw_date DESC)";
                command.Parameters.AddWithValue("@game_cd1", (int)gameMode);
                command.Parameters.AddWithValue("@game_cd2", (int)gameMode);
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            merge.Add(int.Parse(reader["num1"].ToString()));
                            merge.Add(int.Parse(reader["num2"].ToString()));
                            merge.Add(int.Parse(reader["num3"].ToString()));
                            merge.Add(int.Parse(reader["num4"].ToString()));
                            merge.Add(int.Parse(reader["num5"].ToString()));
                            merge.Add(int.Parse(reader["num6"].ToString()));
                        }
                    }
                }
            }
            return merge;
        }
        public List<int> GetTopDrawnPreviousSeasonDigitResults(GameMode gameMode)
        {
            List<int> merge = new List<int>();
            LotteryDrawResult[] lotteryDrawResultArr = GetJackpotDrawResults(gameMode).ToArray();
            if (lotteryDrawResultArr.Length < 2) return merge;

            DateTime fromDate= lotteryDrawResultArr[1].GetDrawDate();
            DateTime toDate = lotteryDrawResultArr[0].GetDrawDate();

            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT a.num1, a.num2, a.num3, a.num4, a.num5, a.num6 " +
                                      "  FROM draw_results a " +
                                      " WHERE a.game_cd = @game_cd " +
                                      "   AND a.draw_date BETWEEN CDATE(@fromDate) " +
                                      "   AND CDATE(@toDate) " +
                                      "   AND a.draw_date<> CDATE(@fromDate) " +
                                      " ORDER BY a.draw_date DESC";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@fromDate", fromDate.Date.ToString());
                command.Parameters.AddWithValue("@toDate", toDate.Date.ToString());
                command.Parameters.AddWithValue("@fromDate", fromDate.Date.ToString());
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            merge.Add(int.Parse(reader["num1"].ToString()));
                            merge.Add(int.Parse(reader["num2"].ToString()));
                            merge.Add(int.Parse(reader["num3"].ToString()));
                            merge.Add(int.Parse(reader["num4"].ToString()));
                            merge.Add(int.Parse(reader["num5"].ToString()));
                            merge.Add(int.Parse(reader["num6"].ToString()));
                        }
                    }
                }
            }
            return merge;
        }
        public List<int> GetTopDrawnDigitFromJackpotsResults(GameMode gameMode)
        {
            List<int> merge = new List<int>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT num1, num2, num3, num4, num5, num6 " +
                                      "  FROM draw_results " +
                                      "  WHERE game_cd = @game_cd " +
                                      "    AND winners > 0";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            merge.Add(int.Parse(reader["num1"].ToString()));
                            merge.Add(int.Parse(reader["num2"].ToString()));
                            merge.Add(int.Parse(reader["num3"].ToString()));
                            merge.Add(int.Parse(reader["num4"].ToString()));
                            merge.Add(int.Parse(reader["num5"].ToString()));
                            merge.Add(int.Parse(reader["num6"].ToString()));
                        }
                    }
                }
            }
            return merge;
        }
        public List<int> GetTopDrawnDigitFromDateRange(GameMode gameMode, DateTime dateFrom, DateTime dateTo)
        {
            List<int> merge = new List<int>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT num1, num2, num3, num4, num5, num6 " +
                                      "  FROM draw_results " +
                                      "  WHERE game_cd = @game_cd " +
                                      "    AND draw_date BETWEEN CDATE(@dateFrom) AND CDATE(@dateTo)";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@dateFrom", dateFrom.Date.ToString());
                command.Parameters.AddWithValue("@dateTo", dateTo.Date.ToString());
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            merge.Add(int.Parse(reader["num1"].ToString()));
                            merge.Add(int.Parse(reader["num2"].ToString()));
                            merge.Add(int.Parse(reader["num3"].ToString()));
                            merge.Add(int.Parse(reader["num4"].ToString()));
                            merge.Add(int.Parse(reader["num5"].ToString()));
                            merge.Add(int.Parse(reader["num6"].ToString()));
                        }
                    }
                }
            }
            return merge;
        }
        public List<int[]> GetTopDrawnDigitToSequenceFromDateRange(GameMode gameMode, DateTime dateFrom, DateTime dateTo)
        {
            List<int[]> result = new List<int[]>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT num1, num2, num3, num4, num5, num6 " +
                                      "  FROM draw_results " +
                                      "  WHERE game_cd = @game_cd " +
                                      "    AND draw_date BETWEEN CDATE(@dateFrom) AND CDATE(@dateTo)";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@dateFrom", dateFrom.Date.ToString());
                command.Parameters.AddWithValue("@dateTo", dateTo.Date.ToString());
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int[] num = new int[6];
                            num[0] = (int.Parse(reader["num1"].ToString()));
                            num[1] = (int.Parse(reader["num2"].ToString()));
                            num[2] = (int.Parse(reader["num3"].ToString()));
                            num[3] = (int.Parse(reader["num4"].ToString()));
                            num[4] = (int.Parse(reader["num5"].ToString()));
                            num[5] = (int.Parse(reader["num6"].ToString()));
                            result.Add(num);
                        }
                    }
                }
            }
            return result;
        }
        public List<LotteryDrawResult> GetJackpotDrawResults(GameMode gameMode)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM draw_results " +
                                      " WHERE game_cd = @game_cd " +
                                      "   AND winners> 0 " +
                                      " ORDER BY draw_date DESC";
                command.Parameters.AddWithValue("@game_cd", gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(GetLotteryDrawResultSetup(reader, gameMode));
                    }
                }
            }
            return results;
        }
        private LotteryDrawResultSetup GetLotteryDrawResultSetup(OleDbDataReader reader, GameMode gameMode)
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
            return dr;
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
        public List<LotteryDrawResult> GetMachineLearningDataSetFastTree(GameMode gameMode, DateTime startingDate)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT TOP 500 jackpot_amt,ID,draw_date,num1,num2,num3,num4,num5,num6,winners,game_cd, " +
                                        " 	     FORMAT(num1,'00') + FORMAT(num2,'00') + FORMAT(num3,'00') +  " +
                                        " 	     FORMAT(num4,'00') + FORMAT(num5,'00') + FORMAT(num6,'00') AS ['result'] " +
                                        "   FROM draw_results " +
                                        "  WHERE game_cd = @game_cd " +
                                        " 	 AND `draw_date` > CDATE(@startingDate) " +
                                        "  ORDER BY `draw_date` ASC ";
                command.Parameters.AddWithValue("@game_cd", gameMode);
                command.Parameters.AddWithValue("@startingDate", startingDate.Date.ToString());
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(GetLotteryDrawResultSetup(reader, gameMode));
                    }
                }
            }
            return results;
        }
        public List<LotteryDrawResult> GetMachineLearningDataSetSDCA(GameMode gameMode, DateTime startingDate)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT TOP 500 * " +
                                        "   FROM draw_results " +
                                        "  WHERE game_cd = @game_cd " +
                                        " 	 AND `draw_date` > CDATE(@startingDate) " +
                                        "  ORDER BY `draw_date` ASC ";
                command.Parameters.AddWithValue("@game_cd", gameMode);
                command.Parameters.AddWithValue("@startingDate", startingDate.Date.ToString());
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(GetLotteryDrawResultSetup(reader, gameMode));
                    }
                }
            }
            return results;
        }
    }
}
