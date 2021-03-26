using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public class LotterySequenceGeneratorSetup : LotterySequenceGenerator
    {
        private int id;
        private int seqGenCode;
        private String description;
        public int ID { get => id; set => id = value; }
        public int SeqGenCode { get => seqGenCode; set => seqGenCode = value; }
        public string Description { get => description; set => description = value; }
        public string GetDescription()
        {
            return Description;
        }
        public int GetID()
        {
            return ID;
        }
        public int GetSeqGenCode()
        {
            return SeqGenCode;
        }
        override
        public String ToString()
        {
            return Description;
        }
    }
}
