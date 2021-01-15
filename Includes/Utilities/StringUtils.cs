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

    }
}
