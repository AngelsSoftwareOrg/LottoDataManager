using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class HistoricalFrequencyRandomGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public HistoricalFrequencyRandomGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_historic_freq_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_historic_freq_count")
            });
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
            if(ValidateCountParamField(out errMessage)) return true;
            if (ValidateDateRangeParamField(out errMessage)) return true;
            return false;
        }

        public List<int[]> GenerateSequence()
        {
            int[] historicFigureList = GroupAndCountOnly(lotteryDataServices.GetTopDrawnDigitFromDateRange(
                (DateTime)GetFieldParamValue(GeneratorParamType.FROMDATE),
                (DateTime)GetFieldParamValue(GeneratorParamType.TODATE)).ToArray());

            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();
            List<int[]> sequenceArr = new List<int[]>();
            Random rnd = new Random();
            for (int ctr = 0; ctr < GetFieldParamValueForCount(); ctr++)
            {
                int[] result = new int[lotteryTicketPanel.GetGameDigitCount()];
                for (int seqCtr = 0; seqCtr < lotteryTicketPanel.GetGameDigitCount(); seqCtr++)
                {
                    while (true)
                    {
                        int anyDigit = rnd.Next(0, historicFigureList.Length);
                        int pickupDigit = historicFigureList[anyDigit];
                        if (!result.Contains(pickupDigit))
                        {
                            result[seqCtr] = pickupDigit;
                            break;
                        }
                    }
                }
                Array.Sort(result);
                sequenceArr.Add(result);
            }
            return sequenceArr;
        }
    }
}
