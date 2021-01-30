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
            for(int ctr=0; ctr < GetParamValue(); ctr++)
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
        private int GetParamValue()
        {
            foreach(SequenceGeneratorParams seq in SequenceParams)
            {
                if(seq.GeneratorParamType == GeneratorParamType.COUNT)
                {
                    if (seq.ParamValue == null) return 0;
                    int count;
                    int.TryParse(seq.ParamValue.ToString(), out count);
                    return count;
                }
            }
            return 0;
        }
        public bool AreParametersValueValid(out String errMessage)
        {
            errMessage = "";
            try
            {
                int count=GetParamValue();
                if (count <= 0 || count > 99)
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_luckypick_err1");
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
        public string GetDescription()
        {
            return Description;
        }


    }
}
