using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details.Options;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes
{
    public class UserSettings
    {
        
        private UserSettingDao userSettingDao;
        public UserSettings()
        {
            this.userSettingDao = UserSettingDaoImpl.GetInstance();
        }
        public void SaveLastOpenedLottery(int gameCode)
        {
            this.userSettingDao.SaveLastOpenedLottery(gameCode);
        }
        public int GetLastOpenedLottery()
        {
            return this.userSettingDao.GetLastOpenedLottery();
        }
        public String GetMLDataSetDirectoryPath()
        {
            return this.userSettingDao.GetMLDataSetDirectoryPath();
        }
        public void SaveMLDataSetDirectoryPath(String filePath)
        {
            this.userSettingDao.SaveMLDataSetDirectoryPath(filePath);
        }
        public void SaveTicketCutoffTime(DateTime newCutoffTime)
        {
            String oldCutOffTime = this.userSettingDao.GetSetting(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME);
            ValidateConfigDetails(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME,
                    UserSettingsConfig.ConvertCutoffTimeToConfigValue(newCutoffTime));
            if (String.IsNullOrWhiteSpace(oldCutOffTime))
            {
                this.userSettingDao.InsertSetting(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME,
                    UserSettingsConfig.ConvertCutoffTimeToConfigValue(newCutoffTime));
            }
            else
            {
                this.userSettingDao.UpdateSetting(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME,
                    UserSettingsConfig.ConvertCutoffTimeToConfigValue(newCutoffTime));
            }
        }
        public void SaveTicketCutoffNotifyTime(int newValue)
        {
            String currentCutOffNotifyTime = this.userSettingDao.GetSetting(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY);
            if (String.IsNullOrWhiteSpace(currentCutOffNotifyTime))
            {
                ValidateConfigDetails(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY,
                    UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY_DEFAULT.ToString());
                this.userSettingDao.InsertSetting(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY,
                    UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY_DEFAULT.ToString());
            }
            else
            {
                this.userSettingDao.UpdateSetting(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY, newValue.ToString());
            }
        }
        public DateTime GetTicketCutoffTime()
        {
            String currentCutOffTime = this.userSettingDao.GetSetting(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME);
            if (String.IsNullOrWhiteSpace(currentCutOffTime))
            {
                ValidateConfigDetails(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME,
                    UserSettingsConfig.CutoffTimeDefaultValue);
                this.userSettingDao.InsertSetting(UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME,
                    UserSettingsConfig.CutoffTimeDefaultValue);
                return UserSettingsConfig.CFG_TICKET_SELLING_CUTOFF_TIME_DEFAULT;
            }

            return UserSettingsConfig.ConvertCutoffTimeToDateTime(currentCutOffTime);
        }
        public DateTime GetTicketCutoffTimeUsingCurrentDate()
        {
            return DateTime.ParseExact(DateTime.Now.ToString(DateTimeConverterUtils.STANDARD_DATE_FORMAT) + " " +
                                    GetTicketCutoffTime().ToString(DateTimeConverterUtils.STANDARD_TIME_FORMAT),
                DateTimeConverterUtils.STANDARD_DATE_TIME_FORMAT,
                new CultureInfo(DateTimeConverterUtils.DEFAULT_GLOBALIZATION));
        }
        public int GetTicketCutoffNotifyTime()
        {
            String currentCutOffNotifyTime = this.userSettingDao.GetSetting(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY);
            if (String.IsNullOrWhiteSpace(currentCutOffNotifyTime))
            {
                ValidateConfigDetails(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY,
                    UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY_DEFAULT.ToString());
                this.userSettingDao.InsertSetting(UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY,
                    UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY_DEFAULT.ToString());
                return UserSettingsConfig.CFG_TICKETING_CUTOFF_NOTIFY_DEFAULT;
            }

            return int.Parse(currentCutOffNotifyTime);
        }
        public bool IsPastTicketSellingCutoffTime(DateTime cutOffTime)
        {
            long timenow = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            long cutoffTime = long.Parse(DateTime.Now.ToString("yyyyMMdd") + cutOffTime.ToString(DateTimeConverterUtils.DT_TICKET_CUTOFF_TIME_FORMAT_TIME_ONLY));
            return (timenow >= cutoffTime);
        }
        private void ValidateConfigDetails(String configName, String configValue)
        {
            int maxLen = 255;

            if (String.IsNullOrWhiteSpace(configName)) throw new Exception(ResourcesUtils.GetMessage("user_sett_dao_impl_msg3"));
            if (String.IsNullOrWhiteSpace(configValue)) throw new Exception(ResourcesUtils.GetMessage("user_sett_dao_impl_msg4"));

            if(configName.Length > maxLen) throw new Exception(String.Format(ResourcesUtils.GetMessage("user_sett_dao_impl_msg5"), maxLen));
            if (configValue.Length > maxLen) throw new Exception(String.Format(ResourcesUtils.GetMessage("user_sett_dao_impl_msg6"), maxLen));
        }
    }
}
