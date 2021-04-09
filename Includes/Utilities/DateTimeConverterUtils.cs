using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itenso.TimePeriod;

namespace LottoDataManager.Includes.Utilities
{
    public class DateTimeConverterUtils
    {
        public static readonly String DATE_FORMAT_LONG = "MMMM dd, yyyy - dddd";
        public static readonly String STANDARD_DATE_FORMAT = "yyyy-MM-dd";
        public static readonly String STANDARD_DATE_FORMAT_DFLT_TIME = "yyyy-MM-dd 00:00:00.0";
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
        public static String DateDifferencePeriod(DateTime earliestDate, DateTime latestDate)
        {
            DateDiff dateDiff = new DateDiff(earliestDate, latestDate);
            return string.Format("{0} year{1}, {2} month{3}, {4} day{5}",
                                    dateDiff.ElapsedYears,
                                    (dateDiff.ElapsedYears > 1) ? "s":"",
                                    dateDiff.ElapsedMonths,
                                    (dateDiff.ElapsedMonths > 1) ? "s" : "",
                                    dateDiff.ElapsedDays,
                                    (dateDiff.ElapsedDays > 1) ? "s" : "");
        }
    }
}
