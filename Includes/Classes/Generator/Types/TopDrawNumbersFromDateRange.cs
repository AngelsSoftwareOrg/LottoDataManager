﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class TopDrawNumbersFromDateRange : AbstractSequenceGenerator, SequenceGenerator
    {
        public TopDrawNumbersFromDateRange(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.TOP_DRAW_NUMBERS_USING_DATE_RANGE;
            this.Description = ResourcesUtils.GetMessage("pick_class_top_draw_date_range_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.FROMDATE,
                Description = ResourcesUtils.GetMessage("pick_class_top_draw_date_range_date_from")
            });
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.TODATE,
                Description = ResourcesUtils.GetMessage("pick_class_top_draw_date_range_date_to")
            });
        }
        public bool AreParametersValueValid(out string errMessage)
        {
            return (ValidateDateRangeParamField(out errMessage));
        }
        public List<int[]> GenerateSequence()
        {
            return GroupAndCountAndSlice(lotteryDataServices.GetTopDrawnDigitFromDateRange(
                (DateTime) GetFieldParamValue(GeneratorParamType.FROMDATE),
                (DateTime) GetFieldParamValue(GeneratorParamType.TODATE)).ToArray());
        }
    }
}
