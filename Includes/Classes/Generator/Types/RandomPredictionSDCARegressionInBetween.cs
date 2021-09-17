using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes.ML.LightGbmRegression;
using LottoDataManager.Includes.Classes.ML.SDCARegression;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.Generator.Types
{
    public class RandomPredictionSDCARegressionInBetween : AbstractSequenceGenerator, SequenceGenerator
    {
        public RandomPredictionSDCARegressionInBetween(LotteryDataServices lotteryDataServices) : base(lotteryDataServices)
        {
            SeqGeneratorType = GeneratorType.RANDOM_PREDICTION_SDCA_REGRESSION_104_176;
            this.Description = ResourcesUtils.GetMessage("pick_class_random_prediction_sdca_reg_in_bet_desc");
            SequenceParams = new List<SequenceGeneratorParams>();
            SequenceParams.Add(new SequenceGeneratorParams()
            {
                GeneratorParamType = GeneratorParamType.COUNT,
                Description = ResourcesUtils.GetMessage("pick_class_random_prediction_sdca_reg_in_bet_count"),
                MaxCountValue = 999
            });
        }

        public bool AreParametersValueValid(out String errMessage)
        {
            return ValidateCountParamField(out errMessage, 0);
        }

        public List<int[]> GenerateSequence()
        {
            int maximumPickCount = GetFieldParamValueForCount(0);

            List<LotteryDrawResult> lotteryDrawResults = this.lotteryDataServices.GetLatestLotteryResult(maximumPickCount);
            String drawDate = DateTimeConverterUtils.ConvertToFormat(this.lotteryDataServices.GetNextDrawDate(),
                DateTimeConverterUtils.STANDARD_DATE_FORMAT) + " 00:00:00.0";
            List<int[]> results = new List<int[]>();

            foreach (LotteryDrawResult lotDraw in lotteryDrawResults)
            {
                SDCARegressionInputModel sampleData = lotDraw.GetSDCARegressionInputModel();
                var predictionResult = SDCARegressionPredictor.Predict(sampleData);

                //Console.WriteLine(String.Format("Data: {0}, {1},{2},{3},{4},{5},{6},{7},{8} ", sampleData.Draw_date,
                //    sampleData.Num1, sampleData.Num2, sampleData.Num3, sampleData.Num4, sampleData.Num5, sampleData.Num6,
                //    sampleData.Game_cd.ToString(), predictionResult.Score.ToString()));

                int totalSum = int.Parse(Math.Ceiling(decimal.Parse(predictionResult.Score.ToString())).ToString());
                if(totalSum>=IN_BETWEEN_SUM_MIN && totalSum <= IN_BETWEEN_SUM_MAX)
                {
                    int[] x = ConvertAndFillSequenceThatMakesUpToTotalSum(totalSum);
                    if (IsUniqueSequence(results, x)) results.Add(x);
                }
            }
            return results;
        }

        private int[] ConvertAndFillSequenceThatMakesUpToTotalSum(int totalSum)
        {
            int[] result = new int[this.lotteryTicketPanel.GetGameDigitCount()];

            Random rand = new Random();
            int arr_position = 0;
            while (true)
            {
                int random_n = rand.Next(this.lotteryTicketPanel.GetMin(), this.lotteryTicketPanel.GetMax());
                if (result.Sum() < totalSum)
                {
                    if (result.Contains(random_n)) continue;
                    if (random_n >= this.lotteryTicketPanel.GetMin() && random_n <= this.lotteryTicketPanel.GetMax())
                        result[arr_position] = random_n;
                    else
                        continue;
                }

                //if there's only 1 more slot to fill up, maybe try to put the difference instead of random number
                if(arr_position == (this.lotteryTicketPanel.GetGameDigitCount() - 2))
                {
                    if (result.Sum() < totalSum)
                    {
                        int leftDiff = totalSum - result.Sum();
                        if (leftDiff > this.lotteryTicketPanel.GetMax())
                            leftDiff = leftDiff - this.lotteryTicketPanel.GetMax();
                        if (leftDiff <=0) continue;
                        if (result.Contains(leftDiff)) continue;
                        result[++arr_position] = leftDiff;
                        if (result.Sum() == totalSum) break;
                    }
                }
                arr_position++;

                //if over value, then repeat again
                if (arr_position >= this.lotteryTicketPanel.GetGameDigitCount())
                {
                    if (result.Sum() == totalSum && !result.Contains(0)) break;
                    result = new int[this.lotteryTicketPanel.GetGameDigitCount()];
                    arr_position = 0;
                }
            }
            Array.Sort(result);
            return result;
        }
    }
}
