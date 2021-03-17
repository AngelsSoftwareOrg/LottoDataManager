using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomNumbersFromJackpotsDigitsGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomNumbersFromJackpotsDigitsGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.RANDOM_NUMBERS_USING_JACKPOTS_WINNING_DIGITS;
            this.Description = ResourcesUtils.GetMessage("pick_class_random_from_jackpot_numbers_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_random_from_jackpot_numbers_count")
            });
        }
        public bool AreParametersValueValid(out string errMessage)
        {
            errMessage = "";
            try
            {
                int count = GetFieldParamValueForCount();
                if (count <= 0 || count > 99)
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_validate_count_1");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
            return true;
        }
        public List<int[]> GenerateSequence()
        {
            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();
            Random rnd = new Random();
            List<int> drawnDigits = lotteryDataServices.GetTopDrawnDigitFromJackpotsResults();
            List<int[]> sequenceArr = new List<int[]>();

            for(int itr=1; itr<=GetFieldParamValueForCount(); itr++)
            {
                int[] result = new int[lotteryTicketPanel.GetGameDigitCount()];
                for (int seqCtr = 0; seqCtr < lotteryTicketPanel.GetGameDigitCount(); seqCtr++)
                {
                    while (true)
                    {
                        int randomIndex = rnd.Next(0, drawnDigits.Count); //intentionally didnt minus 1
                        int anyDigit = drawnDigits[randomIndex];
                        if (anyDigit <= 0) anyDigit = 1;
                        if (!result.Contains(anyDigit))
                        {
                            result[seqCtr] = anyDigit;
                            break;
                        }
                    }
                }
                Array.Sort(result);
                sequenceArr.Add(result);
            }

            return sequenceArr;
        }
    }
}
