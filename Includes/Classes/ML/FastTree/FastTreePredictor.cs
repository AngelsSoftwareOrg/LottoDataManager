// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.ML;

namespace LottoDataManager.Includes.Classes.ML.FastTree
{
    public class FastTreePredictor: MLModelAbstract
    {
        private static Lazy<PredictionEngine<FastTreeInputModel, FastTreeOutputModel>> PredictionEngine = new Lazy<PredictionEngine<FastTreeInputModel, FastTreeOutputModel>>(CreatePredictionEngine);
        private static readonly String MODEL_NAME = "MLModel_14_3H_Fast_Tree.zip";

        public static String MLNetModelPath
        {
            get
            {
                return GetCompleteModelPath(MODEL_NAME);
            }
        }

        public static bool IsMLModelExisting(String folderPath=null)
        {
            return IsModelExists(MODEL_NAME, folderPath);
        }

        // For more info on consuming ML.NET models, visit https://aka.ms/mlnet-consume
        // Method for consuming model in your app
        public static FastTreeOutputModel Predict(FastTreeInputModel input)
        {
            FastTreeOutputModel result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<FastTreeInputModel, FastTreeOutputModel> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<FastTreeInputModel, FastTreeOutputModel>(mlModel);

            return predEngine;
        }
    }
}