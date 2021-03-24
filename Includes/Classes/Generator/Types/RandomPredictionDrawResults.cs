using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using LottoDataManagerML.Model;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomPredictionDrawResults : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomPredictionDrawResults(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.RANDOM_PREDICTION_DRAW_RESULT;
            this.Description = ResourcesUtils.GetMessage("pick_class_random_prediction_dr_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_random_prediction_dr_count"),
                MaxCountValue=9999
            });
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = @ResourcesUtils.GetMessage("pick_class_random_prediction_dr_coefficient"),
                MaxCountValue = 20
            });
        }

        public bool AreParametersValueValid(out String errMessage)
        {
            return ValidateCountParamField(out errMessage, 0) && ValidateCountParamField(out errMessage, 1);
        }

        public List<int[]> GenerateSequence()
        {
            int maximumPickCount = GetFieldParamValueForCount(0);
            int selectedCoefficient = GetFieldParamValueForCount(1);

            List<LotteryDrawResult> lotteryDrawResults = this.lotteryDataServices.GetLatestLotteryResult(maximumPickCount);
            String drawDate = DateTimeConverterUtils.ConvertToFormat(this.lotteryDataServices.GetNextDrawDate(), 
                DateTimeConverterUtils.STANDARD_DATE_FORMAT) + " 00:00:00.0";
            List<int[]> results = new List<int[]>();

            foreach(LotteryDrawResult lotDraw in lotteryDrawResults)
            {
                ModelInput sampleData = lotDraw.GetModelInput();
                var predictionResult = ConsumeModel.Predict(sampleData);

/*                Console.WriteLine(String.Format("Data: {0}, {1},{2},{3},{4},{5},{6},{7},{8} ", sampleData.Draw_date,
                    sampleData.Num1, sampleData.Num2, sampleData.Num3, sampleData.Num4, sampleData.Num5, sampleData.Num6,
                    sampleData.Game_cd.ToString(), predictionResult.Score.ToString()));*/

                if (int.Parse(predictionResult.Score.ToString().Substring(0, 1)) >= selectedCoefficient)
                {
                    results.Add(lotDraw.GetAllNumberSequenceSorted());
                }
            }

            return results;
        }
    }
}
