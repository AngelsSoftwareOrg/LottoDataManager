using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model
{
    class Game658: LotteryDetails
    {
        public Game658(): base(GameMode.Mode_658, ResourcesUtils.GetMessage("lott_details_cls_msg_5"))
        {
        }
    }
}
