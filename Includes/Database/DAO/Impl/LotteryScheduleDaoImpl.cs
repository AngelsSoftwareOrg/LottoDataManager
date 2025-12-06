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
    public class LotteryScheduleDaoImpl : LotteryDaoImplCommon, LotteryScheduleDao
    {
        private static LotteryScheduleDaoImpl lotteryScheduleDaoImpl;
        private LotteryScheduleDaoImpl() { }
        public static LotteryScheduleDao GetInstance()
        {
            if(lotteryScheduleDaoImpl == null)
            {
                lotteryScheduleDaoImpl = new LotteryScheduleDaoImpl();
            }
            return lotteryScheduleDaoImpl;
        }
        public LotterySchedule GetLotterySchedule(GameMode gameMode)
        {
            using(OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using(OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_schedule WHERE game_cd = ? AND active = true", conn)) {
                command.Parameters.Add("game_cd", OleDbType.Integer).Value = gameMode;
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return GetModel(reader);
                    }
                }
            }
            return null;
        }
        public void RemoveLotterySchedule(LotterySchedule lsched)
        {
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE lottery_schedule SET active = false " +
                                      " WHERE ID = @id AND game_cd = @game_cd AND active = true";
                command.Parameters.Add("@id", OleDbType.Integer).Value = lsched.GetID();
                command.Parameters.Add("@game_cd", OleDbType.Integer).Value = (int)lsched.GetGameMode();
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_sched_com_impl_msg1"), lsched.GetID()));
                }
                transaction.Commit();
            }
        }
        public int InsertLotterySchedule(LotterySchedule lsched)
        {
            int modified = 0;
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO `lottery_schedule` " +
                                      "             (`game_cd`, `active`, `mon`, `tues`, `wed`, `thurs`, `fri`, `sat`, `sun`) " +
                                      "         VALUES " +
                                      "             (@game_cd, true, @isMon, @isTue, @isWed, @isThu, @isFri, @isSat, @isSun) ";
                command.Parameters.Add("@game_cd", OleDbType.Integer).Value = (int)lsched.GetGameMode();
                command.Parameters.Add("@isMon", OleDbType.Boolean).Value = lsched.IsMonday();
                command.Parameters.Add("@isTue", OleDbType.Boolean).Value = lsched.IsTuesday();
                command.Parameters.Add("@isWed", OleDbType.Boolean).Value = lsched.IsWednesday();
                command.Parameters.Add("@isThu", OleDbType.Boolean).Value = lsched.IsThursday();
                command.Parameters.Add("@isFri", OleDbType.Boolean).Value = lsched.IsFriday();
                command.Parameters.Add("@isSat", OleDbType.Boolean).Value = lsched.IsSaturday();
                command.Parameters.Add("@isSun", OleDbType.Boolean).Value = lsched.IsSunday();
                command.Connection = conn;
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    transaction.Rollback();
                    throw new Exception(String.Format(ResourcesUtils.GetMessage("lot_sched_com_impl_msg1"), lsched.GetID()));
                }
                else
                {
                    transaction.Commit();
                    modified = base.GetLastInsertedID(command);
                }
            }
            return modified;
        }
        private LotterySchedule GetModel(OleDbDataReader reader)
        {
            LotteryScheduleSetup lotterySched = new LotteryScheduleSetup();
            lotterySched.Monday = Boolean.Parse(reader["mon"].ToString());
            lotterySched.Tuesday = Boolean.Parse(reader["tues"].ToString());
            lotterySched.Wednesday = Boolean.Parse(reader["wed"].ToString());
            lotterySched.Thursday = Boolean.Parse(reader["thurs"].ToString());
            lotterySched.Friday = Boolean.Parse(reader["fri"].ToString());
            lotterySched.Saturday = Boolean.Parse(reader["sat"].ToString());
            lotterySched.Sunday = Boolean.Parse(reader["sun"].ToString());
            lotterySched.GameMode = ClassReflectionUtil.FindGameMode(int.Parse(reader["game_cd"].ToString()));
            lotterySched.ID= int.Parse(reader["ID"].ToString());
            return lotterySched;
        }
    }
}
