using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public abstract class LotteryCommonSetup
    {
        protected int[] allNumbers = new int[6];
        protected int[] allNumbersOriginalOrder = new int[6];
        protected LotteryCommonSetup()
        {
            allNumbers[0] = 0; allNumbersOriginalOrder[0] = 0;
            allNumbers[1] = 0; allNumbersOriginalOrder[1] = 0;
            allNumbers[2] = 0; allNumbersOriginalOrder[2] = 0;
            allNumbers[3] = 0; allNumbersOriginalOrder[3] = 0;
            allNumbers[4] = 0; allNumbersOriginalOrder[4] = 0;
            allNumbers[5] = 0; allNumbersOriginalOrder[5] = 0;
        }
        internal bool isOriginalOrderNumberPopulated()
        {
            return (allNumbersOriginalOrder[0] != 0);
        }
        public int Num1 { get => allNumbers[0]; set => allNumbers[0] = value; }
        public int Num2 { get => allNumbers[1]; set => allNumbers[1] = value; }
        public int Num3 { get => allNumbers[2]; set => allNumbers[2] = value; }
        public int Num4 { get => allNumbers[3]; set => allNumbers[3] = value; }
        public int Num5 { get => allNumbers[4]; set => allNumbers[4] = value; }
        public int Num6 { get => allNumbers[5]; set => allNumbers[5] = value; }
        public void SortNumbers(ListSortDirection direction = ListSortDirection.Ascending)
        {
            if (!isOriginalOrderNumberPopulated()) allNumbersOriginalOrder = (int[])this.allNumbers.Clone();

            if (direction == ListSortDirection.Ascending)
            {
                Array.Sort(this.allNumbers);
            }
            else
            {
                Array.Reverse(this.allNumbers);
            }
        }
        public void RestoreOriginalNumberOrder()
        {
            if (!isOriginalOrderNumberPopulated()) return;
            this.allNumbers = (int[])allNumbersOriginalOrder.Clone();
        }
        public int GetNum1()
        {
            return Num1;
        }
        public int GetNum2()
        {
            return Num2;
        }
        public int GetNum3()
        {
            return Num3;
        }
        public int GetNum4()
        {
            return Num4;
        }
        public int GetNum5()
        {
            return Num5;
        }
        public int GetNum6()
        {
            return Num6;
        }
        public void FillNumberBySeq(int seq, int number)
        {
            if (seq < 1 || seq > 6) throw new Exception("Sequence should be between 1-6.");

            foreach(int n in allNumbers)
            {
                if (n > 0 && n == number) throw new Exception("Duplicate number is not valid.");
            }

            allNumbers[seq - 1] = number;
        }
        public bool IsNumberSequenceMatchesAll(int[] toMatchNumSeq)
        {
            if (allNumbers.Length != toMatchNumSeq.Length) return false;
            int[] allNumbersCopy = (int[]) allNumbers.Clone();
            int[] toMatchNumSeqCopy = (int[]) toMatchNumSeq.Clone();
            Array.Sort(allNumbersCopy);
            Array.Sort(toMatchNumSeqCopy);
            for (int x = 0; x < allNumbersCopy.Length; x++)
            {
                if (allNumbersCopy[x] != toMatchNumSeqCopy[x]) return false;
            }
            return true;
        }
        public int[] GetAllNumberSequence()
        {
            return (int[]) this.allNumbers.Clone();
        }
        public int[] GetAllNumberSequenceSorted(ListSortDirection direction = ListSortDirection.Ascending)
        {
            int[] seq = (int[])this.allNumbers.Clone();
            Array.Sort(seq);
            if (direction == ListSortDirection.Descending) Array.Reverse(seq);
            return seq;
        }

        public void PutNumberSequence(String sequence)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(sequence)) throw new Exception("Parameter should contain a sequence of number for parsing");
                string[] sequenceDeliminator = StringUtils.COMMON_DELIMITERS;
                foreach (String del in sequenceDeliminator)
                {
                    String[] tokens = sequence.Split(del.ToCharArray());
                    if (tokens.Length < 6) continue;
                    for (int ctr = 0; ctr < tokens.Length; ctr++)
                    {
                        FillNumberBySeq(ctr + 1, int.Parse(tokens[ctr]));
                    }
                }
                //test if sequence has been filled up
                if(this.Num6 <=0) throw new Exception("Parameter should contain a sequence of number for parsing");
            }
            catch (Exception e) 
            {
                throw e;
            }
        }
    }
}
