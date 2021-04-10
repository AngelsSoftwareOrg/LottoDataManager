﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator
{
    public abstract class AbstractSequenceGenerator
    {
        private String description;
        private List<SequenceGeneratorParams> sequenceParams;
        private Random random = new Random();
        protected LotteryDataServices lotteryDataServices;
        protected LotteryTicketPanel lotteryTicketPanel;
        protected static int IN_BETWEEN_SUM_MIN = 104;
        protected static int IN_BETWEEN_SUM_MAX = 176;

        private GeneratorType seqGeneratorType;
        protected AbstractSequenceGenerator(LotteryDataServices lotteryDataServices)
        {
            this.lotteryDataServices = lotteryDataServices;
            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
        }
        protected string Description { get => description; set => description = value; }
        protected List<SequenceGeneratorParams> SequenceParams { get => sequenceParams; set => sequenceParams = value; }
        protected GeneratorType SeqGeneratorType { get => seqGeneratorType; set => seqGeneratorType = value; }
        public List<SequenceGeneratorParams> GetFieldParameters()
        {
            return SequenceParams.ToList();
        }
        public void ResetParamsValue()
        {
            foreach (SequenceGeneratorParams seq in SequenceParams)
            {
                if (seq.GeneratorParamType == GeneratorParamType.COUNT)
                {
                    seq.ParamValue = 1;
                }
                else if (seq.GeneratorParamType == GeneratorParamType.PATTERN)
                {
                    seq.ParamValue = null;
                }
                else if (seq.GeneratorParamType == GeneratorParamType.FROMDATE)
                {
                    seq.ParamValue = DateTime.Now;
                }
                else if (seq.GeneratorParamType == GeneratorParamType.GAME_SEASON)
                {
                    seq.ParamValue = null;
                }
                else if (seq.GeneratorParamType == GeneratorParamType.MONTHLY)
                {
                    seq.ParamValue = DateTime.Now;
                }
                else if (seq.GeneratorParamType == GeneratorParamType.TODATE)
                {
                    seq.ParamValue = DateTime.Now;
                }
            }
        }
        protected List<int[]> GroupAndCountAndSlice(int[] drawnNumbers)
        {
            List<int[]> sequenceArr = new List<int[]>();

            var numberGroups = drawnNumbers.GroupBy(i => i)
                                    .Select(grp => new
                                    {
                                        number = grp.Key,
                                        total = grp.Count(),
                                        average = grp.Average(),
                                        minimum = grp.Min(),
                                        maximum = grp.Max()
                                    }).ToArray();

            Array.Sort(numberGroups, (x, y) => (x.total > y.total) ? -1 : 1);

            int inc = lotteryTicketPanel.GetGameDigitCount();
            int segCount = 0;
            while (segCount <= numberGroups.Length)
            {
                int controlledInc = inc;
                if (numberGroups.Length < (segCount + inc)) controlledInc = numberGroups.Length - segCount;

                ArraySegment<object> myArrSegMid = new ArraySegment<object>(numberGroups, segCount, controlledInc);
                int offset = myArrSegMid.Offset + myArrSegMid.Count;
                if (offset > numberGroups.Length) offset = numberGroups.Length - offset;

                int[] result = new int[controlledInc];
                int valueSetter = 0;
                for (int i = myArrSegMid.Offset; i < (offset); i++)
                {
                    Object obj = myArrSegMid.Array[i];
                    Type type = obj.GetType();
                    result[valueSetter++] = (int)type.GetProperty("number").GetValue(obj, null);
                }
                if (result.Length != 0)
                {
                    Array.Sort(result);
                    sequenceArr.Add(result);
                }
                segCount += inc;
            }
            return sequenceArr;
        }
        protected int[] GroupAndCountOnly(int[] drawnNumbers)
        {
            var numberGroups = drawnNumbers.GroupBy(i => i)
                                    .Select(grp => new
                                    {
                                        number = grp.Key,
                                        total = grp.Count(),
                                        average = grp.Average(),
                                        minimum = grp.Min(),
                                        maximum = grp.Max()
                                    }).ToArray();

            Array.Sort(numberGroups, (x, y) => (x.total > y.total) ? -1 : 1);

            int[] sequenceArr = new int[numberGroups.Length];
            int ctr = 0;
            foreach (Object item in numberGroups)
            {
                Type type = item.GetType();
                sequenceArr[ctr++] = (int)type.GetProperty("number").GetValue(item, null);
            }
            return sequenceArr;
        }
        protected int GetFieldParamValueForCount(int fieldIndex=0)
        {
            int ctr = 0;
            foreach (SequenceGeneratorParams seq in SequenceParams)
            {
                if(ctr++ == fieldIndex)
                {
                    if (seq.GeneratorParamType == GeneratorParamType.COUNT)
                    {
                        if (seq.ParamValue == null) return 0;
                        int count;
                        int.TryParse(seq.ParamValue.ToString(), out count);
                        return count;
                    }
                }
            }
            return 0;
        }
        protected int GetFieldFieldCountValue(SequenceGeneratorParams seq)
        {
            if (seq.GeneratorParamType == GeneratorParamType.COUNT)
            {
                if (seq.ParamValue == null) return 0;
                int count;
                int.TryParse(seq.ParamValue.ToString(), out count);
                return count;
            }
            return 0;
        }
        protected SequenceGeneratorParams GetSequenceGeneratorParams(GeneratorParamType type, int fieldIndex = 0)
        {
            int ctr = 0;
            foreach (SequenceGeneratorParams seq in SequenceParams)
            {
                if (seq.GeneratorParamType == GeneratorParamType.COUNT)
                {
                    if (ctr == fieldIndex) return seq;
                }
                ctr++;
            }
            return null;
        }

        protected Object GetFieldParamValue(GeneratorParamType paramType)
        {
            foreach (SequenceGeneratorParams seq in SequenceParams)
            {
                if ((seq.GeneratorParamType == GeneratorParamType.FROMDATE ||
                     seq.GeneratorParamType == GeneratorParamType.TODATE)
                    && seq.GeneratorParamType == paramType)
                {
                    if (seq.ParamValue == null) return null;
                    DateTime result;
                    DateTime.TryParse(seq.ParamValue.ToString(), out result);
                    return result;
                }
                else if (seq.GeneratorParamType == GeneratorParamType.PATTERN
                       && seq.GeneratorParamType == paramType)
                {
                    if (seq.ParamValue == null) return null;
                    return seq.ParamValue.ToString();
                }
            }
            return null;
        }
        protected bool IsDateFromAndToValid(DateTime dateFrom, DateTime dateTo, out String errMessage)
        {
            errMessage = "";
            if (dateFrom.Date.CompareTo(dateTo.Date) > 0)
            {
                errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_from_1");
                return false;
            }
            else if (dateFrom.Date.CompareTo(DateTimeConverterUtils.GetYear2011().Date) < 0)
            {
                errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_from_2");
                return false;
            }
            else if (dateTo.Date.CompareTo(DateTimeConverterUtils.GetYear2011().Date) < 0)
            {
                errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_to_1");
                return false;
            }
            return true;
        }
        protected int GetRandomNumber()
        {
            return random.Next(lotteryTicketPanel.GetMin(), lotteryTicketPanel.GetMax() + 1);
        }
        protected int GetRandomNumber(int[] notContainsWithin)
        {
            while (true)
            {
                int r = GetRandomNumber();
                if (notContainsWithin.Contains(r)) continue;
                return r;
            }
        }
        protected int[] RandomNumberFiller(int[] sequence)
        {
            for (int ctr = 0; ctr < sequence.Length; ctr++)
            {
                if (sequence[ctr] == 0)
                {
                    while (true)
                    {
                        int r = GetRandomNumber();
                        if (sequence.Contains(r)) continue;
                        sequence[ctr] = r;
                        break;
                    }
                }
            }
            return sequence;
        }
        public string GetDescription()
        {
            return Description;
        }
        protected bool ValidateCountParamField(out String errMessage, int fieldIndex=0)
        {
            errMessage = "";
            try
            {
                SequenceGeneratorParams seq = GetSequenceGeneratorParams(GeneratorParamType.COUNT, fieldIndex);
                int count = GetFieldFieldCountValue(seq);
                if (count <= 0 || count > seq.MaxCountValue)
                {
                    errMessage = String.Format(ResourcesUtils.GetMessage("pick_class_validate_count_1"), seq.MaxCountValue);
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
        protected bool ValidateDateRangeParamField(out string errMessage)
        {
            errMessage = "";
            try
            {
                DateTime dtFromDate = (DateTime)GetFieldParamValue(GeneratorParamType.FROMDATE);
                DateTime dtToDate = (DateTime)GetFieldParamValue(GeneratorParamType.TODATE);

                if (dtFromDate.Date.CompareTo(dtToDate.Date) > 0)
                {
                    errMessage = ResourcesUtils.GetMessage("pick_class_validate_date_from_1");
                    return false;
                }
                else if (dtFromDate.Date.CompareTo(DateTimeConverterUtils.GetYear2011().Date) < 0)
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
        public GeneratorType GetSequenceGeneratorType()
        {
            return SeqGeneratorType;
        }
        public int GetSequenceGeneratorID()
        {
            return (int)SeqGeneratorType;
        }
        protected int[] LuckyPickGenerator(Random rnd)
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
            return result;
        }
        protected String GetNumbersOnly(float sourceNum)
        {
            if (sourceNum < 0) sourceNum = sourceNum * -1;
            String numbersOnly = "";
            String tmpString = sourceNum.ToString("F0");
            foreach (Char c in tmpString.ToCharArray())
            {
                int x;
                if (int.TryParse(c.ToString(), out x))
                {
                    numbersOnly = String.Concat(numbersOnly, x);
                }
            }
            return numbersOnly;
        }

        protected bool IsUniqueSequence(List<int[]> haystack, int[] search)
        {
            int[] matched = haystack.Find(seq => {
                int hit = 0;
                for (int ctr = 0; ctr < search.Length; ctr++)
                {
                    if (seq[ctr] == search[ctr]) hit++;
                }
                return (hit == search.Length);
            });

            if (matched == null) return true;
            return false;
        }
    }
}
