// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.ML;
using LottoDataManagerML.Model;

namespace LottoDataManager.Includes.Classes.ML.FastTree
{
    public class ConsumeModelFastTree: MLModelAbstract
    {
        private static Lazy<PredictionEngine<ModelInputFastTree, ModelOutputFastTree>> PredictionEngine = new Lazy<PredictionEngine<ModelInputFastTree, ModelOutputFastTree>>(CreatePredictionEngine);
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
        public static ModelOutputFastTree Predict(ModelInputFastTree input)
        {
            ModelOutputFastTree result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<ModelInputFastTree, ModelOutputFastTree> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInputFastTree, ModelOutputFastTree>(mlModel);

            return predEngine;
        }
    }
}