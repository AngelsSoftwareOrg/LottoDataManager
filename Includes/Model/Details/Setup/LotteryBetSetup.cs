using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes.ML.FastTreeRegression;
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
        private int matchNumCount;
        private LotteryOutlet lotteryOutlet;
        private LotterySequenceGenerator lotterySeqGen;
        private LotteryWinningBet lotteryWinningBet;

        public LotteryBetSetup(): base() {}
        public int GameCode { get => gameCode; set => gameCode = value; }
        public DateTime TargetDrawDate { get => targetDrawDate; set => targetDrawDate = value; }
        public double BetAmount { get => betAmount; set => betAmount = value; }
        public int OutletCode { get => outletCode; set => outletCode = value; }
        public long Id { get => id; set => id = value; }
        public bool LuckyPick { get => luckyPick; set => luckyPick = value; }
        public int MatchNumCount { get => matchNumCount; set => matchNumCount = value; }
        public LotteryOutlet LotteryOutlet { get => lotteryOutlet; set => lotteryOutlet = value; }
        public LotterySequenceGenerator LotterySeqGen { get => lotterySeqGen; set => lotterySeqGen = value; }
        public LotteryWinningBet LotteryWinningBet { get => lotteryWinningBet; set => lotteryWinningBet = value; }

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
        public String GetTargetDrawDateFormatted()
        {
            return DateTimeConverterUtils.ConvertToFormat(this.TargetDrawDate, DateTimeConverterUtils.STANDARD_DATE_FORMAT);
        }
        public String GetTargetDrawDateLongFormat()
        {
            return DateTimeConverterUtils.ConvertToFormat(this.TargetDrawDate, DateTimeConverterUtils.DATE_FORMAT_LONG);
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
        public int GetMatchNumCount()
        {
            return MatchNumCount;
        }
        public LotteryOutlet GetLotteryOutlet()
        {
            return LotteryOutlet;
        }
        public LotterySequenceGenerator GetLotterySequenceGenerator()
        {
            return LotterySeqGen;
        }
        public LotteryWinningBet GetLotteryWinningBet()
        {
            return LotteryWinningBet;
        }

        public LottoMatchCountInputModel GetLottoMatchCountInputModel()
        {
            return new LottoMatchCountInputModel()
            {
                Match_cnt = MatchNumCount,
                Num1 = GetNum1(),
                Num2 = GetNum2(),
                Num3 = GetNum3(),
                Num4 = GetNum4(),
                Num5 = GetNum5(),
                Num6 = GetNum6(),
                Game_cd = GetGameCode()
            };
        }

        public string GetLottoMatchCountTrainerModelDataIntake()
        {
            //game_cd,num1,num2,num3,num4,num5,num6,match_cnt
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                    GameCode, Num1, Num2, Num3, Num4, Num5, Num6, MatchNumCount);
        }
    }
}
