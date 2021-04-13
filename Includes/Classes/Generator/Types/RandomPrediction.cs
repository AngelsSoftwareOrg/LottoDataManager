using System;
using System.Collections.Generic;
using LottoDataManager.Includes.Classes.ML.FastTree;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomPrediction : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomPrediction(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.RANDOM_PREDICTION;
            this.Description = ResourcesUtils.GetMessage("pick_class_random_prediction_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_random_prediction_count"),
                MaxCountValue = 999

            });
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = @ResourcesUtils.GetMessage("pick_class_random_prediction_coefficient"),
                MaxCountValue = 20
            });
        }

        public bool AreParametersValueValid(out String errMessage)
        {
            return ValidateCountParamField(out errMessage, 0) && ValidateCountParamField(out errMessage, 1);
        }

        public List<int[]> GenerateSequence()
        {
            String drawDate = DateTimeConverterUtils.ConvertToFormat(this.lotteryDataServices.GetNextDrawDate(), 
                                    DateTimeConverterUtils.STANDARD_DATE_FORMAT) + " 00:00:00.0";
            List<int[]> results = new List<int[]>();

            int selectedCoefficient = GetFieldParamValueForCount(1);
            int maximumPickCount = GetFieldParamValueForCount(0);
            Random rnd = new Random();

            int loopBreaker = 0;
            while (true)
            {
                int[] lp = LuckyPickGenerator(rnd);

                // Create single instance of sample data from first line of dataset for model input
                ModelInputFastTree sampleData = new ModelInputFastTree()
                {
                    Draw_date = drawDate,
                    Num1 = lp[0],
                    Num2 = lp[1],
                    Num3 = lp[2],
                    Num4 = lp[3],
                    Num5 = lp[4],
                    Num6 = lp[5],
                    Game_cd = this.lotteryDataServices.LotteryDetails.GameCode
                };

                // Make a single prediction on the sample data and print results
                var predictionResult = ConsumeModelFastTree.Predict(sampleData);

                //Console.WriteLine(String.Format("Data: {0}, {1},{2},{3},{4},{5},{6},{7},{8} ", sampleData.Draw_date,
                //    sampleData.Num1, sampleData.Num2, sampleData.Num3, sampleData.Num4, sampleData.Num5, sampleData.Num6,
                //    sampleData.Game_cd.ToString(), predictionResult.Score.ToString()));

                float tmpScore = predictionResult.Score;
                if (tmpScore <= 0) tmpScore = (tmpScore * -1) + 1;

                if (int.Parse(tmpScore.ToString().Substring(0, 1)) >= selectedCoefficient)
                {
                    if (IsUniqueSequence(results, lp)) results.Add(lp);
                }
                if (loopBreaker++ >= 100000) break;
                if (results.Count >= maximumPickCount) break;
            }
            return results;
        }
    }
}
