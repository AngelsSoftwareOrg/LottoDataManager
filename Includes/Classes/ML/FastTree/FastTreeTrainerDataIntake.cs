using LottoDataManager.Includes.Classes.ML.TrainerProcessor;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.FastTree
{
    public class FastTreeTrainerDataIntake: TrainerProcessorAbstract
    {
        private static String DATA_TABLE_HEADERS = "draw_date,num1,num2,num3,num4,num5,num6,game_cd,RESULT\r\n";
        private FastTreeTrainer fastTreeTrainer;

        public FastTreeTrainerDataIntake(LotteryDataServices lotteryDataServices): base(DATA_TABLE_HEADERS)
        {
            this.LotteryDataServices = lotteryDataServices;
            this.fastTreeTrainer = new FastTreeTrainer();
            this.fastTreeTrainer.ProcessingStatus += CommonTrainerInstanceEvent_ProcessingStatus;
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
            return LotteryDataServices.GetFastTreeMLDataSet(
                    trainerDataIntakeModel.GameMode, trainerDataIntakeModel.StartingDateTime).ToList<object>();
        }
        protected override String GetDataSetEntry(Object lotteryModel)
        {
            LotteryDrawResult model = (LotteryDrawResult)lotteryModel;
            return model.GetFastTreeTrainerModelDataIntake();
        }
        protected override void CreateTrainerModel(String fileName)
        {
            try
            {
                CommonCreateTrainerModel(fastTreeTrainer, fileName);
            }
            catch (Exception e)
            {
                log(e.StackTrace);
            }
        }
    }
}
