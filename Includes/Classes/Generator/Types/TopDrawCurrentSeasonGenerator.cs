using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class TopDrawCurrentSeasonGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public TopDrawCurrentSeasonGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_top_draw_cur_season_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
        }

        public bool AreParametersValueValid(out string errMessage)
        {
            errMessage = "";
            return true;
        }

        public List<int[]> GenerateSequence()
        {
            return GroupAndCountAndSlice(lotteryDataServices.GetTopDrawnResultDigits().ToArray());
        }

        public string GetDescription()
        {
            return this.Description;
        }

    }
}
