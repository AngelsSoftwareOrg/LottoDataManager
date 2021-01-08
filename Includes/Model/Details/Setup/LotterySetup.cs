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
        public GameMode GameCode { get => gameCode; set => gameCode = value; }
        public string Description { get => description; set => description = value; }
        public double PricePerBet { get => pricePerBet; set => pricePerBet = value; }
        public string GetDescription()
        {
            return Description ;
        }
        public GameMode GetGameCode()
        {
            return GameCode;
        }
        public double GetPricePerBet()
        {
            return PricePerBet;
        }
    }
}
