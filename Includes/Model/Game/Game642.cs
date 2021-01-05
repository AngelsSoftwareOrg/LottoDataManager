using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    class Game642: LotteryDetails
    {
        public Game642(): base(GameMode.Mode_642, "Lotto 6/42")
        {
        }
    }
}
