using LottoDataManager.Includes.Classes.ML.FastTreeTweedie.DrawResultWinCount;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class DrawResultWinCountFastTreeTweedieRandomGenerator : AbstractSequenceGenerator, SequenceGenerator
    {
        public DrawResultWinCountFastTreeTweedieRandomGenerator(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.DRAW_RESULT_WIN_COUNT_PREDICTION_FAST_TREE_REGRESSION;
            this.Description = ResourcesUtils.GetMessage("pick_class_draw_result_win_count_match_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
        {
            GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_draw_result_win_count_match_lp_count"),
                MaxCountValue = 99
            });
            SequenceParams.Add(new SequenceGeneratorParams()
        {
            GeneratorParamType = GeneratorParamType.COUNT,
                Description = @ResourcesUtils.GetMessage("pick_class_draw_result_win_count_match_perc"),
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
        int maximumPickCount = GetFieldParamValueForCount(0);
        int matchPerc = GetFieldParamValueForCount(1);
        int maxLoopBreaker = 10000;
        int maxLoopCtr = 0;
        List<int[]> results = new List<int[]>();
        DrawResultWinCountInputModel sampleData;
        LotteryDrawResultSetup lotteryDrawResult = new LotteryDrawResultSetup();
        lotteryDrawResult.GameCode = lotteryDataServices.LotteryDetails.GameCode;
        Random ran = new Random();

        while (results.Count < maximumPickCount)
        {
            int[] randomSeq = LuckyPickGenerator(ran);
            lotteryDrawResult.ResetSequenceToZero();
            lotteryDrawResult.FillNumberBySeq(randomSeq);
            sampleData = lotteryDrawResult.GetDrawResultWinCountInputModel(true);
            DrawResultWinCountOutputModel output = DrawResultWinCountPredictor.Predict(sampleData);
            int score = (int)(output.Score * 100);

            if (score >= matchPerc)
            {
                Array.Sort(randomSeq);
                results.Add(randomSeq);
            }
            if (maxLoopCtr++ > maxLoopBreaker) break;
        }
        return results;
    }
}
}
