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

        public List<LotteryDrawResult> GetAllDrawResults(GameMode gameMode)
        {
            List<LotteryDrawResult> results = new List<LotteryDrawResult>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                //DEBUGGING - TOP 200
                command.CommandText = "SELECT TOP 200 * FROM (" + GetStandardSelectQuery() + " ORDER BY draw_date DESC)";
                //DEBUGGING END
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

                        int[] winNumTmp = new int[] { int.Parse(reader["num1"].ToString()), 
                                                    int.Parse(reader["num2"].ToString()), 
                                                    int.Parse(reader["num3"].ToString()), 
                                                    int.Parse(reader["num4"].ToString()), 
                                                    int.Parse(reader["num5"].ToString()), 
                                                    int.Parse(reader["num6"].ToString())};
                        Array.Sort(winNumTmp);
                        dr.Num1 = winNumTmp[0];
                        dr.Num2 = winNumTmp[1];
                        dr.Num3 = winNumTmp[2];
                        dr.Num4 = winNumTmp[3];
                        dr.Num5 = winNumTmp[4];
                        dr.Num6 = winNumTmp[5];
                        dr.JackpotAmt = double.Parse(reader["jackpot_amt"].ToString());
                        dr.Winners = int.Parse(reader["winners"].ToString());
                        results.Add(dr);
                    }
                }
            }
            return results;
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
            return "SELECT draw_date, num1, num2, num3, num4, num5, num6, jackpot_amt, winners " +
                "  FROM draw_results " +
                " WHERE game_cd = @game_cd ";
        }

    }
}
