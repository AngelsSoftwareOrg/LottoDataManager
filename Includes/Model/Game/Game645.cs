using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model
{
    class Game645: LotteryDetails
    {
        public Game645(): base(GameMode.Mode_645, "Lotto 6/45")
        {
        }
    }
}
