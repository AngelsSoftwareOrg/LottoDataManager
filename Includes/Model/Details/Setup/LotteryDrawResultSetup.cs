﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryDrawResultSetup: LotteryCommonSetup, LotteryDrawResult
    {
        private long id;
        private DateTime drawDate;
        private int gameCode;
        private double jackpotAmt;
        private int winners;

        public LotteryDrawResultSetup() : base() { }
        public DateTime DrawDate { get => drawDate; set => drawDate = value; }
        public int GameCode { get => gameCode; set => gameCode = value; }
        public double JackpotAmt { get => jackpotAmt; set => jackpotAmt = value; }
        public int Winners { get => winners; set => winners = value; }
        public long Id { get => id; set => id = value; }
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
        public int GetWinners()
        {
            return this.Winners;
        }
        public long GetID()
        {
            return Id;
        }
        public string GetDrawDateFormatted()
        {
            return DateTimeConverterUtils.ConvertToFormat(this.DrawDate, DateTimeConverterUtils.STANDARD_DATE_FORMAT);
        }
        public string GetJackpotAmtFormatted()
        {
            return String.Format("{0:C}", this.JackpotAmt);
        }
        public bool isWithinDrawResult(int numberToLookFor)
        {
            if (numberToLookFor == this.Num1) return true;
            if (numberToLookFor == this.Num2) return true;
            if (numberToLookFor == this.Num3) return true;
            if (numberToLookFor == this.Num4) return true;
            if (numberToLookFor == this.Num5) return true;
            if (numberToLookFor == this.Num6) return true;
            return false;
        }
        public bool isDrawResulDetailsEmpty()
        {
            if (this.Id <= 0) return true;
            return false;
        }

        override
        public String ToString()
        {
#if DEBUG
            return String.Format("Lottery Draw Result Setup: Draw Date: {0}, Num 1: {1}, Num 2: {2}, Num 3: {3}, Num 4: {4}," +
                "Num 5: {5}, Num 6: {6}, Winners: {7}, Jackpot Amount: {8}",
                this.DrawDate, this.Num1, this.Num2, this.Num3, this.Num4, this.Num5, this.Num6, this.Winners, this.JackpotAmt);
#else
            return base.ToString();
#endif
        }
    }
}