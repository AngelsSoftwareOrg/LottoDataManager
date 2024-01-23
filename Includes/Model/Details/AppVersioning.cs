using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details
{
    public interface AppVersioning
    {
        int GetID();
        int GetMajor();
        int GetMinor();
        int GetFix();
        int GetPatch();
        string GetReleaseCycle();
        string GetRemarks();
        DateTime GetDateTimeApplied();
        string GetAppVersionLbl();
    }
}
