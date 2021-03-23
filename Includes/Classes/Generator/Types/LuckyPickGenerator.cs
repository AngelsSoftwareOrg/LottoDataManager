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
            SeqGeneratorType = GeneratorType.LUCKY_PICK;
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
                sequenceArr.Add(LuckyPickGenerator(rnd));
            }
            return sequenceArr;
        }
        public bool AreParametersValueValid(out String errMessage)
        {
            return ValidateCountParamField(out errMessage);
        }

    }
}
