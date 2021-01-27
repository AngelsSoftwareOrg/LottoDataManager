using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Utilities
{
    public class DateTimeConverterUtils
    {
        public static readonly String DATE_FORMAT_LONG = "MMMM dd, yyyy - dddd";
        public static readonly String STANDARD_DATE_FORMAT = "yyyy-MM-dd";
        public static String ConvertToFormat(DateTime dateSource, String outputFormat)
        {
            return dateSource.ToString(outputFormat);
        }
        /// <summary>
        /// PCSO lowest date
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime GetYear2011()
        {
            DateTime y2k = new DateTime(2011,1,1,0,0,0,DateTimeKind.Local);
            return y2k;
        }

    }
}
