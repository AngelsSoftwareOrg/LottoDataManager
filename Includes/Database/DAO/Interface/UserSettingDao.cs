using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface UserSettingDao
    {
        int GetLastOpenedLottery();
        void SaveLastOpenedLottery(int game_cd);
        String GetMLDataSetDirectoryPath();
        void SaveMLDataSetDirectoryPath(String filePath);
        int InsertSetting(String configName, String value);
        void UpdateSetting(String configName, String value);
        String GetSetting(String configName);
    }
}
