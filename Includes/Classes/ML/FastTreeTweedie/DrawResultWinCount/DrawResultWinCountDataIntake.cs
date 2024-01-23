using LottoDataManager.Includes.Classes.ML.TrainerProcessor;
using LottoDataManager.Includes.Model.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.FastTreeTweedie.DrawResultWinCount
{
    public class DrawResultWinCountDataIntake : TrainerProcessorAbstract
    {
        private static String DATA_TABLE_HEADERS = "game_cd,draw_date,num1,num2,num3,num4,num5,num6,draw_result\r\n";
        private DrawResultWinCountTrainer drawResultWinCountTrainer;

        public DrawResultWinCountDataIntake(LotteryDataServices lotteryDataServices) : base(DATA_TABLE_HEADERS)
        {
            this.LotteryDataServices = lotteryDataServices;
            this.drawResultWinCountTrainer = new DrawResultWinCountTrainer();
            this.drawResultWinCountTrainer.ProcessingStatus += CommonTrainerInstanceEvent_ProcessingStatus;
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
            return LotteryDataServices.GetDrawResultWinCountMLDataset(
                    trainerDataIntakeModel.GameMode, trainerDataIntakeModel.StartingDateTime).ToList<object>();
        }
        protected override String GetDataSetEntry(Object lotteryModel)
        {
            LotteryDrawResult model = (LotteryDrawResult)lotteryModel;
            return model.GetDrawResultWinCountModelDataIntake();
        }
        protected override void CreateTrainerModel(String fileName)
        {
            try
            {
                CommonCreateTrainerModel(drawResultWinCountTrainer, fileName);
            }
            catch (Exception e)
            {
                log(e.StackTrace);
            }
        }
    }
}
