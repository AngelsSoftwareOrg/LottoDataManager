using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Settings
{
    public class LotteryWinningCombinationSetup: LotteryWinningCombination
    {
        private int match0;
        private int match1;
        private int match2;
        private int match3;
        private int match4;
        private int match5;
        private int match6;

        public int Match0 { get => match0; set => match0 = value; }
        public int Match1 { get => match1; set => match1 = value; }
        public int Match2 { get => match2; set => match2 = value; }
        public int Match3 { get => match3; set => match3 = value; }
        public int Match4 { get => match4; set => match4 = value; }
        public int Match5 { get => match5; set => match5 = value; }
        public int Match6 { get => match6; set => match6 = value; }

        public int GetMatch0()
        {
            return this.Match0;
        }

        public int GetMatch1()
        {
            return this.Match1;
        }

        public int GetMatch2()
        {
            return this.Match2;
        }

        public int GetMatch3()
        {
            return this.Match3;
        }

        public int GetMatch4()
        {
            return this.Match4;
        }

        public int GetMatch5()
        {
            return this.Match5;
        }

        public int GetMatch6()
        {
            return this.Match6;
        }
    }
}
