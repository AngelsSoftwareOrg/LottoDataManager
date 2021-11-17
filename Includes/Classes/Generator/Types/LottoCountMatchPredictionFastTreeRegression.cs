using LottoDataManager.Includes.Classes.ML.FastTreeRegression;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class LottoCountMatchPredictionFastTreeRegression : AbstractSequenceGenerator, SequenceGenerator
    {
        public LottoCountMatchPredictionFastTreeRegression(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.LOTTO_MATCH_COUNT_PREDICTION_FAST_TREE_REGRESSION;
            this.Description = ResourcesUtils.GetMessage("pick_class_lotto_count_match_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_lotto_count_match_lp_count"),
                MaxCountValue = 99
            });
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = @ResourcesUtils.GetMessage("pick_class_lotto_count_match_perc"),
                MaxCountValue = 100
            });
        }

        public bool AreParametersValueValid(out string errMessage)
        {
            return ValidateCountParamField(out errMessage, 0)
                    && ValidateCountParamField(out errMessage, 1);
        }

        public List<int[]> GenerateSequence()
        {
            StartPickGeneration();
            int maximumPickCount = GetFieldParamValueForCount(0);
            int matchPerc = GetFieldParamValueForCount(1);
            int maxLoopBreaker = int.MaxValue - 100;
            int maxLoopCtr = 0;
            List<int[]> results = new List<int[]>();
            LottoMatchCountInputModel sampleData;
            LotteryBetSetup lotteryBet = new LotteryBetSetup();
            lotteryBet.GameCode = lotteryDataServices.LotteryDetails.GameCode;
            Random ran = new Random();

            while (results.Count < maximumPickCount)
            {
                int[] randomSeq = LuckyPickGenerator(ran);
                lotteryBet.ResetSequenceToZero();
                lotteryBet.FillNumberBySeq(randomSeq);
                sampleData = lotteryBet.GetLottoMatchCountInputModel();
                LottoMatchCountOutputModel output = LottoMatchCountPredictor.Predict(sampleData);
                int score = (int)(output.Score * 100);
                PickGenerationProgressEvent.IncrementGenerationAttemptCount();
                if (score >= matchPerc)
                {
                    Array.Sort(randomSeq);
                    results.Add(randomSeq);
                    PickGenerationProgressEvent.IncrementGeneratedPickCount();
                }
                if (!IsContinuePickGenerationProgress()) break;
                if (maxLoopCtr++ > maxLoopBreaker) break;
            }
            return results;
        }
    }
}
