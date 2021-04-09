using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes.Generator;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class LotteryBetDaoImpl : LotteryDaoImplCommon, LotteryBetDao
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
                command.CommandText = " SELECT a.*,  " +
                                        "       (   IIF(a.num1 IN(b.num1, b.num2, b.num3, b.num4, b.num5, b.num6), 1, 0) +   " +
                                        "           IIF(a.num2 IN(b.num1, b.num2, b.num3, b.num4, b.num5, b.num6), 1, 0) +   " +
                                        "           IIF(a.num3 IN(b.num1, b.num2, b.num3, b.num4, b.num5, b.num6), 1, 0) +   " +
                                        "           IIF(a.num4 IN(b.num1, b.num2, b.num3, b.num4, b.num5, b.num6), 1, 0) +   " +
                                        "           IIF(a.num5 IN(b.num1, b.num2, b.num3, b.num4, b.num5, b.num6), 1, 0) +   " +
                                        "           IIF(a.num6 IN(b.num1, b.num2, b.num3, b.num4, b.num5, b.num6), 1, 0)     " +
                                        "       ) AS[match_cnt],  " +
                                        "        o.ID AS[O_ID],  " +
                                        "        o.outlet_cd AS[O_OUTLET_CD],  " +
                                        "        o.description AS[O_DESCRIPTION], " +
                                        "        s.ID AS[SEQ_ID],  " +
                                        "        s.seqgencd AS[SEQ_SEQGENCD],  " +
                                        "        s.description AS[SEQ_DESCFRIPTION] " +
                                        "  FROM (((lottery_bet a  " +
                                        "  LEFT OUTER JOIN draw_results b  " +
                                        "    ON a.target_draw_date = b.draw_date)  " +
                                        "  LEFT OUTER JOIN lottery_outlet o  " +
                                        "    ON o.outlet_cd = a.outlet_cd) " +
                                        "  LEFT OUTER JOIN lottery_seq_gen s " +
                                        "   ON a.seqgencd = s.seqgencd) " +
                                        " WHERE a.game_cd = @game_cd " +
                                        "   AND a.game_cd = b.game_cd  " +
                                        "   AND a.target_draw_date >= CDATE(@sinceWhen)  " +
                                        "   AND a.active = true  " +
                                        //"   AND o.active = true " +
                                        " UNION  " +
                                        " SELECT a.*,  " +
                                        "        0, " +
                                        "        o.ID AS[O_ID], " +
                                        "        o.outlet_cd AS[O_OUTLET_CD], " +
                                        "        o.description AS[O_DESCRIPTION], " +
                                        "        s.ID AS[SEQ_ID],  " +
                                        "        s.seqgencd AS[SEQ_SEQGENCD],  " +
                                        "        s.description AS[SEQ_DESCFRIPTION] " +
                                        "   FROM ((lottery_bet a  " +
                                        "   LEFT OUTER JOIN lottery_outlet o " +
                                        "     ON o.outlet_cd = a.outlet_cd) " +
                                        "   LEFT OUTER JOIN lottery_seq_gen s " +
                                        "     ON a.seqgencd = s.seqgencd) " +
                                        "  WHERE a.game_cd = @game_cd " +
                                        "    AND a.target_draw_date >= CDATE(@sinceWhen)  " +
                                        "    AND a.active = true  " +
                                        //"    AND o.active = true " +
                                        "    AND (SELECT DISTINCT b.draw_date FROM draw_results b  " +
                                        "   	   WHERE a.target_draw_date = b.draw_date  " +
                                        "            AND a.game_cd = b.game_cd) IS NULL  " +
                                        "  ORDER BY a.target_draw_date DESC ";
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = gameMode;
                command.Parameters.AddWithValue("@sinceWhen", OleDbType.DBDate).Value = sinceWhen.Date.ToString();
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = gameMode;
                command.Parameters.AddWithValue("@sinceWhen", OleDbType.DBDate).Value = sinceWhen.Date.ToString();
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
        public List<LotteryBet> GetLotteryBets(GameMode gameMode, DateTime betDrawDate)
        {
            List<LotteryBet> lotteryBet = new List<LotteryBet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM lottery_bet " +
                                      " WHERE game_cd = @game_cd " +
                                      "   AND target_draw_date = CDATE(@sinceWhen) " +
                                      "   AND active = true " +
                                      " ORDER BY target_draw_date DESC";
                command.Parameters.AddWithValue("@game_cd", OleDbType.Integer).Value = gameMode;
                command.Parameters.AddWithValue("@sinceWhen", OleDbType.DBDate).Value = betDrawDate.Date.ToString();
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
                command.CommandText = "SELECT a.* " +
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
                                      "   AND outlet_cd = @outletCd " +
                                      "   AND seqgencd = @seqgencd " +
                                      "   AND ( " +
                                      "     @num1 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num2 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num3 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num4 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num5 IN(num1, num2, num3, num4, num5, num6) " +
                                      " AND @num6 IN(num1, num2, num3, num4, num5, num6)) ";
                command.Parameters.AddWithValue("@game_cd", lotteryBet.GetGameCode());
                command.Parameters.AddWithValue("@draw_date", lotteryBet.GetTargetDrawDate().Date.ToString());
                command.Parameters.AddWithValue("@outletCd", lotteryBet.GetOutletCode());
                command.Parameters.AddWithValue("@seqgencd", lotteryBet.GetLotterySequenceGenerator().GetSeqGenCode());
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
                                      "                          bet_amt,active,outlet_cd,seqgencd, " +
                                      "                          num1,num2,num3,num4,num5,num6) " +
                                      " VALUES (@game_cda, CDATE(@target_draw_datea), " +
                                      "         @bet_amta, 1, @outlet_cda, @seqgencda, " +
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
                    command.Parameters.AddWithValue("@seqgencda", item.GetLotterySequenceGenerator().GetSeqGenCode());
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
        public int InsertLotteryBet(LotteryBet lotteryBet)
        {
            int modified = 0;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO lottery_bet (game_cd,target_draw_date, " +
                                      "                          bet_amt,active,outlet_cd,seqgencd, " +
                                      "                          num1,num2,num3,num4,num5,num6) " +
                                      " VALUES (@game_cda, CDATE(@target_draw_datea), " +
                                      "         @bet_amta, 1, @outlet_cda, @seqgencda, " +
                                      "         @num1a, @num2a, @num3a, @num4a, @num5a, @num6a) ";
                command.Connection = conn;
                command.Parameters.AddWithValue("@game_cda", lotteryBet.GetGameCode());
                command.Parameters.AddWithValue("@target_draw_datea", lotteryBet.GetTargetDrawDate().Date.ToString());
                command.Parameters.AddWithValue("@bet_amta", lotteryBet.GetBetAmount());
                command.Parameters.AddWithValue("@outlet_cda", lotteryBet.GetOutletCode());
                command.Parameters.AddWithValue("@seqgencda", lotteryBet.GetLotterySequenceGenerator().GetSeqGenCode());
                command.Parameters.AddWithValue("@num1a", lotteryBet.GetNum1());
                command.Parameters.AddWithValue("@num2a", lotteryBet.GetNum2());
                command.Parameters.AddWithValue("@num3a", lotteryBet.GetNum3());
                command.Parameters.AddWithValue("@num4a", lotteryBet.GetNum4());
                command.Parameters.AddWithValue("@num5a", lotteryBet.GetNum5());
                command.Parameters.AddWithValue("@num6a", lotteryBet.GetNum6());
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
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
                    modified = base.GetLastInsertedID(command);
                }
            }
            return modified;
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
            if (ColumnExists(reader,"O_OUTLET_CD")){
                bet.MatchNumCount = int.Parse(reader["match_cnt"].ToString());
            }
            if (ColumnExists(reader, "O_OUTLET_CD"))
            {
                LotteryOutletSetup o = new LotteryOutletSetup()
                {
                    Id = int.Parse(reader["O_ID"].ToString()),
                    OutletCode = int.Parse(reader["O_OUTLET_CD"].ToString()),
                    Description = reader["O_DESCRIPTION"].ToString()
                };
                bet.LotteryOutlet = o;
            }
            if (ColumnExists(reader, "SEQ_SEQGENCD"))
            {
                LotterySequenceGeneratorSetup lotterySeqGen = new LotterySequenceGeneratorSetup();
                lotterySeqGen.ID = int.Parse(reader["SEQ_ID"].ToString());
                lotterySeqGen.SeqGenCode = int.Parse(reader["SEQ_SEQGENCD"].ToString());
                lotterySeqGen.Description = reader["SEQ_DESCFRIPTION"].ToString();
                bet.LotterySeqGen = lotterySeqGen;
            }
            if (ColumnExists(reader, "WIN_BET_ID"))
            {
                LotteryWinningBetSetup winbet = new LotteryWinningBetSetup();
                winbet.ClaimStatus = bool.Parse(reader["WIN_BET_CLAIM_STATUS"].ToString());
                winbet.ID = long.Parse(reader["WIN_BET_ID"].ToString());
                winbet.LotteryBetId= long.Parse(reader["WIN_BET_BET_ID"].ToString());
                winbet.Num1 = int.Parse(reader["WIN_BET_NUM1"].ToString());
                winbet.Num2 = int.Parse(reader["WIN_BET_NUM2"].ToString());
                winbet.Num3 = int.Parse(reader["WIN_BET_NUM3"].ToString());
                winbet.Num4 = int.Parse(reader["WIN_BET_NUM4"].ToString());
                winbet.Num5 = int.Parse(reader["WIN_BET_NUM5"].ToString());
                winbet.Num6 = int.Parse(reader["WIN_BET_NUM6"].ToString());
                winbet.WinningAmount = double.Parse(reader["WIN_BET_WIN_AMT"].ToString());
                bet.LotteryWinningBet = winbet;
            }
            bet.SortNumbers();
            return bet;
        }
        public void RemoveLotteryBet(long id)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_bet SET active = 0 " +
                                      " WHERE ID = @id";
                command.Parameters.AddWithValue("@id", OleDbType.BigInt).Value = (long)id;
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception("Removing Lottery Bet ID: " + id + " | Error updating data into Lottery Bet Database! ");
                }
                transaction.Commit();
            }
        }
        public double GetTotalAmountBetted(GameMode gameMode, DateTime dateFrom, DateTime dateTo)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT SUM(bet_amt) as [total_bet_amt] " +
                                      "  FROM lottery_bet " +
                                      " WHERE active = true " +
                                      "   AND game_cd = @game_cd " +
                                      "  AND target_draw_date BETWEEN CDATE(@from) AND CDATE(@to) ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@from", dateFrom.Date.ToString());
                command.Parameters.AddWithValue("@to", dateTo.Date.ToString());
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["total_bet_amt"].ToString()))
                            {
                                return double.Parse(reader["total_bet_amt"].ToString());
                            }
                        }
                    }
                }
            }
            return 0.00;
        }
        public int GetTotalBetMade(GameMode gameMode)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(ID) AS[total_bet] " +
                                      "  FROM lottery_bet " +
                                      " WHERE game_cd = @game_cd " +
                                      "   AND active = true";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["total_bet"].ToString()))
                            {
                                return int.Parse(reader["total_bet"].ToString());
                            }
                        }
                    }
                }
            }
            return 0;
        }
        public int[] GetTotalNumberOfClaims(GameMode gameMode)
        {
            int[] result = new int[2];
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText =" SELECT SUM(IIF(b.claim_status = true, 1, 0)) AS[claimed_count], " +
                                     "        SUM(IIF(b.claim_status = false, 1, 0)) AS[not_claimed_count] " +
                                     "   FROM lottery_bet a " +
                                     "  INNER JOIN lottery_winning_bet b " +
                                     "     ON a.ID = b.bet_ID " +
                                     "  WHERE a.game_cd = @game_cd " +
                                     "    AND a.active = true " +
                                     "    AND b.active = true " +
                                     "    AND b.winning_amt > 0 ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["claimed_count"].ToString()))
                            {
                                result[0] = int.Parse(reader["claimed_count"].ToString());
                                result[1] = int.Parse(reader["not_claimed_count"].ToString());
                            }
                        }
                    }
                }
            }
            return result;
        }
        public List<LotteryBet> GetAllRedeemedClaims(GameMode gameMode, bool isGetClaimedStatus)
        {
            List<LotteryBet> result = new List<LotteryBet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT a.*, " +
                                     "		   b.ID AS[WIN_BET_ID], b.bet_id AS[WIN_BET_BET_ID], b.winning_amt AS[WIN_BET_WIN_AMT],    " +
                                     "		   b.num1 AS[WIN_BET_NUM1],b.num2 AS[WIN_BET_NUM2],b.num3 AS[WIN_BET_NUM3],                " +
                                     "		   b.num4 AS[WIN_BET_NUM4],b.num5 AS[WIN_BET_NUM5],b.num6 AS[WIN_BET_NUM6],                " +
                                     "		   b.claim_status AS[WIN_BET_CLAIM_STATUS]                                                 " +
                                     "   FROM lottery_bet a " +
                                     "  INNER JOIN lottery_winning_bet b " +
                                     "     ON a.ID = b.bet_ID " +
                                     "  WHERE a.game_cd = @game_cd " +
                                     "    AND a.active = true " +
                                     "    AND b.active = true " +
                                     "    AND b.winning_amt > 0 " +
                                     "    AND b.claim_status = @claim_status " +
                                     "  ORDER BY a.target_draw_date DESC";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@claim_status", isGetClaimedStatus);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(GetInstanceDeriveLotteryBetSetup(reader));
                        }
                    }
                }
            }
            return result;
        }
        public double[] GetTotalLuckyPickWinAndLoose(GameMode gameMode)
        {
            double[] result = new double[2];
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT SUM(b.winning_amt) AS [lp_win], " +
                                      "        SUM(a.bet_amt) AS [lp_loose] " +
                                      "   FROM lottery_bet a " +
                                      "  INNER JOIN lottery_winning_bet b " +
                                      "     ON a.ID = b.bet_ID " +
                                      "  WHERE a.game_cd = @game_cd " +
                                      "    AND a.active = true " +
                                      "    AND b.active = true " +
                                      "    AND a.seqgencd IN (@luckypick) ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@luckypick", (int)GeneratorType.LUCKY_PICK);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["lp_win"].ToString()))
                            {
                                result[0] = double.Parse(reader["lp_win"].ToString());
                                result[1] = double.Parse(reader["lp_loose"].ToString());
                            }
                        }
                    }
                }
            }
            return result;
        }
        public int GetTotalYearsOfBetting(GameMode gameMode)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT DATEDIFF('yyyy',a.min_date,a.max_date) AS YEARS_COUNT " +
                                      "FROM (SELECT MIN(target_draw_date) as [min_date]," +
                                      "             MAX (target_draw_date) as [max_date] " +
                                      "        FROM lottery_bet " +
                                      "       WHERE active = true " +
                                      "         AND game_cd = @game_cd) a ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["YEARS_COUNT"].ToString()))
                            {
                                return int.Parse(reader["YEARS_COUNT"].ToString());
                            }
                        }
                    }
                }
            }
            return 0;
        }
        public DateTime[] GetMinMaxYearsOfBetting(GameMode gameMode)
        {
            DateTime[] result = new DateTime[2];
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT a.min_date, a.max_date " +
                                      "FROM (SELECT MIN(target_draw_date) as [min_date]," +
                                      "             MAX (target_draw_date) as [max_date] " +
                                      "        FROM lottery_bet " +
                                      "       WHERE active = true " +
                                      "         AND game_cd = @game_cd) a ";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["min_date"].ToString()))
                            {
                                result[0] = DateTime.Parse(reader["min_date"].ToString());
                                result[1] = DateTime.Parse(reader["max_date"].ToString());
                            }
                        }
                    }
                }
            }
            return result;
        }
        public DateTime GetLastTimeWon(GameMode gameMode)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP 1 a.target_draw_date " +
                                      "  FROM lottery_bet a " +
                                      " INNER JOIN lottery_winning_bet b " +
                                      "    ON a.ID = b.bet_id " +
                                      " WHERE a.active = true " +
                                      "   AND b.active = true " +
                                      "   AND a.game_cd = @game_cd " +
                                      "   AND b.winning_amt > 0 " +
                                      " ORDER BY a.target_draw_date DESC ";

                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["target_draw_date"].ToString()))
                            {
                                return DateTime.Parse(reader["target_draw_date"].ToString());
                            }
                        }
                    }
                }
            }
            return DateTimeConverterUtils.GetYear2011();
        }
        public List<LotteryBet> GetLotteryBetsCurrentSeason(GameMode gameMode)
        {
            List<LotteryBet> lotteryBet = new List<LotteryBet>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT b.* " +
                                      "  FROM lottery_bet b " +
                                      "  WHERE b.game_cd = @game_cd1 " +
                                      "  AND b.active = true " +
                                      "  AND b.target_draw_date >= (SELECT TOP 1 a.draw_date " +
                                      "    FROM draw_results a " +
                                      "   WHERE a.game_cd = @game_cd2 " +
                                      "     AND a.draw_date > (SELECT TOP 1 d.draw_date " +
                                      "                          FROM draw_results d " +
                                      "                         WHERE d.winners > 0 " +
                                      "                           AND d.game_cd = @game_cd3 " +
                                      "                         ORDER BY d.draw_date DESC) " +
                                      "  ORDER BY a.draw_date ASC)";
                command.Parameters.AddWithValue("@game_cd1", gameMode);
                command.Parameters.AddWithValue("@game_cd2", gameMode);
                command.Parameters.AddWithValue("@game_cd3", gameMode);
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
        public double[] GetMonthlySpending(GameMode gameMode, int year)
        {
            double[] result = new double[13] {0,0,0,0,0,0,0,0,0,0,0,0,0};
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT SUM(IIF(MONTH(target_draw_date) = 1, bet_amt, 0)) AS [jan], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 2, bet_amt, 0)) AS [feb], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 3, bet_amt, 0)) AS [mar], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 4, bet_amt, 0)) AS [apr], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 5, bet_amt, 0)) AS [may], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 6, bet_amt, 0)) AS [jun], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 7, bet_amt, 0)) AS [jul], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 8, bet_amt, 0)) AS [aug], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 9, bet_amt, 0)) AS [sep], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 0, bet_amt, 0)) AS [oct], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 11, bet_amt, 0)) AS [nov], " +
                                      "        SUM(IIF(MONTH(target_draw_date) = 12, bet_amt, 0)) AS [dec], " +
                                      "        SUM(bet_amt) AS[annual] " +
                                      "   FROM lottery_bet " +
                                      "  WHERE game_cd = @game_cd " +
                                      "    AND YEAR(target_draw_date) = @year " +
                                      "    AND active = true";
                command.Parameters.AddWithValue("@game_cd", (int)gameMode);
                command.Parameters.AddWithValue("@year", year);
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["jan"].ToString()))
                            {
                                result[0] = double.Parse(reader["jan"].ToString());
                                result[1] = double.Parse(reader["feb"].ToString());
                                result[2] = double.Parse(reader["mar"].ToString());
                                result[3] = double.Parse(reader["apr"].ToString());
                                result[4] = double.Parse(reader["may"].ToString());
                                result[5] = double.Parse(reader["jun"].ToString());
                                result[6] = double.Parse(reader["jul"].ToString());
                                result[7] = double.Parse(reader["aug"].ToString());
                                result[8] = double.Parse(reader["sep"].ToString());
                                result[9] = double.Parse(reader["aug"].ToString());
                                result[10] = double.Parse(reader["nov"].ToString());
                                result[11] = double.Parse(reader["dec"].ToString());
                                result[12] = double.Parse(reader["annual"].ToString());
                            }
                        }
                    }
                }
            }
            return result;
        }
        public List<double[]> GetTabularAllBetsSpending(List<int> gameCodes)
        {
            List<double[]> resultList = new List<double[]>();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText =   " SELECT YEAR(target_draw_date) AS [year],                            " +
                                        " 	     SUM(IIF(MONTH(target_draw_date) = 1, bet_amt, 0)) AS [jan],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 2, bet_amt, 0)) AS [feb],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 3, bet_amt, 0)) AS [mar],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 4, bet_amt, 0)) AS [apr],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 5, bet_amt, 0)) AS [may],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 6, bet_amt, 0)) AS [jun],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 7, bet_amt, 0)) AS [jul],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 8, bet_amt, 0)) AS [aug],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 9, bet_amt, 0)) AS [sep],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 0, bet_amt, 0)) AS [oct],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 11, bet_amt, 0)) AS [nov], " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 12, bet_amt, 0)) AS [dec], " +
                                        "        SUM(bet_amt) AS[annual]                                      " +
                                        "  FROM lottery_bet                                                   " +
                                        " WHERE active = true                                                 " +
                                        "   AND " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                        " GROUP BY YEAR(target_draw_date)                                     " +
                                        " UNION                                                               " +
                                        " SELECT 0,                                                           " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 1, bet_amt, 0)) AS [jan],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 2, bet_amt, 0)) AS [feb],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 3, bet_amt, 0)) AS [mar],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 4, bet_amt, 0)) AS [apr],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 5, bet_amt, 0)) AS [may],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 6, bet_amt, 0)) AS [jun],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 7, bet_amt, 0)) AS [jul],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 8, bet_amt, 0)) AS [aug],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 9, bet_amt, 0)) AS [sep],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 0, bet_amt, 0)) AS [oct],  " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 11, bet_amt, 0)) AS [nov], " +
                                        "        SUM(IIF(MONTH(target_draw_date) = 12, bet_amt, 0)) AS [dec], " +
                                        "        SUM(bet_amt) AS[annual]                                      " +
                                        "  FROM lottery_bet                                                   " +
                                        " WHERE active = true                                                 " +
                                        "   AND " + GetMultipleGameCodeSQLPredicate(gameCodes) +
                                        " ORDER BY 1 DESC                                                     ";
                //command.Parameters.AddWithValue("@game_cd", GetMultipleGameCodeSQLPredicate(gameCodes));
                command.Connection = conn;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["jan"].ToString()))
                            {
                                double[] result = new double[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                                result[0] = double.Parse(reader["year"].ToString());
                                result[1] = double.Parse(reader["jan"].ToString());
                                result[2] = double.Parse(reader["feb"].ToString());
                                result[3] = double.Parse(reader["mar"].ToString());
                                result[4] = double.Parse(reader["apr"].ToString());
                                result[5] = double.Parse(reader["may"].ToString());
                                result[6] = double.Parse(reader["jun"].ToString());
                                result[7] = double.Parse(reader["jul"].ToString());
                                result[8] = double.Parse(reader["aug"].ToString());
                                result[9] = double.Parse(reader["sep"].ToString());
                                result[10] = double.Parse(reader["aug"].ToString());
                                result[11] = double.Parse(reader["nov"].ToString());
                                result[12] = double.Parse(reader["dec"].ToString());
                                result[13] = double.Parse(reader["annual"].ToString());
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
