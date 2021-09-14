// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.ML;


namespace LottoDataManager.Includes.Classes.ML.SDCARegression
{
    public class SDCARegressionPredictor: MLModelAbstract
    {
        private static Lazy<PredictionEngine<SDCARegressionInputModel, SDCARegressionOutputModel>> PredictionEngine = new Lazy<PredictionEngine<SDCARegressionInputModel, SDCARegressionOutputModel>>(CreatePredictionEngine);
        private static readonly String MODEL_NAME = "MLModel_16_3H_SdcaRegression.zip";

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

        // For more info on consuming ML.NET models, visit https://aka.ms/mlnet-consume
        // Method for consuming model in your app
        public static SDCARegressionOutputModel Predict(SDCARegressionInputModel input)
        {
            SDCARegressionOutputModel result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<SDCARegressionInputModel, SDCARegressionOutputModel> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<SDCARegressionInputModel, SDCARegressionOutputModel>(mlModel);

            return predEngine;
        }
    }
}