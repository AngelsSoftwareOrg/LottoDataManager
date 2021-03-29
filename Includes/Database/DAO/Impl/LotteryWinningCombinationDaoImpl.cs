using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO
{
    public class LotteryWinningCombinationDaoImpl : LotteryDaoImplCommon, LotteryWinningCombinationDao
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
            LotteryWinningCombinationSetup lotteryWinningCombinationSetup = null;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_winning_combination WHERE game_cd = ? AND active = true;", conn))
            {
                command.Parameters.AddWithValue("game_cd", gameMode);
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryWinningCombinationSetup = GetModel(reader);
                    }
                }
            }
            return lotteryWinningCombinationSetup;
        }
        public void RemoveWinningCombination(LotteryWinningCombination lwc)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_winning_combination SET active = false " +
                                      " WHERE ID = @id AND game_cd = @game_cd AND active = true";
                command.Parameters.AddWithValue("@id", lwc.GetID());
                command.Parameters.AddWithValue("@game_cd", lwc.GetGameCode());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_win_com_impl_msg1"), lwc.GetID()));
                }
                transaction.Commit();
            }
        }
        public int InsertWinningCombination(LotteryWinningCombination lwc)
        {
            int modified = 0;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO `lottery_winning_combination` " +
                                      "          (`game_cd`, `active`, `match_0`, `match_1`, `match_2`, `match_3`, `match_4`, `match_5`, `match_6`) " +
                                      "  VALUES (@game_cd, true, @m0, @m1, @m2, @m3, @m4, @m5, @m6) ";
                command.Parameters.AddWithValue("@game_cd", (int)lwc.GetGameCode());
                command.Parameters.AddWithValue("@m0", lwc.GetMatch0());
                command.Parameters.AddWithValue("@m1", lwc.GetMatch1());
                command.Parameters.AddWithValue("@m2", lwc.GetMatch2());
                command.Parameters.AddWithValue("@m3", lwc.GetMatch3());
                command.Parameters.AddWithValue("@m4", lwc.GetMatch4());
                command.Parameters.AddWithValue("@m5", lwc.GetMatch5());
                command.Parameters.AddWithValue("@m6", lwc.GetMatch6());
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_win_com_impl_msg1"), lwc.GetID()));
                }
                else
                {
                    transaction.Commit();
                    modified = base.GetLastInsertedID(command);
                }
            }
            return modified;
        }
        private LotteryWinningCombinationSetup GetModel(OleDbDataReader reader)
        {
            LotteryWinningCombinationSetup setup = new LotteryWinningCombinationSetup();
            setup.ID = int.Parse(reader["ID"].ToString());
            setup.GameCode = ClassReflectionUtil.FindGameMode(int.Parse(reader["game_cd"].ToString()));
            setup.Match0 = double.Parse(reader["match_0"].ToString());
            setup.Match1 = double.Parse(reader["match_1"].ToString());
            setup.Match2 = double.Parse(reader["match_2"].ToString());
            setup.Match3 = double.Parse(reader["match_3"].ToString());
            setup.Match4 = double.Parse(reader["match_4"].ToString());
            setup.Match5 = double.Parse(reader["match_5"].ToString());
            setup.Match6 = double.Parse(reader["match_6"].ToString());
            return setup;
        }
    }
}
