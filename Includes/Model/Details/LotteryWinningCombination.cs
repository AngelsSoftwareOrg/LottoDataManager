﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryWinningCombination
    {
        double GetMatch0();
        double GetMatch1();
        double GetMatch2();
        double GetMatch3();
        double GetMatch4();
        double GetMatch5();
        double GetMatch6();
    }
}
