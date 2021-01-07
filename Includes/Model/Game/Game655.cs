using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    class Game655: LotteryDetails
    {
        public Game655(): base(GameMode.Mode_655, "Lotto 6/55")
        {
        }
    }
}
