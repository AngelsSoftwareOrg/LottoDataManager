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
    public class LotteryDaoImpl : LotteryDao
    {
        private static LotteryDaoImpl lotteryDaoImpl;
        private LotteryDaoImpl() { }
        public static LotteryDao GetInstance()
        {
            if (lotteryDaoImpl == null)
            {
                lotteryDaoImpl = new LotteryDaoImpl();
            }
            return lotteryDaoImpl;
        }
        public Lottery GetLottery(GameMode gameCode)
        {
            LotterySetup lotterySetup = new LotterySetup();
            using (OleDbConnection conn = DatabaseConnectionFactory.GetDataSource())
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM lottery WHERE game_cd = @game_cd AND active = true;";
                command.Parameters.AddWithValue("@game_cd", gameCode);
                command.Connection = conn;
                conn.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lotterySetup.GameCode = gameCode;
                        lotterySetup.Description = reader["description"].ToString();
                        lotterySetup.PricePerBet = double.Parse(reader["price_per_bet"].ToString());
                        lotterySetup.WebScrapeGameCode = int.Parse(reader["web_scrape_code"].ToString());
                    }
                }
            }
            return lotterySetup;
        }
    }
}
