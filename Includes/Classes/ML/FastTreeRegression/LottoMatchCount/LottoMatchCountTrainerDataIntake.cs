using LottoDataManager.Includes.Classes.ML.TrainerProcessor;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML.FastTreeRegression.LottoMatchCount
{
    public class LottoMatchCountTrainerDataIntake : TrainerProcessorAbstract
    {
        private static String DATA_TABLE_HEADERS = "game_cd,num1,num2,num3,num4,num5,num6,match_cnt\r\n";
        private LottoMatchCountTrainer lottoMatchCountTrainer;

        public LottoMatchCountTrainerDataIntake(LotteryDataServices lotteryDataServices) : base(DATA_TABLE_HEADERS)
        {
            this.LotteryDataServices = lotteryDataServices;
            this.lottoMatchCountTrainer = new LottoMatchCountTrainer();
            this.lottoMatchCountTrainer.ProcessingStatus += CommonTrainerInstanceEvent_ProcessingStatus;
        }

        public override void StartUpdate()
        {
            CommonTrainerModelDrawResults();
        }
        protected override DateTime GetDrawDateEquivalent(Object lotteryObject)
        {
            LotteryBet result = (LotteryBet)lotteryObject;
            return result.GetTargetDrawDate();
        }
        protected override List<Object> GetTrainerDataSets(TrainerDataIntakeModel trainerDataIntakeModel)
        {
            return LotteryDataServices.GetLottoCountMatchMLDataset(
                    trainerDataIntakeModel.GameMode, trainerDataIntakeModel.StartingDateTime).ToList<object>();
        }
        protected override String GetDataSetEntry(Object lotteryModel)
        {
            LotteryBet model = (LotteryBet)lotteryModel;
            return model.GetLottoMatchCountTrainerModelDataIntake();
        }
        protected override void CreateTrainerModel(String fileName)
        {
            try
            {
                CommonCreateTrainerModel(lottoMatchCountTrainer, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                log(e.StackTrace);
            }
        }
    }
}
