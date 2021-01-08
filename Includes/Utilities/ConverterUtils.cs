using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Utilities
{
    public class ConverterUtils
    {
        private static readonly string[] SIZE_SUFFIXES =
               { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string HumanReadableFileSize(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SIZE_SUFFIXES[-value]; }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SIZE_SUFFIXES[mag]);
        }

        public static string ConvertToHourMinuteSeconds(long secs)
        {// 0.63 ms
            long hours = secs / 3600;
            long mins = (secs % 3600) / 60;
            secs = secs % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, secs);
        }

        public static string ConvertToHourMinuteSecondsUsingModulo(long secs)
        {// 0.64 ms
            long s = secs % 60;
            secs /= 60;
            long mins = secs % 60;
            long hours = secs / 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, s);
        }

        public static string ConvertToHourMinuteSecondsUsingTimeSpan(long secs)
        {// 0.70 ms
            TimeSpan t = TimeSpan.FromSeconds(secs);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                (int)t.TotalHours,
                t.Minutes,
                t.Seconds);
        }

        public static int GetPercentageFloored(long progress = 0, long total = 0)
        {
            if (total <= 0) return 0;
            decimal result = ((decimal)progress / (decimal)total) * 100;
            result = Math.Floor(result);
            return int.Parse(result.ToString());
        }

    }
}
