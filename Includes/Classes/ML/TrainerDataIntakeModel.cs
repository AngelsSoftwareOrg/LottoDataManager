using LottoDataManager.Includes.Model.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML
{
    public class TrainerDataIntakeModel
    {
        private GameMode gameMode;
        private DateTime startingDateTime;
        public GameMode GameMode { get => gameMode; set => gameMode = value; }
        public DateTime StartingDateTime { get => startingDateTime; set => startingDateTime = value; }
    }
}
