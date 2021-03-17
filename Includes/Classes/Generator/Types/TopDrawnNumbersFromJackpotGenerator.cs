using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class TopDrawnNumbersFromJackpotGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public TopDrawnNumbersFromJackpotGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.TOP_DRAWN_NUMBERS_FROM_JACKPOTS;
            this.Description = ResourcesUtils.GetMessage("pick_class_top_draw_jackpot_numbers_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
        }
        public bool AreParametersValueValid(out string errMessage)
        {
            errMessage = "";
            return true;
        }
        public List<int[]> GenerateSequence()
        {
            return GroupAndCountAndSlice(lotteryDataServices.GetTopDrawnDigitFromJackpotsResults().ToArray());
        }
    }
}
