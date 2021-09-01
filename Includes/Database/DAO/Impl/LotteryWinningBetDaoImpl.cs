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
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class LotteryWinningBetDaoImpl : LotteryDaoImplCommon, LotteryWinningBetDao
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
                        lotteryWinningBet.ID = long.Parse(reader["ID"].ToString());
                        lotteryWinningBet.LotteryBetId = long.Parse(reader["bet_id"].ToString());
                        lotteryWinningBet.WinningAmount = double.Parse(reader["winning_amt"].ToString());
                        lotteryWinningBet.Num1 = int.Parse(reader["num1"].ToString());
                        lotteryWinningBet.Num2 = int.Parse(reader["num2"].ToString());
                        lotteryWinningBet.Num3 = int.Parse(reader["num3"].ToString());
                        lotteryWinningBet.Num4 = int.Parse(reader["num4"].ToString());
                        lotteryWinningBet.Num5 = int.Parse(reader["num5"].ToString());
                        lotteryWinningBet.Num6 = int.Parse(reader["num6"].ToString());
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["num1"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["num2"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["num3"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["num4"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["num5"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["num6"].ToString()));
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
                command.CommandText = " INSERT INTO lottery_winning_bet " +
                                      "        (bet_id,         winning_amt, active, claim_status, num1,  num2,  num3,  num4,  num5,  num6)" +
                                      " VALUES (@lotteryBetID,  @winningAmt, true,   @claimStatus, @num1, @num2, @num3, @num4, @num5, @num6)";
                command.Parameters.AddWithValue("@lotteryBetID", lotteryWinningBet.GetLotteryBetId());
                command.Parameters.AddWithValue("@winningAmt", lotteryWinningBet.GetWinningAmount());
                command.Parameters.AddWithValue("@claimStatus", lotteryWinningBet.IsClaimed());
                command.Parameters.AddWithValue("@num1", lotteryWinningBet.GetNum1());
                command.Parameters.AddWithValue("@num2", lotteryWinningBet.GetNum2());
                command.Parameters.AddWithValue("@num3", lotteryWinningBet.GetNum3());
                command.Parameters.AddWithValue("@num4", lotteryWinningBet.GetNum4());
                command.Parameters.AddWithValue("@num5", lotteryWinningBet.GetNum5());
                command.Parameters.AddWithValue("@num6", lotteryWinningBet.GetNum6());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg10"), lotteryWinningBet.GetLotteryBetId()));
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
                                      "   AND b.game_cd = @game_cd " +
                                      "   AND a.claim_status = true";
                command.Parameters.AddWithValue("@game_cd", (int) gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["WINNING_AMOUNT"].ToString()))
                            {
                                return double.Parse(reader["WINNING_AMOUNT"].ToString());
                            }
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
                                      "   AND MONTH(target_draw_date) = MONTH(NOW()) " +
                                      "   AND YEAR(target_draw_date) = YEAR(NOW()) " + 
                                      "   AND a.claim_status = true";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["WINNING_AMOUNT"].ToString()))
                            {
                                return double.Parse(reader["WINNING_AMOUNT"].ToString());
                            }
                        }
                    }
                }
            }
            return 0.00;
        }
        public void RemoveLotteryWinningBet(long Id)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_winning_bet SET active = 0 " +
                                      " WHERE ID = @id";
                command.Parameters.AddWithValue("@id", OleDbType.BigInt).Value = (long)Id;
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg11"), Id));
                }
                transaction.Commit();
            }
        }
        public void RemoveLotteryWinningBetByBetId(long betId)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_winning_bet SET active = 0 " +
                                      " WHERE bet_id = @id";
                command.Parameters.AddWithValue("@bet_id", OleDbType.BigInt).Value = (long)betId;
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg11"), betId));
                }
                transaction.Commit();
            }
        }
        public List<LotteryWinningBet> GetLotteryWinningBet(GameMode gameMode, DateTime sinceWhen)
        {
            List<LotteryWinningBet> lotteryWinningBetArr = new List<LotteryWinningBet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT a.*, " +
                                      "       b.ID as [b_ID], " +
                                      "       b.bet_id as [b_bet_id], " +
                                      "	      b.winning_amt as [b_winning_amt], " +
                                      "	      b.active as [b_active], " +
                                      "	      b.num1 as [b_num1], " +
                                      "	      b.num2 as [b_num2], " +
                                      "	      b.num3 as [b_num3], " +
                                      "	      b.num4 as [b_num4], " +
                                      "	      b.num5 as [b_num5], " +
                                      "	      b.num6 as [b_num6], " +
                                      "	      b.claim_status as [b_claim_status], " +
                                      "	      c.ID as [c_ID], " +
                                      "	      c.outlet_cd as [c_outlet_cd], " +
                                      "	      c.description as [c_description] " +
                                      "  FROM ((lottery_bet a " +
                                      "  LEFT OUTER JOIN lottery_winning_bet b " +
                                      "    ON a.ID = b.bet_Id) " +
                                      "  LEFT OUTER JOIN lottery_outlet c " +
                                      "    ON a.outlet_cd = c.outlet_cd) " +
                                      " WHERE a.game_cd = @game_cd " +
                                      "   AND a.target_draw_date >= CDATE(@sinceWhen) " +
                                      "   AND a.active = true " +
                                      "   AND b.active = true " +
                                      //"   AND c.active = true " +
                                      "   AND b.winning_amt > 0";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@sinceWhen", sinceWhen.Date.ToString());
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LotteryWinningBetSetup lotteryWinningBet = new LotteryWinningBetSetup();
                        lotteryWinningBet.ID = long.Parse(reader["b_ID"].ToString());
                        lotteryWinningBet.TargetDrawDate = DateTime.Parse(reader["target_draw_date"].ToString());
                        lotteryWinningBet.LotteryBetId = long.Parse(reader["b_bet_id"].ToString());
                        lotteryWinningBet.WinningAmount = double.Parse(reader["b_winning_amt"].ToString());
                        lotteryWinningBet.Num1 = int.Parse(reader["num1"].ToString());
                        lotteryWinningBet.Num2 = int.Parse(reader["num2"].ToString());
                        lotteryWinningBet.Num3 = int.Parse(reader["num3"].ToString());
                        lotteryWinningBet.Num4 = int.Parse(reader["num4"].ToString());
                        lotteryWinningBet.Num5 = int.Parse(reader["num5"].ToString());
                        lotteryWinningBet.Num6 = int.Parse(reader["num6"].ToString());
                        lotteryWinningBet.ClaimStatus = bool.Parse(reader["b_claim_status"].ToString());
                        lotteryWinningBet.OutletCd = int.Parse(reader["c_outlet_cd"].ToString());
                        lotteryWinningBet.OutletDesc = reader["c_description"].ToString();
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["b_num1"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["b_num2"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["b_num3"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["b_num4"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["b_num5"].ToString()));
                        lotteryWinningBet.AddWinningNumber(int.Parse(reader["b_num6"].ToString()));
                        lotteryWinningBetArr.Add(lotteryWinningBet);
                    }
                }
            }
            return lotteryWinningBetArr;
        }
        public void UpdateClaimStatus(LotteryWinningBet winBet)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_winning_bet SET claim_status = @claim_status " +
                                      " WHERE ID = @id AND active = true";
                command.Parameters.AddWithValue("@claim_status", winBet.IsClaimed());
                command.Parameters.AddWithValue("@id", winBet.GetID());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_dao_impl_msg12"), winBet.GetID()));
                }
                transaction.Commit();
            }
        }
        public int[] GetWinningBetNumbersTally(GameMode gameMode)
        {
            int[] result = new int[6] { 0,0,0,0,0,0};
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT SUM(IIF(b.num1 > 0 AND b.num2=0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num1], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num2], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num3], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5=0 AND b.num6=0,1,0)) AS [num4], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6=0,1,0)) AS [num5], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6>0,1,0)) AS [num6] " +
                                      "   FROM lottery_bet a " +
                                      "  INNER JOIN lottery_winning_bet b " +
                                      "     ON a.ID = b.bet_ID " +
                                      "  WHERE a.game_cd = @game_cd " +
                                      "    AND a.active = true " +
                                      "    AND b.active = true ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if(!String.IsNullOrWhiteSpace(reader["num1"].ToString()))
                            {
                                result[0] = int.Parse(reader["num1"].ToString());
                                result[1] = int.Parse(reader["num2"].ToString());
                                result[2] = int.Parse(reader["num3"].ToString());
                                result[3] = int.Parse(reader["num4"].ToString());
                                result[4] = int.Parse(reader["num5"].ToString());
                                result[5] = int.Parse(reader["num6"].ToString());
                            }
                        }
                    }
                }
            }
            return result;
        }
        public int[] GetMinMaxWinningBetAmount(GameMode gameMode)
        {
            int[] result = new int[2] { 0, 0 };
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT MIN(b.winning_amt) as [min_won], " +
                                      "        MAX(b.winning_amt) as [max_won] " +
                                      "  FROM lottery_bet a " +
                                      " INNER JOIN lottery_winning_bet b " +
                                      "    ON a.ID = b.bet_ID " +
                                      " WHERE a.game_cd = @game_cd " +
                                      "   AND a.active = true " +
                                      "   AND b.active = true " +
                                      "   AND b.winning_amt > 0";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if(!String.IsNullOrWhiteSpace(reader["min_won"].ToString()))
                            {
                                result[0] = int.Parse(reader["min_won"].ToString());
                                result[1] = int.Parse(reader["max_won"].ToString());
                            }
                        }
                    }
                }
            }
            return result;
        }
        public List<String[]> GetDaysOfWeekTally(List<int> gameCodes)
        {
            List<String[]> resultList = new List<string[]>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "  SELECT FORMAT(a.target_draw_date,\"dddd\") as [day_of_week],      " +
                                      "  		Weekday(a.target_draw_date),                               " +
                                      "  		SUM(a.bet_amt) as [total_spending],                        " +
                                      "  		SUM(IIF(b.num1 > 0 AND b.num2=0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num1], " +
                                      "  	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num2],  " +
                                      "  	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num3],  " +
                                      "  	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5=0 AND b.num6=0,1,0)) AS [num4],  " +
                                      "  	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6=0,1,0)) AS [num5],  " +
                                      "  	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6>0,1,0)) AS [num6]   " +
                                      "    FROM lottery_bet a                     " +
                                      "   INNER JOIN lottery_winning_bet b        " +
                                      "      ON a.ID = b.bet_ID                   " +
                                      "   WHERE a." + GetMultipleGameCodeSQLPredicate(gameCodes) + 
                                      "     AND a.active = true                   " +
                                      "     AND b.active = true               " +
                                      "    GROUP BY FORMAT(a.target_draw_date,\"dddd\"), Weekday(a.target_draw_date)    " +
                                      "    ORDER BY 2 ASC   ";

                //command.Parameters.AddWithValue("@game_cd", GetMultipleGameCodeSQLPredicate(gameCodes));
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(reader["num1"].ToString()))
                            {
                                String[] result = new String[8] { "", "", "0", "0", "0", "0", "0", "0" };
                                result[0] = reader["day_of_week"].ToString();
                                result[1] = reader["total_spending"].ToString();
                                result[2] = reader["num1"].ToString();
                                result[3] = reader["num2"].ToString();
                                result[4] = reader["num3"].ToString();
                                result[5] = reader["num4"].ToString();
                                result[6] = reader["num5"].ToString();
                                result[7] = reader["num6"].ToString();
                                resultList.Add(result);
                            }
                        }
                    }
                }
            }
            return resultList;
        }
        public List<String[]> GetPickGeneratorsTally(List<int> gameCodes)
        {
            List<String[]> resultList = new List<string[]>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT a.seqgencd, s.description,                                                                         " +
                                      " 	   SUM(a.bet_amt) as [total_spending],                                                                 " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2=0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num1]," +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num2], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num3], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5=0 AND b.num6=0,1,0)) AS [num4], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6=0,1,0)) AS [num5], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6>0,1,0)) AS [num6]  " +
                                      "   FROM ((lottery_bet a                                                                                      " +
                                      "  INNER JOIN lottery_winning_bet b                                                                         " +
                                      "     ON a.ID = b.bet_ID)                                                                                   " +
                                      "   LEFT OUTER JOIN lottery_seq_gen s                                                                        " +
                                      "     ON a.seqgencd = s.seqgencd)                                                                             " +
                                      "  WHERE a." + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "    AND a.active = true                                                                                    " +
                                      "    AND b.active = true                                                                                    " +
                                      "  GROUP BY a.seqgencd, s.description                                                                      " +
                                      "  ORDER BY 2 ASC                                                                                          ";

                //command.Parameters.AddWithValue("@game_cd", GetMultipleGameCodeSQLPredicate(gameCodes));
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(reader["num1"].ToString()))
                            {
                                String[] result = new String[8] { "", "", "0", "0", "0", "0", "0", "0" };
                                result[0] = reader["description"].ToString();
                                result[1] = reader["total_spending"].ToString();
                                result[2] = reader["num1"].ToString();
                                result[3] = reader["num2"].ToString();
                                result[4] = reader["num3"].ToString();
                                result[5] = reader["num4"].ToString();
                                result[6] = reader["num5"].ToString();
                                result[7] = reader["num6"].ToString();
                                resultList.Add(result);
                            }
                        }
                    }
                }
            }
            return resultList;
        }
        public List<String[]> GetOutletTally(List<int> gameCodes)
        {
            List<String[]> resultList = new List<string[]>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT a.outlet_cd, o.description,                                                                        " +
                                      " 	   SUM(a.bet_amt) as [total_spending],                                                                  " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2=0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num1], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3=0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num2], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4=0 AND b.num5=0 AND b.num6=0,1,0)) AS [num3], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5=0 AND b.num6=0,1,0)) AS [num4], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6=0,1,0)) AS [num5], " +
                                      " 	   SUM(IIF(b.num1 > 0 AND b.num2>0 AND b.num3>0 AND b.num4>0 AND b.num5>0 AND b.num6>0,1,0)) AS [num6]  " +
                                      "   FROM ((lottery_bet a                                                                                      " +
                                      "  INNER JOIN lottery_winning_bet b                                                                         " +
                                      "     ON a.ID = b.bet_ID)                                                                                    " +
                                      "   LEFT OUTER JOIN lottery_outlet o                                                                        " +
                                      "     ON a.outlet_cd = o.outlet_cd)                                                                          " +
                                      "  WHERE a." + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "    AND a.active = true                                                                                    " +
                                      "    AND b.active = true                                                                                    " +
                                      "  GROUP BY a.outlet_cd, o.description                                                                      " +
                                      "  ORDER BY 2 ASC  ";

                //command.Parameters.AddWithValue("@game_cd", GetMultipleGameCodeSQLPredicate(gameCodes));
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(reader["num1"].ToString()))
                            {
                                String[] result = new String[8] { "", "0", "0", "0", "0", "0", "0", "0" };
                                result[0] = reader["description"].ToString();
                                result[1] = reader["total_spending"].ToString();
                                result[2] = reader["num1"].ToString();
                                result[3] = reader["num2"].ToString();
                                result[4] = reader["num3"].ToString();
                                result[5] = reader["num4"].ToString();
                                result[6] = reader["num5"].ToString();
                                result[7] = reader["num6"].ToString();
                                resultList.Add(result);
                            }
                        }
                    }
                }
            }
            return resultList;
        }
        public List<String[]> GetWinningBetDigitTally(List<int> gameCodes)
        {
            List<String[]> resultList = new List<string[]>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "  SELECT NUM,SUM(HIT) AS [HIT2]                      " +
                                      "  FROM (                                            " +
                                      "  	SELECT a.num1 AS [NUM],COUNT(a.num1) AS [HIT]        " +
                                      "  	FROM lottery_winning_bet a                       " +
                                      "  	LEFT OUTER JOIN lottery_bet b ON a.bet_id = b.ID " +
                                      "  	WHERE " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "  		AND a.active = true                          " +
                                      "  		AND b.active = true                          " +
                                      "  	GROUP BY a.num1,2                                  " +
                                      "  	                                                 " +
                                      "  	UNION                                            " +
                                      "  	                                                 " +
                                      "  	SELECT a.num2 AS [NUM],COUNT(a.num2) AS [HIT]        " +
                                      "  	FROM lottery_winning_bet a                       " +
                                      "  	LEFT OUTER JOIN lottery_bet b ON a.bet_id = b.ID " +
                                      "  	WHERE " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "  		AND a.active = true                          " +
                                      "  		AND b.active = true                          " +
                                      "  	GROUP BY a.num2,2                                  " +
                                      "  	                                                 " +
                                      "  	UNION                                            " +
                                      "  	                                                 " +
                                      "  	SELECT a.num3 AS [NUM],COUNT(a.num3) AS [HIT]        " +
                                      "  	FROM lottery_winning_bet a                       " +
                                      "  	LEFT OUTER JOIN lottery_bet b ON a.bet_id = b.ID " +
                                      "  	WHERE " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "  		AND a.active = true                          " +
                                      "  		AND b.active = true                          " +
                                      "  	GROUP BY a.num3,2                                  " +
                                      "  	                                                 " +
                                      "  	UNION                                            " +
                                      "  	                                                 " +
                                      "  	SELECT a.num4 AS [NUM],COUNT(a.num4) AS [HIT]        " +
                                      "  	FROM lottery_winning_bet a                       " +
                                      "  	LEFT OUTER JOIN lottery_bet b ON a.bet_id = b.ID " +
                                      "  	WHERE " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "  		AND a.active = true                          " +
                                      "  		AND b.active = true                          " +
                                      "  	GROUP BY a.num4,2                                  " +
                                      "  	                                                 " +
                                      "  	UNION                                            " +
                                      "  	                                                 " +
                                      "  	SELECT a.num5 AS [NUM],COUNT(a.num5) AS [HIT]        " +
                                      "  	FROM lottery_winning_bet a                       " +
                                      "  	LEFT OUTER JOIN lottery_bet b ON a.bet_id = b.ID " +
                                      "  	WHERE " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "  		AND a.active = true                          " +
                                      "  		AND b.active = true                          " +
                                      "  	GROUP BY a.num5,2                                  " +
                                      "  	                                                 " +
                                      "  	UNION                                            " +
                                      "  	                                                 " +
                                      "  	SELECT a.num6 AS [NUM],COUNT(a.num6) AS [HIT]        " +
                                      "  	FROM lottery_winning_bet a                       " +
                                      "  	LEFT OUTER JOIN lottery_bet b ON a.bet_id = b.ID " +
                                      "  	WHERE " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                      "  		AND a.active = true                          " +
                                      "  		AND b.active = true                          " +
                                      "  	GROUP BY a.num6,2                                  " +
                                      "  	)                                                " +
                                      "  WHERE NUM > 0                                     " +
                                      "  GROUP BY NUM                                " +
                                      "  ORDER BY 2 DESC,1 ASC                         ";
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(reader["NUM"].ToString()))
                            {
                                String[] result = new String[2] { "0", "0"};
                                result[0] = reader["NUM"].ToString();
                                result[1] = reader["HIT2"].ToString();
                                resultList.Add(result);
                            }
                        }
                    }
                }
            }
            return resultList;
        }

    }
}
