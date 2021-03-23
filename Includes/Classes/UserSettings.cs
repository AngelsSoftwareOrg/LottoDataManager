using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;

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
    }
}
