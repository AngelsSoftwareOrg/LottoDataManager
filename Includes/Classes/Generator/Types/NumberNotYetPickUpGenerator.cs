using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator
{
    public class NumberNotYetPickUpGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public NumberNotYetPickUpGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.NUMBER_NOT_YET_PICK_UP_GENERATOR;
            this.Description = ResourcesUtils.GetMessage("pick_class_numbers_not_yet_drawn_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
        }

        public bool AreParametersValueValid(out string errMessage)
        {
            errMessage = "";
            return true;
        }

        public List<int[]> GenerateSequence()
        {
            List<int> hasntYetPickUp = new List<int>();
            List<int> topDraw = lotteryDataServices.GetTopDrawnResultDigits();
            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();

            for(int ctr=1; ctr<= lotteryTicketPanel.GetMax(); ctr++)
            {
                if (!topDraw.Contains(ctr))
                {
                    hasntYetPickUp.Add(ctr);
                }
            }
            return GroupAndCountAndSlice(hasntYetPickUp.ToArray());
        }
    }
}
