using LottoDataManager.Includes.Utilities;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML
{
    public abstract class MLModelBuilderAbstract
    {
        public event EventHandler<String> ProcessingStatus;
        public abstract void CreateModel(String mlDataSetsPath);
        protected void InvokeProcessingStatus(String statusMessage)
        {
            if (ProcessingStatus == null) return;
            ProcessingStatus.Invoke(this, statusMessage);
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
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_1"));
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_2"));
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_3"));
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_4") + $" {L1.Average():0.###} ");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_5") + $" {L2.Average():0.###} ");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_6") + $" {RMS.Average():0.###} ");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_7") + $" {lossFunction.Average():0.###} ");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_8") + $" {R2.Average():0.###} ");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_fold_ave_metrics_1"));
                InvokeProcessingStatus(s.ToString());
            }
        }
        public void PrintRegressionMetrics(RegressionMetrics metrics)
        {
            using (StringWriter s = new StringWriter())
            {
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_1"));
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_2"));
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_3"));
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_4") + $" {metrics.LossFunction:0.##}");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_5") + $" {metrics.RSquared:0.##}");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_6") + $" {metrics.MeanAbsoluteError:#.##}");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_7") + $" {metrics.MeanSquaredError:#.##}");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_8") + $" {metrics.RootMeanSquaredError:#.##}");
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_reg_metrics_1"));
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
        protected void SaveModel(MLContext mlContext, ITransformer mlModel, string modelRelativePath, DataViewSchema modelInputSchema)
        {
            using (StringWriter s = new StringWriter())
            {
                // Save/persist the trained model to a .ZIP file
                s.Write($"\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_save_model_1"));
                mlContext.Model.Save(mlModel, modelInputSchema, GetAbsolutePath(modelRelativePath));
                s.Write("\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_save_model_2"), GetAbsolutePath(modelRelativePath));
                InvokeProcessingStatus(s.ToString());
            }
        }
        public ITransformer RetrainModel(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            using (StringWriter s = new StringWriter())
            {
                s.Write("\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_train_model_1"));
                ITransformer model = trainingPipeline.Fit(trainingDataView);
                s.Write("\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_train_model_2"));
                return model;
            }
        }
        protected void Evaluate(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline, String labelColumnName)
        {
            // Cross-Validate with single dataset (since we don't have two datasets, one for training and for evaluate)
            // in order to evaluate and get the model's accuracy metrics
            using (StringWriter s = new StringWriter())
            {
                s.Write("\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_evaluate_model_1"));
                var crossValidationResults = mlContext.Regression.CrossValidate(trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: labelColumnName);
                InvokeProcessingStatus(s.ToString());
                PrintRegressionFoldsAverageMetrics(crossValidationResults);
            }
        }
    }
}
