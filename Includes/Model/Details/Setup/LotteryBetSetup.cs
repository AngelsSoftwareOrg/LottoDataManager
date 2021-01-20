using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryBetSetup : LotteryCommonSetup, LotteryBet
    {
        private long id;
        private int gameCode;
        private DateTime targetDrawDate;
        private double betAmount;
        private int outletCode;
        private bool luckyPick;

        public LotteryBetSetup(): base() {}
        public int GameCode { get => gameCode; set => gameCode = value; }
        public DateTime TargetDrawDate { get => targetDrawDate; set => targetDrawDate = value; }
        public double BetAmount { get => betAmount; set => betAmount = value; }
        public int OutletCode { get => outletCode; set => outletCode = value; }
        public long Id { get => id; set => id = value; }
        public bool LuckyPick { get => luckyPick; set => luckyPick = value; }
        public double GetBetAmount()
        {
            return BetAmount;
        }
        public int GetGameCode()
        {
            return GameCode;   
        }
        public long GetId()
        {
            return Id;
        }
        public int GetOutletCode()
        {
            return OutletCode;
        }
        public DateTime GetTargetDrawDate()
        {
            return TargetDrawDate;
        }
        public string GetTargetDrawDateFormatted()
        {
            return DateTimeConverterUtils.ConvertToFormat(this.TargetDrawDate, DateTimeConverterUtils.STANDARD_DATE_FORMAT);
        }
        public int[] GetBetNumbersAsArray()
        {
            return this.allNumbers;
        }
        public String GetSimpleContentDetails()
        {
            return String.Format("{0}, {1}-{2}-{3}-{4}-{5}-{6}",
                this.TargetDrawDate.Date.ToString(), this.Num1, this.Num2, this.Num3, this.Num4, this.Num5, this.Num6);
        }
        override
        public String ToString()
        {
#if DEBUG
            return String.Format("Lottery Bet Setup: Draw Date: {0}, Bet Amount: {1}, Game Code: {2}, Outlet Code: {3}, " +
                    "Num 1: {4}, Num 2: {5}, Num 3: {6}, Num 4: {7}, Num 5: {8}, Num 6: {9}, ID: {10}",
                    this.TargetDrawDate, this.BetAmount, this.GameCode, this.OutletCode, 
                    this.Num1, this.Num2, this.Num3, this.Num4, this.Num5, this.Num6, this.Id);
#else
            return base.ToString();
#endif
        }

        public bool IsLuckyPick()
        {
            return LuckyPick;
        }
    }
}
