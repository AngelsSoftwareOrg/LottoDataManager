using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Utilities
{
    public class FileUtils
    {
        public static String TEMP_FILE_MARKED = "Lotto_Data_manager_1234567890_";
        public static string GetTempFilePathWithExtension(string extension)
        {
            var path = Path.GetTempPath();
            var fileName = TEMP_FILE_MARKED + Guid.NewGuid().ToString() + extension;
            return Path.Combine(path, fileName);
        }

        public static string GetCSVTempFilePathName()
        {
            return GetTempFilePathWithExtension(".csv");
        }
    }
}
