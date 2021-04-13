using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public class LotteryWinningBetSetup: LotteryCommonSetup, LotteryWinningBet
    {
        private long id;
        private DateTime targetDrawDate;
        private long lotteryBetId;
        private double winningAmount;
        private bool claimStatus;
        private int outletCd;
        private String outletDesc;

        public LotteryWinningBetSetup() : base(){}
        public long LotteryBetId { get => lotteryBetId; set => lotteryBetId = value; }
        public double WinningAmount { get => winningAmount; set => winningAmount = value; }
        public bool ClaimStatus { get => claimStatus; set => claimStatus = value; }
        public int OutletCd { get => outletCd; set => outletCd = value; }
        public string OutletDesc { get => outletDesc; set => outletDesc = value; }
        public DateTime TargetDrawDate { get => targetDrawDate; set => targetDrawDate = value; }
        public long ID { get => id; set => id = value; }

        public long GetLotteryBetId()
        {
            return LotteryBetId;
        }
        public double GetWinningAmount()
        {
            return WinningAmount;
        }
        public String GetWinningAmountInCurrency()
        {
            return WinningAmount.ToString("C");
        }
        public bool IsClaimed()
        {
            return ClaimStatus;
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
        public int GetOutletCd()
        {
            return OutletCd;
        }
        public string GetOutletDesc()
        {
            return OutletDesc;
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
        public long GetID()
        {
            return ID;
        }
    }
}
