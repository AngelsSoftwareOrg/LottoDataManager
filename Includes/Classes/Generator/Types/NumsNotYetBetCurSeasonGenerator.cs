using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class NumsNotYetBetCurSeasonGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public NumsNotYetBetCurSeasonGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            this.Description = ResourcesUtils.GetMessage("pick_class_numbers_not_yet_bet_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
        }
        public bool AreParametersValueValid(out string errMessage)
        {
            errMessage = "";
            return true;
        }
        public List<int[]> GenerateSequence()
        {
            LotteryTicketPanel lotteryTicketPanel = lotteryDataServices.GetLotteryTicketPanel();
            List<LotteryBet> betsThisSeason = lotteryDataServices.GetLotteryBetsCurrentSeason();
            List<int> merge = new List<int>();
            List<int> rawResult = new List<int>();
            foreach (LotteryBet bet in betsThisSeason)
            {
                merge.AddRange(bet.GetAllNumberSequence());
            }

            for(int ctr= lotteryTicketPanel.GetMin(); ctr< lotteryTicketPanel.GetMax(); ctr++)
            {
                if (!merge.Contains(ctr)) rawResult.Add(ctr);
            }

            int[] result = rawResult.ToArray();
            Array.Sort(result);
            return GroupAndCountAndSlice(result);
        }
    }
}
