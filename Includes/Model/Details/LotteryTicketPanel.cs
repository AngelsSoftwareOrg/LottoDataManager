using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Model.Details
{
    public interface LotteryTicketPanel
    {
        NumberDirection GetNumberDirection();
        int GetRows();
        int GetCols();
        int GetMin();
        int GetMax();
        int GetGameDigitCount();
    }
}
