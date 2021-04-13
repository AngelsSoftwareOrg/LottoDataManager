using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.ML
{
    public abstract class MLModelAbstract
    {

        protected static bool IsModelExists(String modelName, String folderPath=null)
        {
            if (!String.IsNullOrEmpty(folderPath))
            {
                if (File.Exists(Path.Combine(folderPath, modelName)))
                {
                    return true;
                }
            }

            if(File.Exists(Path.Combine(AppSettings.GetMLModelSourcePath(), modelName))){
                return true;
            }
            return false;
        }

        protected static String GetCompleteModelPath(String modelName)
        {
            if (IsModelExists(modelName))
            {
                return Path.Combine(AppSettings.GetMLModelSourcePath(), modelName);
            }
            throw new Exception(String.Format(ResourcesUtils.GetMessage("mac_lrn_bldr_log_6"), modelName, AppSettings.GetMLModelSourcePath()));
        }
    }
}
