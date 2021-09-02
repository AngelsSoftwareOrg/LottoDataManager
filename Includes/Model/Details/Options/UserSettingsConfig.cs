using LottoDataManager.Includes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Details.Options
{
    public class UserSettingsConfig
    {
        private static int DEFAULT_DATE_YEAR = 2000;
        private static int DEFAULT_DATE_MONTH = 1;
        private static int DEFAULT_DATE_DAY = 1;
        private static int DEFAULT_DATE_HOUR = 20;
        private static int DEFAULT_DATE_MIN = 0;
        private static int DEFAULT_DATE_SEC = 0;
        public static readonly String CFG_ML_DATA_SET = "ml_data_set";
        public static readonly String CFG_LAST_OPENED_DIRECTORY = "last_opened_lottery";
        public static readonly String CFG_TICKET_SELLING_CUTOFF_TIME = "ticketing_selling_cutoff_time";
        public static readonly String CFG_TICKETING_CUTOFF_NOTIFY = "ticketing_cutoff_notify";
        public static readonly int CFG_TICKETING_CUTOFF_NOTIFY_DEFAULT = 30;
        public static readonly DateTime CFG_TICKET_SELLING_CUTOFF_TIME_DEFAULT = 
                                new DateTime(DEFAULT_DATE_YEAR, DEFAULT_DATE_MONTH, DEFAULT_DATE_DAY, 
                                    DEFAULT_DATE_HOUR, DEFAULT_DATE_MIN, DEFAULT_DATE_SEC);

        public static String ConvertCutoffTimeToConfigValue(DateTime cutOffTime)
        {
            return cutOffTime.ToString(DateTimeConverterUtils.STANDARD_DATE_TIME_FORMAT);
        }
        public static String CutoffTimeDefaultValue
        {
            get
            {
                return CFG_TICKET_SELLING_CUTOFF_TIME_DEFAULT.ToString(DateTimeConverterUtils.STANDARD_DATE_TIME_FORMAT);
            }
        }
        public static DateTime ConvertCutoffTimeToDateTime(String cutOffTimeString)
        {
            return DateTimeConverterUtils.GetDateTimeInstance(cutOffTimeString,
                DateTimeConverterUtils.STANDARD_DATE_TIME_FORMAT);
        }
    }
}
