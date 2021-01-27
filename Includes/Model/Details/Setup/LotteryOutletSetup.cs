using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public class LotteryOutletSetup: LotteryOutlet
    {
        private long id;
        private int outletCode;
        private String description;
        public long Id { get => id; set => id = value; }
        public int OutletCode { get => outletCode; set => outletCode = value; }
        public string Description { get => description; set => description = value; }
        public string GetDescription()
        {
            return Description;
        }
        public long GetId()
        {
            return Id;
        }
        public int GetOutletCode()
        {
            return OutletCode;
        }
        override
        public String ToString()
        {
            return Description;
        }
    }
}
