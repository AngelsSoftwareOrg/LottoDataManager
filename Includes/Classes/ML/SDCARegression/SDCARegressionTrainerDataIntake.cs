using LottoDataManager.Includes.Classes.ML.TrainerProcessor;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.SDCARegression
{
    public class SDCARegressionTrainerDataIntake: TrainerProcessorAbstract
    {
        private static String DATA_TABLE_HEADERS = "draw_date,num1,num2,num3,num4,num5,num6,PREDICT,winners,game_cd\r\n";
        private SDCARegressionTrainer sdcaRegressionTrainer;

        public SDCARegressionTrainerDataIntake(LotteryDataServices lotteryDataServices) : base(DATA_TABLE_HEADERS)
        {
            this.LotteryDataServices = lotteryDataServices;
            this.sdcaRegressionTrainer = new SDCARegressionTrainer();
            this.sdcaRegressionTrainer.ProcessingStatus += CommonTrainerInstanceEvent_ProcessingStatus;
        }

        public override void StartUpdate()
        {
            CommonTrainerModelDrawResults();
        }
        protected override DateTime GetDrawDateEquivalent(Object lotteryObject)
        {
            LotteryDrawResult result = (LotteryDrawResult)lotteryObject;
            return result.GetDrawDate();
        }
        protected override List<Object> GetTrainerDataSets(TrainerDataIntakeModel trainerDataIntakeModel)
        {
            return LotteryDataServices.GetSDCAMLDataSet(
                    trainerDataIntakeModel.GameMode, trainerDataIntakeModel.StartingDateTime).ToList<object>();
        }
        protected override String GetDataSetEntry(Object lotteryModel)
        {
            LotteryDrawResult model = (LotteryDrawResult)lotteryModel;
            return model.GetSCDARegressionModelDataIntake();
        }

        protected override void CreateTrainerModel(String fileName)
        {
            try
            {
                CommonCreateTrainerModel(sdcaRegressionTrainer, fileName);
            }
            catch (Exception e)
            {
                log(e.StackTrace);
            }
        }
    }
}
