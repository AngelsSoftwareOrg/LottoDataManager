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
            String value = null;
            MESSAGES_DICTIONARY.TryGetValue(messageName, out value);
            return value;
        }

        public void Dispose()
        {
            RESOURCE_MANAGER = null;
        }

        private static void GetResourceMessages()
        {
            String fileObject = Encoding.UTF8.GetString((Byte[])RESOURCE_MANAGER.GetObject(RESOURCE_PROPERTY_FILE_NAME_MESSAGES_EN));
            foreach(String lineStr in fileObject.Split(Char.Parse("\n")).ToList<string>())
            {
                if (!String.IsNullOrWhiteSpace(lineStr))
                {
                    String[] splitted = lineStr.Split("=".ToCharArray());
                    if (splitted == null) continue;
                    if (splitted.Length <= 1) continue;
                    MESSAGES_DICTIONARY.Add(splitted[0], splitted[1]);
                }
            }
        }
    }
}
