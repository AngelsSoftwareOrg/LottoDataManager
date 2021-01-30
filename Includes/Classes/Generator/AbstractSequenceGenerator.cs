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
        protected LotteryDataServices lotteryDataServices;
        protected AbstractSequenceGenerator(LotteryDataServices lotteryDataServices)
        {
            this.lotteryDataServices = lotteryDataServices;

        }
        protected string Description { get => description; set => description = value; }
        protected List<SequenceGeneratorParams> SequenceParams { get => sequenceParams; set => sequenceParams = value; }
        public List<SequenceGeneratorParams> GetFieldParameters()
        {
            return SequenceParams.ToList();
        }
        public void ResetParamsValue()
        {
            foreach (SequenceGeneratorParams seq in SequenceParams)
            {
                if(seq.GeneratorParamType == GeneratorParamType.COUNT)
                {
                    seq.ParamValue = 1;
                }
                else if(seq.GeneratorParamType == GeneratorParamType.DIRECTION) 
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
            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();
            List<int[]> sequenceArr = new List<int[]>();

            var numberGroups = drawnNumbers.GroupBy(i => i)
                                    .Select(grp => new {
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
    
    }
}
