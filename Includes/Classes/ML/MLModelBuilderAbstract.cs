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

        protected void InvokeProcessingStatus(String statusMessage)
        {
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
                s.Write($"\r\n=============== Saving the model  ===============");
                mlContext.Model.Save(mlModel, modelInputSchema, GetAbsolutePath(modelRelativePath));
                s.Write("\r\nThe model is saved to {0}", GetAbsolutePath(modelRelativePath));
                InvokeProcessingStatus(s.ToString());
            }
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
        protected void Evaluate(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline, String labelColumnName)
        {
            // Cross-Validate with single dataset (since we don't have two datasets, one for training and for evaluate)
            // in order to evaluate and get the model's accuracy metrics
            using (StringWriter s = new StringWriter())
            {
                s.Write("\r\n=============== Cross-validating to get model's accuracy metrics ===============");
                var crossValidationResults = mlContext.Regression.CrossValidate(trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: labelColumnName);
                InvokeProcessingStatus(s.ToString());
                PrintRegressionFoldsAverageMetrics(crossValidationResults);
            }
        }
    }
}
