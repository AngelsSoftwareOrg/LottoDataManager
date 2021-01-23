using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryNumbersAndOperations
    {
        int GetNum1();
        int GetNum2();
        int GetNum3();
        int GetNum4();
        int GetNum5();
        int GetNum6();
        void SortNumbers(ListSortDirection direction = ListSortDirection.Ascending);
        void RestoreOriginalNumberOrder();
        void FillNumberBySeq(int seq, int number);
        bool IsNumberSequenceMatchesAll(int[] toMatchNumSeq);
        int[] GetAllNumberSequence();
        int[] GetAllNumberSequenceSorted(ListSortDirection direction = ListSortDirection.Ascending);
    }
}
