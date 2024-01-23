using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.FastTreeTweedie.DrawResultWinCount
{
    public class DrawResultWinCountPredictor : MLModelAbstract
    {
        private static readonly String MODEL_NAME = "MLModel_5H_DrawResultWinCount.zip";
        public static readonly Lazy<PredictionEngine<DrawResultWinCountInputModel, DrawResultWinCountOutputModel>>
            PredictEngine = new Lazy<PredictionEngine<DrawResultWinCountInputModel, DrawResultWinCountOutputModel>>(() =>
                CreatePredictEngine(), true);

        public static String MLNetModelPath
        {
            get
            {
                return GetCompleteModelPath(MODEL_NAME);
            }
        }

        public static bool IsMLModelExisting(String folderPath = null)
        {
            return IsModelExists(MODEL_NAME, folderPath);
        }


        /// <summary>
        /// Use this method to predict on <see cref="DrawResultWinCountOutputModel"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" DrawResultWinCountInputModel"/></returns>
        public static DrawResultWinCountOutputModel Predict(DrawResultWinCountInputModel input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<DrawResultWinCountInputModel, DrawResultWinCountOutputModel> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<DrawResultWinCountInputModel, DrawResultWinCountOutputModel>(mlModel);
        }

    }
}
