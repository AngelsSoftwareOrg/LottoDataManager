using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryWinningCombinationSetup: LotteryWinningCombination
    {
        private double match0;
        private double match1;
        private double match2;
        private double match3;
        private double match4;
        private double match5;
        private double match6;
        private int Id;
        private GameMode gameCode;
        public double Match0 { get => match0; set => match0 = value; }
        public double Match1 { get => match1; set => match1 = value; }
        public double Match2 { get => match2; set => match2 = value; }
        public double Match3 { get => match3; set => match3 = value; }
        public double Match4 { get => match4; set => match4 = value; }
        public double Match5 { get => match5; set => match5 = value; }
        public double Match6 { get => match6; set => match6 = value; }
        public int ID { get => Id; set => Id = value; }
        public GameMode GameCode { get => gameCode; set => gameCode = value; }
        public object Clone()
        {
            LotteryWinningCombinationSetup s = new LotteryWinningCombinationSetup()
            {
                ID = this.ID,
                GameCode = this.GameCode,
                Match0 = this.Match0,
                Match1 = this.Match1,
                Match2 = this.Match2,
                Match3 = this.Match3,
                Match4 = this.Match4,
                Match5 = this.Match5,
                Match6 = this.Match6,
            };
            return s;
        }

        public GameMode GetGameCode()
        {
            return GameCode;
        }
        public int GetID()
        {
            return ID;
        }
        public double GetMatch0()
        {
            return this.Match0;
        }
        public double GetMatch1()
        {
            return this.Match1;
        }
        public double GetMatch2()
        {
            return this.Match2;
        }
        public double GetMatch3()
        {
            return this.Match3;
        }
        public double GetMatch4()
        {
            return this.Match4;
        }
        public double GetMatch5()
        {
            return this.Match5;
        }
        public double GetMatch6()
        {
            return this.Match6;
        }
        public double GetWinningAmount(int matchingCount)
        {
            if (matchingCount == 1) return this.Match1;
            if (matchingCount == 2) return this.Match2;
            if (matchingCount == 3) return this.Match3;
            if (matchingCount == 4) return this.Match4;
            if (matchingCount == 5) return this.Match5;
            if (matchingCount == 6) return this.Match6;
            return 0;
        }
        override
        public String ToString()
        {
#if DEBUG
            return String.Format("Lottery Winning Combination Setup: Match 0->{0}, 1->{1}, 2->{2}, 3->{3}, 4->{4}, 5->{5}, 6->{6}",
                this.Match0, this.Match1, this.Match2, this.Match3, this.Match4, this.Match5, this.Match6);
#else
            return base.ToString();
#endif
        }
    }
}
