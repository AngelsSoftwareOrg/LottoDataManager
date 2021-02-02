using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class TopDrawPreviousSeasonGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public TopDrawPreviousSeasonGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_top_draw_prev_season_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
        }

        public bool AreParametersValueValid(out string errMessage)
        {
            errMessage = "";
            return true;
        }

        public List<int[]> GenerateSequence()
        {
            return GroupAndCountAndSlice(lotteryDataServices.GetTopDrawnPreviousSeasonDigitResults().ToArray());
        }

        public string GetDescription()
        {
            return this.Description;
        }
    }
}
