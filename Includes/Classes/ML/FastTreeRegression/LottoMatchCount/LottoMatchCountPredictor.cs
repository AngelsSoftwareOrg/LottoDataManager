using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.FastTreeRegression
{
    public class LottoMatchCountPredictor : MLModelAbstract
    {
        private static readonly String MODEL_NAME = "MLModel_6H_LottoMatchCount.zip";
        public static readonly Lazy<PredictionEngine<LottoMatchCountInputModel, LottoMatchCountOutputModel>> 
            PredictEngine = new Lazy<PredictionEngine<LottoMatchCountInputModel, LottoMatchCountOutputModel>>(() => 
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
        /// Use this method to predict on <see cref="LottoMatchCountInputModel"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" LottoMatchCountOutputModel"/></returns>
        public static LottoMatchCountOutputModel Predict(LottoMatchCountInputModel input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<LottoMatchCountInputModel, LottoMatchCountOutputModel> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load (MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<LottoMatchCountInputModel, LottoMatchCountOutputModel>(mlModel);
        }

    }
}
