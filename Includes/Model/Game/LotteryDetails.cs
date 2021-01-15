using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes.Scraping;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    public class LotteryDetails
    {
        private GameMode gameMode;
        private String description;
        private Lottery lottery;

        
        public LotteryDetails(GameMode gameMode, String description = "")
        {
            SetGameMode(gameMode);
            LotteryDao lotteryDao = LotteryDaoImpl.GetInstance();
            this.lottery = lotteryDao.GetLottery(gameMode);
            if (String.IsNullOrWhiteSpace(lottery.GetDescription()))
            {
                SetDescription(description);
            }
            else
            {
                SetDescription(lottery.GetDescription());
            }
        }
        protected void SetGameMode(GameMode gameCode) 
        { 
            this.gameMode = gameCode; 
        }
        protected void SetDescription(String description)
        {
            this.description = description;
        }
        public GameMode GameMode { get => gameMode; }
        public int GameCode { get => (int) GameMode; }
        public string Description { get => description; }
        public Lottery Lottery
        {
            get
            {
                return this.lottery;
            }
        }

    }
}
