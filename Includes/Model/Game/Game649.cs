using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    class Game649: LotteryDetails
    {
        public Game649(): base(GameMode.Mode_649, "Lotto 6/49")
        {
        }
    }
}
