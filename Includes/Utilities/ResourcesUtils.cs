using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Utilities
{
    public class ResourcesUtils : IDisposable
    {
        private static ResourceManager RESOURCE_MANAGER;
        private static readonly String RESOURCE_NAME = "LottoDataManager.Properties.Resources";
        private static readonly String RESOURCE_PROPERTY_FILE_NAME_MESSAGES_EN = "messages_en";
        private static Dictionary<String, String> MESSAGES_DICTIONARY = new Dictionary<string, string>();

        private static readonly String RESOURCE_ID_APPLICATION_ID = "APPLICATION_ID";
        private static readonly String RESOURCE_ID_DB_SOURCE_FILE_TYPE_EXTENSION = "DB_SOURCE_FILE_TYPE_EXTENSION";
        private static readonly String RESOURCE_ID_DB_SOURCE_FILE_TYPE_EXTENSION_DESC = "DB_SOURCE_FILE_TYPE_EXTENSION_DESC";
        private static readonly String RESOURCE_ID_ML_MODEL_FILE_TYPE_EXTENSION = "ML_MODEL_FILE_TYPE_EXTENSION";
        private static readonly String RESOURCE_ID_ML_MODEL_FILE_TYPE_EXTENSION_DESC = "ML_MODEL_FILE_TYPE_EXTENSION_DESC";
        private static readonly String RESOURCE_ID_APP_DATA_FOLDER = "APP_DATA_FOLDER";
        private static readonly String RESOURCE_ID_APP_DATA_FOLDER_CONFIG_FILE_NAME = "APP_DATA_FOLDER_CONFIG_FILE_NAME";

        static ResourcesUtils()
        {
            RESOURCE_MANAGER = new ResourceManager(RESOURCE_NAME, typeof(ResourcesUtils).Assembly);
            GetResourceMessages();
        }
        private static string GetSetting(String settingName)
        {
            return RESOURCE_MANAGER.GetString(settingName);
        }
        public static string GetMessage(String messageName)
        {
            String value;
            MESSAGES_DICTIONARY.TryGetValue(messageName, out value);
            return value.TrimEnd('\r', '\n');
        }
        public static String ApplicationID { get { return GetSetting(RESOURCE_ID_APPLICATION_ID); } }
        public static String SourceDBFileExtension { get { return GetSetting(RESOURCE_ID_DB_SOURCE_FILE_TYPE_EXTENSION); } }
        public static String SourceDBFileDialogFilter { get { return SourceDBFileExtensionDescription + "|*" + SourceDBFileExtension; } }
        public static String SourceDBFileExtensionDescription { get { return GetSetting(RESOURCE_ID_DB_SOURCE_FILE_TYPE_EXTENSION_DESC); } }
        public static String MachineLearningModelFileExtension { get { return GetSetting(RESOURCE_ID_ML_MODEL_FILE_TYPE_EXTENSION); } }
        public static String MachineLearningModelFileExtensionDescription { get { return GetSetting(RESOURCE_ID_ML_MODEL_FILE_TYPE_EXTENSION_DESC); } }
        public static String AppDataFolderName { get { return GetSetting(RESOURCE_ID_APP_DATA_FOLDER); } }
        public static String AppDataConfigFileName { get { return GetSetting(RESOURCE_ID_APP_DATA_FOLDER_CONFIG_FILE_NAME); } }
        public void Dispose()
        {
            RESOURCE_MANAGER = null;
            MESSAGES_DICTIONARY = null;
        }
        private static void GetResourceMessages()
        {
            String fileObject = Encoding.UTF8.GetString((Byte[])RESOURCE_MANAGER.GetObject(RESOURCE_PROPERTY_FILE_NAME_MESSAGES_EN));
            foreach(String lineStr in fileObject.Split(Char.Parse("\n")).ToList<string>())
            {
                String lineStrTmp = lineStr.Trim();
                if (lineStrTmp.StartsWith("#")) continue;
                if (!String.IsNullOrWhiteSpace(lineStr))
                {
                    String[] splitted = lineStr.Split("=".ToCharArray());
                    if (splitted == null) continue;
                    if (splitted.Length <= 1) continue;
                    String key = splitted[0];
                    String value = splitted[1];

                    if (MESSAGES_DICTIONARY.ContainsKey(key))
                    {
                        throw new Exception(String.Format("The key [{0}] already exist. Please avoid duplicate entries on your messages_x.properties",key));
                    }
                    MESSAGES_DICTIONARY.Add(key, value);
                }
            }
        }
    }
}
