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
            SeqGeneratorType = GeneratorType.RANDOM_PATTERN_SEQUENCE;
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
            String pattern = (String)GetFieldParamValue(GeneratorParamType.PATTERN);
            List<int[]> topDrFrDtRange = lotteryDataServices.GetTopDrawnDigitToSequenceFromDateRange(
                                    (DateTime)GetFieldParamValue(GeneratorParamType.FROMDATE),
                                    (DateTime)GetFieldParamValue(GeneratorParamType.TODATE));
            List<int[]> result;
            if (GetLeftDiagonalDown(pattern, topDrFrDtRange, out result)) return result;
            if (GetLeftDiagonalUp(pattern, topDrFrDtRange, out result)) return result;
            if (GetLeftVerticalDown(pattern, topDrFrDtRange, out result)) return result;
            if (GetLeftVerticalUpward(pattern, topDrFrDtRange, out result)) return result;
            if (GetRightDiagonalDown(pattern, topDrFrDtRange, out result)) return result;
            if (GetRightDiagonalUp(pattern, topDrFrDtRange, out result)) return result;
            if (GetRightVerticalDown(pattern, topDrFrDtRange, out result)) return result;
            if (GetRightVerticalUpward(pattern, topDrFrDtRange, out result)) return result;
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
                Array.Sort(seqEntry);
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

                for (int ctr = 0; ctr < lotteryTicketPanel.GetGameDigitCount(); ctr++)
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
                Array.Sort(seqEntry);
                result.Add(seqEntry);
                if (seqRow < 0) break;
            }
            return true;
        }
        private bool GetLeftVerticalDown(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isLeftVertdown = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_flvd"), StringComparison.OrdinalIgnoreCase);
            if (!isLeftVertdown) return false;

            List<int[]> destinationSeqArr = new List<int[]>();
            for (int ctr = 0; ctr < drawNumbers.Count; ctr++)
            {
                destinationSeqArr.Add(new int[lotteryTicketPanel.GetGameDigitCount()]);
            }

            int fromIndex = 0;
            int toIndex = lotteryTicketPanel.GetGameDigitCount();
            while (fromIndex < drawNumbers.Count)
            {
                int placingIndex = 0;
                for (int drawRowCtr = fromIndex; drawRowCtr < toIndex; drawRowCtr++)
                {
                    if (drawRowCtr > (drawNumbers.Count - 1)) break;
                    int[] source = drawNumbers[drawRowCtr];
                    int sourceValueIdx = 0;
                    for (int destinationFrom = fromIndex; destinationFrom < toIndex; destinationFrom++)
                    {
                        if (destinationFrom > (destinationSeqArr.Count-1)) break;
                        int[] destination = destinationSeqArr[destinationFrom];
                        int numToPlaceToDestination = source[sourceValueIdx++];
                        if(destination.Contains(numToPlaceToDestination)) numToPlaceToDestination = GetRandomNumber(destination);
                        destination[placingIndex] = numToPlaceToDestination;
                    }
                    placingIndex++;
                }

                fromIndex += lotteryTicketPanel.GetGameDigitCount();
                toIndex += lotteryTicketPanel.GetGameDigitCount();
            }
            foreach(int[] seq in destinationSeqArr)
            {
                RandomNumberFiller(seq);
                Array.Sort(seq);
            }
            result.AddRange(destinationSeqArr.ToArray());
            return true;
        }
        private bool GetLeftVerticalUpward(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isLeftVertdUp = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_flvu"), StringComparison.OrdinalIgnoreCase);
            if (!isLeftVertdUp) return false;

            List<int[]> destinationSeqArr = new List<int[]>();
            for (int ctr = 0; ctr < drawNumbers.Count; ctr++)
            {
                destinationSeqArr.Add(new int[lotteryTicketPanel.GetGameDigitCount()]);
            }

            int fromIndex = drawNumbers.Count - 1;
            int toIndex = fromIndex - lotteryTicketPanel.GetGameDigitCount();
            while (fromIndex > 0)
            {
                int placingIndex = lotteryTicketPanel.GetGameDigitCount() - 1;
                for (int drawRowCtr = fromIndex; drawRowCtr > toIndex; drawRowCtr--)
                {
                    if (drawRowCtr < 0) break;
                    int[] source = drawNumbers[drawRowCtr];
                    int sourceValueIdx = 0;
                    for (int destinationFrom = fromIndex; destinationFrom < toIndex; destinationFrom++)
                    {
                        if (destinationFrom < 0) break;
                        int[] destination = destinationSeqArr[destinationFrom];
                        int numToPlaceToDestination = source[sourceValueIdx++];
                        if (destination.Contains(numToPlaceToDestination)) numToPlaceToDestination = GetRandomNumber(destination);
                        destination[placingIndex] = numToPlaceToDestination;
                    }
                    placingIndex--;
                }

                fromIndex -= lotteryTicketPanel.GetGameDigitCount();
                toIndex -= lotteryTicketPanel.GetGameDigitCount();
            }
            foreach (int[] seq in destinationSeqArr)
            {
                RandomNumberFiller(seq);
                Array.Sort(seq);
            }
            result.AddRange(destinationSeqArr.ToArray());
            return true;
        }
        private bool GetRightDiagonalDown(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isRightDiagDown = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_frdd"), StringComparison.OrdinalIgnoreCase);

            if (!isRightDiagDown) return false;

            int seqRow = 0;
            while (seqRow < drawNumbers.Count)
            {
                int[] seqEntry = new int[lotteryTicketPanel.GetGameDigitCount()];

                for (int ctr = (lotteryTicketPanel.GetGameDigitCount()-1); ctr >=0 ; ctr--)
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
                Array.Sort(seqEntry);
                result.Add(seqEntry);
                if (seqRow > drawNumbers.Count) break;
            }
            return true;
        }
        private bool GetRightDiagonalUp(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isRightDiagUp = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_frdu"), StringComparison.OrdinalIgnoreCase);
            if (!isRightDiagUp) return false;

            int seqRow = drawNumbers.Count - 1;
            while (seqRow >= 0)
            {
                int[] seqEntry = new int[lotteryTicketPanel.GetGameDigitCount()];

                for (int ctr = (lotteryTicketPanel.GetGameDigitCount() - 1); ctr >= 0; ctr--)
                {
                    if (seqRow >= 0)
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
                Array.Sort(seqEntry);
                result.Add(seqEntry);
                if (seqRow < 0) break;
            }
            return true;
        }
        private bool GetRightVerticalDown(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isRightVertdown = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_frvd"), StringComparison.OrdinalIgnoreCase);
            if (!isRightVertdown) return false;

            List<int[]> destinationSeqArr = new List<int[]>();
            for (int ctr = 0; ctr < drawNumbers.Count; ctr++)
            {
                destinationSeqArr.Add(new int[lotteryTicketPanel.GetGameDigitCount()]);
            }

            int fromIndex = 0;
            int toIndex = lotteryTicketPanel.GetGameDigitCount();
            while (fromIndex < drawNumbers.Count)
            {
                int placingIndex = 0;
                for (int drawRowCtr = fromIndex; drawRowCtr < toIndex; drawRowCtr++)
                {
                    if (drawRowCtr > (drawNumbers.Count - 1)) break;
                    int[] source = drawNumbers[drawRowCtr];
                    int sourceValueIdx = lotteryTicketPanel.GetGameDigitCount()-1;
                    for (int destinationFrom = fromIndex; destinationFrom < toIndex; destinationFrom++)
                    {
                        if (destinationFrom > (destinationSeqArr.Count - 1)) break;
                        int[] destination = destinationSeqArr[destinationFrom];
                        int numToPlaceToDestination = source[sourceValueIdx--];
                        if (destination.Contains(numToPlaceToDestination)) numToPlaceToDestination = GetRandomNumber(destination);
                        destination[placingIndex] = numToPlaceToDestination;
                    }
                    placingIndex++;
                }

                fromIndex += lotteryTicketPanel.GetGameDigitCount();
                toIndex += lotteryTicketPanel.GetGameDigitCount();
            }
            foreach (int[] seq in destinationSeqArr)
            {
                RandomNumberFiller(seq);
                Array.Sort(seq);
            }
            result.AddRange(destinationSeqArr.ToArray());
            return true;
        }
        private bool GetRightVerticalUpward(String pattern, List<int[]> drawNumbers, out List<int[]> result)
        {
            result = new List<int[]>();
            bool isRightVertdUp = pattern.Equals(ResourcesUtils.GetMessage("pick_class_top_pattern_frvu"), StringComparison.OrdinalIgnoreCase);
            if (!isRightVertdUp) return false;

            List<int[]> destinationSeqArr = new List<int[]>();
            for (int ctr = 0; ctr < drawNumbers.Count; ctr++)
            {
                destinationSeqArr.Add(new int[lotteryTicketPanel.GetGameDigitCount()]);
            }

            int fromIndex = drawNumbers.Count-1;
            int toIndex = fromIndex - lotteryTicketPanel.GetGameDigitCount();
            while (fromIndex > 0)
            {
                int placingIndex = lotteryTicketPanel.GetGameDigitCount() - 1;
                for (int drawRowCtr = fromIndex; drawRowCtr > toIndex; drawRowCtr--)
                {
                    if (drawRowCtr < 0) break;
                    int[] source = drawNumbers[drawRowCtr];
                    int sourceValueIdx = lotteryTicketPanel.GetGameDigitCount() - 1;
                    for (int destinationFrom = fromIndex; destinationFrom < toIndex; destinationFrom++)
                    {
                        if (destinationFrom < 0) break;
                        int[] destination = destinationSeqArr[destinationFrom];
                        int numToPlaceToDestination = source[sourceValueIdx--];
                        if (destination.Contains(numToPlaceToDestination)) numToPlaceToDestination = GetRandomNumber(destination);
                        destination[placingIndex] = numToPlaceToDestination;
                    }
                    placingIndex--;
                }

                fromIndex -= lotteryTicketPanel.GetGameDigitCount();
                toIndex -= lotteryTicketPanel.GetGameDigitCount();
            }
            foreach (int[] seq in destinationSeqArr)
            {
                RandomNumberFiller(seq);
                Array.Sort(seq);
            }
            result.AddRange(destinationSeqArr.ToArray());
            return true;
        }

    }
}
