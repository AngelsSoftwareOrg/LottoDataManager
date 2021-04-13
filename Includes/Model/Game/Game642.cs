﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Model
{
    class Game642: LotteryDetails
    {
        public Game642(): base(GameMode.Mode_642, ResourcesUtils.GetMessage("lott_details_cls_msg_1"))
        {
        }
    }
}
