using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomPatternSequenceGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomPatternSequenceGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_top_pattern_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.PATTERN,
                Description = ResourcesUtils.GetMessage("pick_class_top_pattern_box_desc")
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
            errMessage = "";
            try
            {
                DateTime dtFromDate = (DateTime)GetFieldParamValue(GeneratorParamType.FROMDATE);
                DateTime dtToDate = (DateTime)GetFieldParamValue(GeneratorParamType.TODATE);
                if (!IsDateFromAndToValid(dtFromDate, dtToDate, out errMessage)) return false;

                String pattern = (String) GetFieldParamValue(GeneratorParamType.PATTERN);
                if (String.IsNullOrWhiteSpace(pattern))
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_validate_pattern_1");
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


            /*            combo.Items.Add(ResourcesUtils.GetMessage("pick_class_top_pattern_fldd")); xxx
                        combo.Items.Add(ResourcesUtils.GetMessage("pick_class_top_pattern_fldu")); xxx

                        combo.Items.Add(ResourcesUtils.GetMessage("pick_class_top_pattern_flvu"));
                        combo.Items.Add(ResourcesUtils.GetMessage("pick_class_top_pattern_frdd"));
                        combo.Items.Add(ResourcesUtils.GetMessage("pick_class_top_pattern_frdu"));
                        combo.Items.Add(ResourcesUtils.GetMessage("pick_class_top_pattern_frvu"));*/

            String pattern = (String)GetFieldParamValue(GeneratorParamType.PATTERN);
            List<int[]> topDrFrDtRange = lotteryDataServices.GetTopDrawnDigitToSequenceFromDateRange(
                                    (DateTime)GetFieldParamValue(GeneratorParamType.FROMDATE),
                                    (DateTime)GetFieldParamValue(GeneratorParamType.TODATE));
            List<int[]> result;
            if (GetLeftDiagonalDown(pattern, topDrFrDtRange, out result)) return result;
            if (GetLeftDiagonalUp(pattern, topDrFrDtRange, out result)) return result;

            return result;
        }

        private bool GetLeftDiagonalDown(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isLeftDown = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_fldd"), StringComparison.OrdinalIgnoreCase);

            if (!isLeftDown) return false;

            int seqRow = 0;
            while (seqRow < drawNumbers.Count)
            {
                int[] seqEntry = new int[lotteryTicketPanel.GetGameDigitCount()];

                for (int ctr = 0; ctr < lotteryTicketPanel.GetGameDigitCount(); ctr++)
                {
                    if (seqRow < drawNumbers.Count)
                    {
                        int n = drawNumbers[seqRow][ctr];
                        if (seqEntry.Contains(n)) n = GetRandomNumber(seqEntry);
                        seqEntry[ctr] = n;
                    }
                    else
                    {
                        seqEntry = RandomNumberFiller(seqEntry);
                    }
                    seqRow++;
                }
                result.Add(seqEntry);

                if (seqRow > drawNumbers.Count) break;
            }
            return true;
        }

        private bool GetLeftDiagonalUp(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isLeftUp = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_fldu"), StringComparison.OrdinalIgnoreCase);
            if (!isLeftUp) return false;

            int seqRow = drawNumbers.Count-1;
            while (seqRow >= 0)
            {
                int[] seqEntry = new int[lotteryTicketPanel.GetGameDigitCount()];

                for (int ctr = (lotteryTicketPanel.GetGameDigitCount()-1); ctr >= 0; ctr--)
                {
                    if (seqRow >=0)
                    {
                        int n = drawNumbers[seqRow][ctr];
                        if (seqEntry.Contains(n)) n = GetRandomNumber(seqEntry);
                        seqEntry[ctr] = n;
                    }
                    else
                    {
                        seqEntry = RandomNumberFiller(seqEntry);
                    }
                    seqRow--;
                }
                result.Add(seqEntry);
                if (seqRow < 0) break;
            }
            return true;
        }


    }
}
