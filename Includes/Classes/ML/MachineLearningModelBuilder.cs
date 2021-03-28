// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using LottoDataManagerML.Model;
using Microsoft.ML.Trainers.FastTree;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes.ML
{
    public class MachineLearningModelBuilder
    {
        public event EventHandler<String> ProcessingStatus;
        //private static string TRAIN_DATA_FILEPATH = @"D:\Development\WorkSpace00002\LottoDataManager\DatabaseMain\ml_data_sets.csv";
        private static string MODEL_FILE = ConsumeModel.MLNetModelPath;

        // Create MLContext to be shared across the model creation workflow objects 
        // Set a random seed for repeatable/deterministic results across multiple trainings.
        private static MLContext mlContext = new MLContext(seed: 1);

        public void CreateModel(String mlDataSetsPath)
        {
            // Load Data
            InvokeProcessingStatus(ResourcesUtils.GetMessage("mac_lrn_bldr_log_1"));
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            //path: TRAIN_DATA_FILEPATH,
                                            path: @mlDataSetsPath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);
            // Build training pipeline
            InvokeProcessingStatus(ResourcesUtils.GetMessage("mac_lrn_bldr_log_2"));
            IEstimator<ITransformer> trainingPipeline = BuildTrainingPipeline(mlContext);

            // Train Model
            InvokeProcessingStatus(ResourcesUtils.GetMessage("mac_lrn_bldr_log_3"));
            ITransformer mlModel = TrainModel(mlContext, trainingDataView, trainingPipeline);

            // Evaluate quality of Model
            InvokeProcessingStatus(ResourcesUtils.GetMessage("mac_lrn_bldr_log_4"));
            Evaluate(mlContext, trainingDataView, trainingPipeline);

            // Save model
            InvokeProcessingStatus("\r\n\r\n\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_log_5"));
            SaveModel(mlContext, mlModel, MODEL_FILE, trainingDataView.Schema);
        }

        public IEstimator<ITransformer> BuildTrainingPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations 
            var dataProcessPipeline = mlContext.Transforms.Categorical.OneHotHashEncoding(new[] { new InputOutputColumnPair("game_cd", "game_cd") })
                                      .Append(mlContext.Transforms.Text.FeaturizeText("draw_date_tf", "draw_date"))
                                      .Append(mlContext.Transforms.Concatenate("Features", new[] { "game_cd", "draw_date_tf", "num1", "num2", "num3", "num4", "num5", "num6" }));
            // Set the training algorithm 
            var trainer = mlContext.Regression.Trainers.FastTree(new FastTreeRegressionTrainer.Options() { NumberOfLeaves = 19, MinimumExampleCountPerLeaf = 10, NumberOfTrees = 500, LearningRate = 0.09198709f, Shrinkage = 0.2990312f, LabelColumnName = @"RESULT", FeatureColumnName = "Features" });

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            return trainingPipeline;
        }

        public ITransformer TrainModel(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            using (StringWriter s = new StringWriter())
            { 
                s.Write("\r\n=============== Training  model ===============");
                ITransformer model = trainingPipeline.Fit(trainingDataView);
                s.Write("\r\n=============== End of training process ===============");
                return model;
            }
        }

        private void Evaluate(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            // Cross-Validate with single dataset (since we don't have two datasets, one for training and for evaluate)
            // in order to evaluate and get the model's accuracy metrics
            using (StringWriter s = new StringWriter())
            {
                s.Write("\r\n=============== Cross-validating to get model's accuracy metrics ===============");
                var crossValidationResults = mlContext.Regression.CrossValidate(trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: "RESULT");
                InvokeProcessingStatus(s.ToString());
                PrintRegressionFoldsAverageMetrics(crossValidationResults);
            }
        }

        private void SaveModel(MLContext mlContext, ITransformer mlModel, string modelRelativePath, DataViewSchema modelInputSchema)
        {
            using (StringWriter s = new StringWriter())
            {
                // Save/persist the trained model to a .ZIP file
                s.Write($"\r\n=============== Saving the model  ===============");
                mlContext.Model.Save(mlModel, modelInputSchema, GetAbsolutePath(modelRelativePath));
                s.Write("\r\nThe model is saved to {0}", GetAbsolutePath(modelRelativePath));
                InvokeProcessingStatus(s.ToString());
            }
        }

        public string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }

        public void PrintRegressionMetrics(RegressionMetrics metrics)
        {
            using (StringWriter s = new StringWriter())
            {
                s.Write($"\r\n*************************************************");
                s.Write($"\r\n*       Metrics for Regression model      ");
                s.Write($"\r\n*------------------------------------------------");
                s.Write($"\r\n*       LossFn:        {metrics.LossFunction:0.##}");
                s.Write($"\r\n*       R2 Score:      {metrics.RSquared:0.##}");
                s.Write($"\r\n*       Absolute loss: {metrics.MeanAbsoluteError:#.##}");
                s.Write($"\r\n*       Squared loss:  {metrics.MeanSquaredError:#.##}");
                s.Write($"\r\n*       RMS loss:      {metrics.RootMeanSquaredError:#.##}");
                s.Write($"\r\n*************************************************");
                InvokeProcessingStatus(s.ToString());
            }
        }

        public void PrintRegressionFoldsAverageMetrics(IEnumerable<TrainCatalogBase.CrossValidationResult<RegressionMetrics>> crossValidationResults)
        {
            var L1 = crossValidationResults.Select(r => r.Metrics.MeanAbsoluteError);
            var L2 = crossValidationResults.Select(r => r.Metrics.MeanSquaredError);
            var RMS = crossValidationResults.Select(r => r.Metrics.RootMeanSquaredError);
            var lossFunction = crossValidationResults.Select(r => r.Metrics.LossFunction);
            var R2 = crossValidationResults.Select(r => r.Metrics.RSquared);

            using (StringWriter s = new StringWriter())
            {
                s.Write($"\r\n*************************************************************************************************************");
                s.Write($"\r\n*       Metrics for Regression model      ");
                s.Write($"\r\n*------------------------------------------------------------------------------------------------------------");
                s.Write($"\r\n*       Average L1 Loss:       {L1.Average():0.###} ");
                s.Write($"\r\n*       Average L2 Loss:       {L2.Average():0.###}  ");
                s.Write($"\r\n*       Average RMS:           {RMS.Average():0.###}  ");
                s.Write($"\r\n*       Average Loss Function: {lossFunction.Average():0.###}  ");
                s.Write($"\r\n*       Average R-squared:     {R2.Average():0.###}  ");
                s.Write($"\r\n*************************************************************************************************************");
                InvokeProcessingStatus(s.ToString());
            }
        }

        private void InvokeProcessingStatus(String statusMessage)
        {
            ProcessingStatus.Invoke(this, statusMessage);
        }
    }
}