using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryDrawResultSetup: LotteryDrawResult
    {
        private DateTime drawDate;
        private int gameCode;
        private int num1;
        private int num2;
        private int num3;
        private int num4;
        private int num5;
        private int num6;
        private double jackpotAmt;
        private int winners;
        public DateTime DrawDate { get => drawDate; set => drawDate = value; }
        public int GameCode { get => gameCode; set => gameCode = value; }
        public int Num1 { get => num1; set => num1 = value; }
        public int Num2 { get => num2; set => num2 = value; }
        public int Num3 { get => num3; set => num3 = value; }
        public int Num4 { get => num4; set => num4 = value; }
        public int Num5 { get => num5; set => num5 = value; }
        public int Num6 { get => num6; set => num6 = value; }
        public double JackpotAmt { get => jackpotAmt; set => jackpotAmt = value; }
        public int Winners { get => winners; set => winners = value; }
        public DateTime GetDrawDate()
        {
            return this.DrawDate;
        }
        public int GetGameCode()
        {
            return this.GameCode;
        }
        public double GetJackpotAmt()
        {
            return this.JackpotAmt;
        }
        public int GetNum1()
        {
            return this.Num1;
        }
        public int GetNum2()
        {
            return this.Num2;
        }
        public int GetNum3()
        {
            return this.Num3;
        }
        public int GetNum4()
        {
            return this.Num4;
        }
        public int GetNum5()
        {
            return this.Num5;
        }
        public int GetNum6()
        {
            return this.Num6;
        }
        public int GetWinners()
        {
            return this.Winners;
        }
        public string GetDrawDateFormatted()
        {
            return DateTimeConverterUtils.ConvertToFormat(this.DrawDate, DateTimeConverterUtils.STANDARD_DATE_FORMAT);
        }
        public string GetJackpotAmtFormatted()
        {
            return String.Format("{0:C}", this.JackpotAmt);
        }
        override
        public String ToString()
        {
            return String.Format("Lottery Draw Result Setup: Draw Date: {0}, Num 1: {1}, Num 2: {2}, Num 3: {3}, Num 4: {4}," +
                "Num 5: {5}, Num 6: {6}, Winners: {7}, Jackpot Amount: {8}",
                this.DrawDate, this.Num1, this.Num2, this.Num3, this.Num4, this.Num5, this.Num6, this.Winners, this.JackpotAmt);
        }
    }
}
