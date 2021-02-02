using System;
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
            errMessage = "";
            try
            {
                DateTime dtFromDate = (DateTime) GetFieldParamValue(GeneratorParamType.FROMDATE);
                DateTime dtToDate = (DateTime)GetFieldParamValue(GeneratorParamType.TODATE);

                if (dtFromDate.Date.CompareTo(dtToDate.Date)>0)
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_from_1");
                    return false;
                }else if (dtFromDate.Date.CompareTo(DateTimeConverterUtils.GetYear2011().Date) < 0)
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_from_2");
                    return false;
                }
                else if (dtToDate.Date.CompareTo(DateTimeConverterUtils.GetYear2011().Date) < 0)
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_to_1");
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
            return GroupAndCountAndSlice(lotteryDataServices.GetTopDrawnDigitFromDateRange(
                (DateTime) GetFieldParamValue(GeneratorParamType.FROMDATE),
                (DateTime) GetFieldParamValue(GeneratorParamType.TODATE)).ToArray());
        }
    }
}
