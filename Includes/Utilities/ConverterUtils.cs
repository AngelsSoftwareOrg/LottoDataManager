using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Utilities
{
    public class ConverterUtils
    {

        public static NumberDirection ConvertToNumberDirection(int value)
        {
            foreach (int item in Enum.GetValues(typeof(NumberDirection)))
            {
                if (item == value) return (NumberDirection)item;
            }
            return NumberDirection.LEFT_TO_RIGHT;
        }

    }
}
