using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManagerML.Model;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryDrawResult: LotteryNumbersAndOperations
    {
        DateTime GetDrawDate();
        String GetDrawDateFormatted();
        int GetGameCode();
        long GetID();
        double GetJackpotAmt();
        String GetJackpotAmtFormatted();
        int GetWinners();
        bool IsWithinDrawResult(int numberToLookFor);
        bool IsDrawResulDetailsEmpty();
        void PutNumberSequence(String sequence);
        bool IsDrawResulSequenceEmpty();
        ModelInput GetModelInput();
        String GetMachineLearningDataSetEntry();
    }
}
