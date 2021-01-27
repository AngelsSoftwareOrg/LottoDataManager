using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;

namespace LottoDataManager.Includes.Model.Game
{
    public class GameFactory
    {
        public static LotteryDetails GetInstance(int gameCode)
        {
            switch (gameCode)
            {
                case 1:
                    return new Game642();
                case 2:
                    return new Game645();
                case 3:
                    return new Game649();
                case 4:
                    return new Game655();
                case 5:
                    return new Game658();
                default:
                    return new Game642();
            }
        }
    
        public static LotteryDetails GetPreviousOpenGameInstance()
        {
            UserSettingDao userSettingDao = UserSettingDaoImpl.GetInstance();
            return GetInstance(userSettingDao.GetLastOpenedLottery());
        }
    }
}
