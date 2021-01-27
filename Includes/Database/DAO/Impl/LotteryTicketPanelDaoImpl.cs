using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Database.DAO
{
    public class LotteryTicketPanelDaoImpl : LotteryTicketPanelDao
    {
        private static LotteryTicketPanelDaoImpl lotteryTicketPanelDaoImpl;

        private LotteryTicketPanelDaoImpl() { }

        public static LotteryTicketPanelDao GetInstance()
        {
            if (lotteryTicketPanelDaoImpl == null)
            {
                lotteryTicketPanelDaoImpl = new LotteryTicketPanelDaoImpl();
            }
            return lotteryTicketPanelDaoImpl;
        }

        public LotteryTicketPanel GetLotteryTicketPanel(GameMode gameMode)
        {
            LotteryTicketPanelSetup lotteryTicketPanel = new LotteryTicketPanelSetup();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM lottery_ticket_panel WHERE game_cd = ? AND active = true;", conn))
            {
                command.Parameters.AddWithValue("game_cd", gameMode);
                conn.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotteryTicketPanel.Cols = int.Parse(reader["cols"].ToString());
                        lotteryTicketPanel.Rows = int.Parse(reader["rows"].ToString());
                        lotteryTicketPanel.Max = int.Parse(reader["max"].ToString());
                        lotteryTicketPanel.Min = int.Parse(reader["min"].ToString());
                        lotteryTicketPanel.GameDigitCount = int.Parse(reader["game_digit"].ToString());
                        lotteryTicketPanel.NumberDirection = ClassReflectionUtil.ConvertToNumberDirection(int.Parse(reader["num_dir"].ToString()));
                    }
                }
            }
            return lotteryTicketPanel;
        }
    }
}
