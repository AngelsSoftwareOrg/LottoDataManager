using System;
using LottoDataManager.Includes.Classes.ML.FastTree;
using LottoDataManager.Includes.Classes.ML.SDCARegression;

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
        ModelInputFastTree GetModelInput();
        ModelInputSDCARegression GetModelInputSDCARegression();
        String GetMachineLearningDataSetEntry();
    }
}
