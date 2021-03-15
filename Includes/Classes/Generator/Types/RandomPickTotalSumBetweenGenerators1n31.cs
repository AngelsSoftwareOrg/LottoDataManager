using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomPickTotalSumBetweenGenerators1n31 : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomPickTotalSumBetweenGenerators1n31(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_random_sum2_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_random_sum2_count")
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
            List<int[]> sequenceArr = new List<int[]>();
            Random rnd = new Random();
            for (int ctr = 0; ctr < GetFieldParamValueForCount(); ctr++)
            {
                int[] result = new int[lotteryTicketPanel.GetGameDigitCount()];
                while (true)
                {
                    for (int seqCtr = 0; seqCtr < lotteryTicketPanel.GetGameDigitCount(); seqCtr++)
                    {
                        while (true)
                        {
                            int anyDigit = rnd.Next(1, 32);
                            if (anyDigit <= 0) anyDigit = 1;
                            if (!result.Contains(anyDigit))
                            {
                                result[seqCtr] = anyDigit;
                                break;
                            }
                        }
                    }
                    int sum = 0;
                    foreach (int i in result)
                    {
                        sum += i;
                    }
                    if (sum >= 104 && sum <= 176) break;
                    result = new int[lotteryTicketPanel.GetGameDigitCount()];
                }
                Array.Sort(result);
                sequenceArr.Add(result);
            }
            return sequenceArr;
        }
    }
}
