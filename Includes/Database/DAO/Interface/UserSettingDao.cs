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
    }
}
