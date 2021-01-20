using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details
{
    public class LotteryTicketPanelSetup: LotteryTicketPanel
    {
        private NumberDirection numberDirection;
        private int rows;
        private int cols;
        private int min;
        private int max;
        private int gameDigitCount;
        public NumberDirection NumberDirection { get => numberDirection; set => numberDirection = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }
        public int Min { get => min; set => min = value; }
        public int Max { get => max; set => max = value; }
        public int GameDigitCount { get => gameDigitCount; set => gameDigitCount = value; }
        public int GetCols()
        {
            return this.Cols;
        }
        public int GetMax()
        {
            return this.Max;
        }
        public int GetMin()
        {
            return this.Min;
        }
        public NumberDirection GetNumberDirection()
        {
            return this.NumberDirection;
        }
        public int GetRows()
        {
            return this.Rows;
        }
        override
        public String ToString()
        {
#if DEBUG
            return String.Format("Lottery Ticket Panel Setup: Max {0}, Min {1}, Col {2}, Rows {3}, Number Direction {4}, Game Digit Count {5}",
                this.Max, this.Min, this.Cols, this.Rows, this.NumberDirection.ToString(), this.GameDigitCount);
#else
            return base.ToString();
#endif
        }
        public int GetGameDigitCount()
        {
            return GameDigitCount;
        }
        public bool IsWithinMinMax(int num)
        {
            if (num >= Min && num <= Max) return true;
            return false;
        }
    }
}
