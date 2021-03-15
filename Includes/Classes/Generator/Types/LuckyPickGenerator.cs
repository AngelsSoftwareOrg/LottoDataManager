using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class LuckyPickGenerator: AbstractSequenceGenerator, SequenceGenerator
    {
        public LuckyPickGenerator(LotteryDataServices lotteryDataServices): base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_luckypick_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_luckypick_count")
            });
        }
        public List<int[]> GenerateSequence()
        {
            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();
            List<int[]> sequenceArr = new List<int[]>();
            Random rnd = new Random();
            for(int ctr=0; ctr < GetFieldParamValueForCount(); ctr++)
            {
                int[] result = new int[lotteryTicketPanel.GetGameDigitCount()];
                for (int seqCtr = 0; seqCtr < lotteryTicketPanel.GetGameDigitCount(); seqCtr++)
                {
                    while (true)
                    {
                        int anyDigit = rnd.Next(lotteryTicketPanel.GetMin(), lotteryTicketPanel.GetMax() + 1);
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
        public bool AreParametersValueValid(out String errMessage)
        {
            return ValidateCountParamField(out errMessage);
        }

    }
}
