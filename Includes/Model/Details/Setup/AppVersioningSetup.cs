using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details.Setup
{
    public class AppVersioningSetup: AppVersioning
    {
        private int Id;
        private int major;
        private int minor;
        private int fix;
        private int patch;
        private String releaseCycle;
        private String remarks;
        private DateTime dateTimeApplied;

        public int ID { get => Id; set => Id = value; }
        public int Major { get => major; set => major = value; }
        public int Minor { get => minor; set => minor = value; }
        public int Fix { get => fix; set => fix = value; }
        public int Patch { get => patch; set => patch = value; }
        public string ReleaseVersion { get => releaseCycle; set => releaseCycle = value; }
        public DateTime DateTimeApplied { get => dateTimeApplied; set => dateTimeApplied = value; }
        public string Remarks { get => remarks; set => remarks = value; }
        public DateTime GetDateTimeApplied()
        {
            return DateTimeApplied;
        }
        public int GetFix()
        {
            return Fix;
        }
        public int GetID()
        {
            return ID;
        }
        public int GetMajor()
        {
            return Major;
        }
        public int GetMinor()
        {
            return Minor;
        }
        public int GetPatch()
        {
            return Patch;
        }
        public string GetReleaseCycle()
        {
            return ReleaseVersion;
        }
        public string GetRemarks()
        {
            return Remarks;
        }
    }
}
