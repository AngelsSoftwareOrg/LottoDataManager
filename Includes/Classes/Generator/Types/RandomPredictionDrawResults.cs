using System;
using System.Collections.Generic;
using System.Linq;
using LottoDataManager.Includes.Classes.ML.FastTree;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;


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
                Description = ResourcesUtils.GetMessage("pick_class_random_prediction_fasttree_count"),
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
                ModelInputFastTree sampleData = lotDraw.GetModelInput();
                var predictionResult = ConsumeModelFastTree.Predict(sampleData);

                //Console.WriteLine(String.Format("Data: {0}, {1},{2},{3},{4},{5},{6},{7},{8} ", sampleData.Draw_date,
                //    sampleData.Num1, sampleData.Num2, sampleData.Num3, sampleData.Num4, sampleData.Num5, sampleData.Num6,
                //    sampleData.Game_cd.ToString(), predictionResult.Score.ToString("G20")));

                float tmpScore = predictionResult.Score;
                if (tmpScore <= 0) tmpScore = (tmpScore * -1) + 1;
                if (int.Parse(tmpScore.ToString("G20").Substring(0, 1)) >= selectedCoefficient)
                {
                    int[] x = ConvertAndFillSequence(predictionResult.Score);
                    if (IsUniqueSequence(results, x)) results.Add(x);
                }
            }
            return results;
        }

        private int[] ConvertAndFillSequence(float sourceNum)
        {
            int[] result = new int[this.lotteryTicketPanel.GetGameDigitCount()];
            String numbers = GetNumbersOnly(sourceNum);
            if (numbers.Length < 12) numbers = numbers.PadLeft(12, char.Parse("0"));

            Random rand = new Random();
            int x = 0;
            while (true)
            {
                int n = int.Parse(numbers.Substring(x, 2));
                if (n < this.lotteryTicketPanel.GetMin()) n = rand.Next(this.lotteryTicketPanel.GetMin(), this.lotteryTicketPanel.GetMax());
                if (n > this.lotteryTicketPanel.GetMax()) n = n - (this.lotteryTicketPanel.GetMax() % n);

                while (true)
                {
                    if (result.Contains(n)) n++;
                    if (n < this.lotteryTicketPanel.GetMin() || n > this.lotteryTicketPanel.GetMax())
                    {
                        n = rand.Next(this.lotteryTicketPanel.GetMin(), this.lotteryTicketPanel.GetMax());
                    }

                    if (!result.Contains(n))
                    {
                        result[x / 2] = n;
                        break;
                    }
                    if (n == 0)
                        Console.WriteLine(true);
                }
                x += 2;
                if ((x + 2) > numbers.Length) break;
            }
            Array.Sort(result);
            return result;
        }
    }
}
