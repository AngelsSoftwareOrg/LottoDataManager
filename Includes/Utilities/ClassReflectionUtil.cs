using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Classes.Generator;
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
        public static GeneratorType FindGeneratorType(int value)
        {
            foreach (int item in Enum.GetValues(typeof(GeneratorType)))
            {
                if (item == value) return (GeneratorType)item;
            }
            return GeneratorType.PERSONAL_PICK;
        }
        public static bool IsMainForm(Form formObj)
        {
            return (formObj is MainForm);
        }
        public static Form GetMainFormObj(Form form1, Form form2)
        {
            if (IsMainForm(form1)) return form1;
            if (IsMainForm(form2)) return form2;
            return null;
        }
    
    }
}
