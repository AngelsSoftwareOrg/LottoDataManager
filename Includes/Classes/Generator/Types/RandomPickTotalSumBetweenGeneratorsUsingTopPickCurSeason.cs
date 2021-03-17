using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomPickTotalSumBetweenGeneratorsUsingTopPickCurSeason : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomPickTotalSumBetweenGeneratorsUsingTopPickCurSeason(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.RANDOM_PICK_A_SEQ_104_176_3;
            this.Description = ResourcesUtils.GetMessage("pick_class_random_sum3_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_random_sum3_count")
            });
        }

        public bool AreParametersValueValid(out string errMessage)
        {
            if (ValidateCountParamField(out errMessage)) return true;
            return false;
        }

        public List<int[]> GenerateSequence()
        {
            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();
            int[] topDrawnNumbersArr = lotteryDataServices.GetTopDrawnResultDigits().ToArray();

            List<int[]> sequenceArr = new List<int[]>();
            Random rnd = new Random();
            int breakInfLoop = 0;
            for (int ctr = 0; ctr < GetFieldParamValueForCount(); ctr++)
            {
                breakInfLoop = 0;
                int[] result = new int[lotteryTicketPanel.GetGameDigitCount()];
                while (true)
                {
                    for (int seqCtr = 0; seqCtr < lotteryTicketPanel.GetGameDigitCount(); seqCtr++)
                    {
                        while (true)
                        {
                            int anyDigit = rnd.Next(0, topDrawnNumbersArr.Length);
                            int pickupDigit = topDrawnNumbersArr[anyDigit];
                            if (!result.Contains(pickupDigit))
                            {
                                result[seqCtr] = pickupDigit;
                                break;
                            }
                            if (breakInfLoop++ > 100000) break;
                        }
                    }
                    int sum = 0;
                    foreach (int i in result)
                    {
                        sum += i;
                    }
                    if (sum >= 104 && sum <= 176) break;
                    result = new int[lotteryTicketPanel.GetGameDigitCount()];

                    if (breakInfLoop++ > 100000) break;
                }
                if (breakInfLoop++ > 100000) break;
                Array.Sort(result);
                sequenceArr.Add(result);
            }
            return sequenceArr;
        }
    }
}
