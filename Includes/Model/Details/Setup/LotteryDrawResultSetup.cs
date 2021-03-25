using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;
using LottoDataManagerML.Model;

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
        public bool IsWithinDrawResult(int numberToLookFor)
        {
            if (numberToLookFor == this.Num1) return true;
            if (numberToLookFor == this.Num2) return true;
            if (numberToLookFor == this.Num3) return true;
            if (numberToLookFor == this.Num4) return true;
            if (numberToLookFor == this.Num5) return true;
            if (numberToLookFor == this.Num6) return true;
            return false;
        }
        public bool IsDrawResulDetailsEmpty()
        {
            if (this.Id <= 0) return true;
            return false;
        }
        public bool IsDrawResulSequenceEmpty()
        {
            return (this.Num1 <= 0 && this.Num2 <= 0 && this.Num3 <= 0 && this.Num4 <= 0 && this.Num5 <= 0 && this.Num6 <= 0);
        }
        public ModelInput GetModelInput()
        {
            return new ModelInput()
            {
                Draw_date = GetDrawDateFormatted() + " 00:00:00.0",
                Num1 = GetNum1(),
                Num2 = GetNum2(),
                Num3 = GetNum3(),
                Num4 = GetNum4(),
                Num5 = GetNum5(),
                Num6 = GetNum6(),
                Game_cd = GetGameCode()
            };
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

        public String GetMachineLearningDataSetEntry()
        {
            //draw_date,num1,num2,num3,num4,num5,num6,game_cd,RESULT
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                    DateTimeConverterUtils.ConvertToFormat(DrawDate,DateTimeConverterUtils.STANDARD_DATE_FORMAT),
                    Num1, Num2, Num3, Num4, Num5, Num6, GameCode, 
                    String.Format("{0}{1}{2}{3}{4}{5}", 
                        Num1.ToString().PadLeft(2, char.Parse("0")),
                        Num2.ToString().PadLeft(2, char.Parse("0")),
                        Num3.ToString().PadLeft(2, char.Parse("0")),
                        Num4.ToString().PadLeft(2, char.Parse("0")),
                        Num5.ToString().PadLeft(2, char.Parse("0")),
                        Num6.ToString().PadLeft(2, char.Parse("0"))));
        }
    
    }
}
