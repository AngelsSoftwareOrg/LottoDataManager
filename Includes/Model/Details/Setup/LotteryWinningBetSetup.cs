using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public class LotteryWinningBetSetup: LotteryCommonSetup, LotteryWinningBet
    {
        private long lotteryBetId;
        private double winningAmount;
        public LotteryWinningBetSetup() : base(){}
        public long LotteryBetId { get => lotteryBetId; set => lotteryBetId = value; }
        public double WinningAmount { get => winningAmount; set => winningAmount = value; }
        public long GetLotteryBetId()
        {
            return LotteryBetId;
        }
        public double GetWinningAmount()
        {
            return WinningAmount;
        }
        override
        public String ToString()
        {

#if DEBUG
            return String.Format("Lottery Winning Bet Setup: Bet ID: {0}, Winning Amount: {1}, " +
                                 "Num 1: {2}, Num 2: {3}, Num 3: {4}, Num 4: {5}, Num 5: {6}, Num 6: {7}",
                this.LotteryBetId, this.WinningAmount,this.Num1, this.Num2, this.Num3, this.Num4, this.Num5, this.Num6);
#else
            return base.ToString();
#endif
        }
    }
}
