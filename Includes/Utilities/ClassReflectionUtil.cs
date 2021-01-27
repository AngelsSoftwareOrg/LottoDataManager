using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Utilities
{
    public class ClassReflectionUtil
    {
        public static GameMode FindGameMode(int gameCode)
        {
            foreach (int item in Enum.GetValues(typeof(GameMode)))
            {
                if (item == gameCode) return (GameMode)item;
            }
            return GameMode.Mode_642;
        }
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
