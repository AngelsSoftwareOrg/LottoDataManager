using LottoDataManager.Includes.Utilities;
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.FastTreeTweedie.DrawResultWinCount
{
    public class DrawResultWinCountTrainer : MLModelBuilderAbstract
    {
        private static string MODEL_FILE = DrawResultWinCountPredictor.MLNetModelPath;
        private static string OUTPUT_COLUMN_NAME = "draw_result";

        // Create MLContext to be shared across the model creation workflow objects 
        // Set a random seed for repeatable/deterministic results across multiple trainings.
        private static MLContext mlContext = new MLContext(seed: 1);

        public override void CreateModel(String mlDataSetsPath)
        {
            // Load Data
            InvokeProcessingStatus(ResourcesUtils.GetMessage("mac_lrn_bldr_log_1"));
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<DrawResultWinCountInputModel>(
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
            ITransformer mlModel = RetrainModel(mlContext, trainingDataView, trainingPipeline);

            // Evaluate quality of Model
            InvokeProcessingStatus(ResourcesUtils.GetMessage("mac_lrn_bldr_log_4"));
            Evaluate(mlContext, trainingDataView, trainingPipeline, OUTPUT_COLUMN_NAME);

            // Save model
            InvokeProcessingStatus("\r\n\r\n\r\n" + ResourcesUtils.GetMessage("mac_lrn_bldr_log_5"));
            SaveModel(mlContext, mlModel, MODEL_FILE, trainingDataView.Schema);
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildTrainingPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new[] { new InputOutputColumnPair(@"game_cd", @"game_cd"), new InputOutputColumnPair(@"num1", @"num1"), new InputOutputColumnPair(@"num2", @"num2"), new InputOutputColumnPair(@"num3", @"num3"), new InputOutputColumnPair(@"num4", @"num4"), new InputOutputColumnPair(@"num5", @"num5"), new InputOutputColumnPair(@"num6", @"num6") })
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"draw_date", @"draw_date"))
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new[] { @"game_cd", @"num1", @"num2", @"num3", @"num4", @"num5", @"num6", @"draw_date" }))
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))
                                    .Append(mlContext.Regression.Trainers.FastTreeTweedie(new FastTreeTweedieTrainer.Options() { NumberOfLeaves = 4, MinimumExampleCountPerLeaf = 128, NumberOfTrees = 3605, MaximumBinCountPerFeature = 47, LearningRate = 0.00365027684249047F, FeatureFraction = 0.845581925532354F, LabelColumnName = @"draw_result", FeatureColumnName = @"Features" }));

            return pipeline;
        }
    }
}
