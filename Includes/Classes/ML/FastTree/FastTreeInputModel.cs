// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace LottoDataManager.Includes.Classes.ML.FastTree
{
    public class FastTreeInputModel
    {
        [ColumnName("draw_date"), LoadColumn(0)]
        public string Draw_date { get; set; }


        [ColumnName("num1"), LoadColumn(1)]
        public float Num1 { get; set; }


        [ColumnName("num2"), LoadColumn(2)]
        public float Num2 { get; set; }


        [ColumnName("num3"), LoadColumn(3)]
        public float Num3 { get; set; }


        [ColumnName("num4"), LoadColumn(4)]
        public float Num4 { get; set; }


        [ColumnName("num5"), LoadColumn(5)]
        public float Num5 { get; set; }


        [ColumnName("num6"), LoadColumn(6)]
        public float Num6 { get; set; }


        [ColumnName("game_cd"), LoadColumn(7)]
        public float Game_cd { get; set; }


        [ColumnName("RESULT"), LoadColumn(8)]
        public float RESULT { get; set; }


    }
}
