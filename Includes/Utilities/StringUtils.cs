using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Utilities
{
    public class StringUtils
    {
        public static String[] COMMON_DELIMITERS = new string[] {" ","-","\t",",","/"};
        private static readonly List<char> INVALID_FILE_PATH_CHARACTERS;
        static StringUtils()
        {
            INVALID_FILE_PATH_CHARACTERS = new List<char>();
            INVALID_FILE_PATH_CHARACTERS.AddRange(Path.GetInvalidFileNameChars().Where(c => !INVALID_FILE_PATH_CHARACTERS.Contains(c)));
            INVALID_FILE_PATH_CHARACTERS.AddRange(Path.GetInvalidPathChars().Where(c => !INVALID_FILE_PATH_CHARACTERS.Contains(c)));
            INVALID_FILE_PATH_CHARACTERS.AddRange("\"?".ToCharArray());
        }

        public static IEnumerable<string> GetLines(string s)
        {
            using (var reader = new StringReader(s))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        public static bool ContainsInvalidCharacters(String haystack)
        {
            return INVALID_FILE_PATH_CHARACTERS.Any(haystack.Contains);
        }
    }
}
