using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public class LotterySetup: Lottery
    {
        private GameMode gameCode;
        private String description;
        private double pricePerBet;
        private int webScrapeGameCode;

        public GameMode GameCode { get => gameCode; set => gameCode = value; }
        public string Description { get => description; set => description = value; }
        public double PricePerBet { get => pricePerBet; set => pricePerBet = value; }
        public int WebScrapeGameCode { get => webScrapeGameCode; set => webScrapeGameCode = value; }
        public Lottery Clone()
        {
            LotterySetup setup = new LotterySetup()
            {
                GameCode = this.GameCode,
                Description = new string(this.Description.ToCharArray()),
                PricePerBet = this.PricePerBet,
                WebScrapeGameCode = this.WebScrapeGameCode
            };
            return setup;
        }

        public string GetDescription()
        {
            return Description ;
        }
        public GameMode GetGameMode()
        {
            return GameCode;
        }
        public double GetPricePerBet()
        {
            return PricePerBet;
        }
        public int GetWebScrapeGameCode()
        {
            return WebScrapeGameCode;
        }
        override
        public String ToString()
        {
            return Description;
        }
    }
}
