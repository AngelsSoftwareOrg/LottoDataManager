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

        static FileUtils()
        {
        }

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

        public static String GetConfigFileFullPath()
        {
            String complete = Path.Combine(GetAppDataFolder(), ResourcesUtils.AppDataConfigFileName);
            if (!File.Exists(complete)) {
                using (StreamWriter w = File.AppendText(complete)) { }
            }
            return complete;
        }

        private static String GetAppDataFolder()
        {
            // The folder for the roaming current user 
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, ResourcesUtils.AppDataFolderName);

            // CreateDirectory will check if folder exists and, if not, create it.
            // If folder exists then CreateDirectory will do nothing.
            Directory.CreateDirectory(specificFolder);

            return specificFolder;
        }

        public static void SaveConfigurationFile(Dictionary<String, String> configKeyPairValue)
        {
            String filePath = Path.Combine(GetAppDataFolder(), ResourcesUtils.AppDataConfigFileName);

            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<String, String> kvp in configKeyPairValue)
                {
                    file.Write(String.Format("{0}={1}",kvp.Key, kvp.Value));
                    file.WriteLine();
                }
            }
        }

        public static Dictionary<String, String> GetFilePropertiesContent(String filePath)
        {
            Dictionary<String, String> tempDictionary = new Dictionary<string, string>();
            String fileObject = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(File.ReadAllText(filePath)));
            foreach (String lineStr in fileObject.Split(Char.Parse("\n")).ToList<string>())
            {
                if (!String.IsNullOrWhiteSpace(lineStr))
                {
                    String[] splitted = lineStr.Split("=".ToCharArray());
                    if (splitted == null) continue;
                    if (splitted.Length <= 1) continue;
                    tempDictionary.Add(splitted[0], splitted[1]);
                }
            }
            return tempDictionary;
        }
    }
}
