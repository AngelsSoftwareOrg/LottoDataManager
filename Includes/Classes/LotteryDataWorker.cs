using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes
{
    public class LotteryDataWorker
    {
        public void ProcessCheckingForWinningBets(GameMode gameMode)
        {
            LotteryWinningCombinationDao lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
            LotteryBetDao lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            LotteryWinningBetDao lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            LotteryWinningCombination lotteryWinningCombination = lotteryWinningCombinationDao.GetLotteryWinningCombination(gameMode);
            List<LotteryBet> lotteryBetArr = lotteryBetDao.ExtractLotteryBetsCheckWinningNumber(gameMode);

            foreach (LotteryBet lotteryBet in lotteryBetArr)
            {
                LotteryDrawResult betDrawResult = lotteryDrawResultDao.GetLotteryDrawResultByDrawDate(
                                            ClassReflectionUtil.FindGameMode(lotteryBet.GetGameCode()), 
                                            lotteryBet.GetTargetDrawDate());
                LotteryWinningBetSetup lotteryWinningBet = new LotteryWinningBetSetup();
                lotteryWinningBet.LotteryBetId = lotteryBet.GetId(); //betDrawResult.GetID();

                if (betDrawResult.IsDrawResulDetailsEmpty()) continue;

                int matchingNumberCtr = 0;
                foreach(int bet in lotteryBet.GetBetNumbersAsArray())
                {
                    if (betDrawResult.IsWithinDrawResult(bet))
                    {
                        matchingNumberCtr++;
                        lotteryWinningBet.FillNumberBySeq(matchingNumberCtr, bet);
                    }
                }
                
                if (lotteryWinningBet.IsNumberSequenceMatchesAll(betDrawResult.GetAllNumberSequence())){
                    lotteryWinningBet.WinningAmount = betDrawResult.GetJackpotAmt();
                }
                else
                {
                    lotteryWinningBet.WinningAmount = lotteryWinningCombination.GetWinningAmount(matchingNumberCtr);
                }

                lotteryWinningBetDao.InsertWinningBet(lotteryWinningBet);
            }
        }

        public void ProcessAdjustCorrectTargetDrawDate(GameMode gameMode)
        {
            LotteryWinningCombinationDao lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
            LotteryBetDao lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            List<LotteryBet> lotteryBetArr = lotteryBetDao.GetDashboardLatestBets(gameMode, DateTime.Now.AddDays(-9999));

            foreach(LotteryBet lotteryBet in lotteryBetArr)
            {
                DateTime dt = lotteryDrawResultDao.GetNextDrawDate(gameMode, lotteryBet.GetTargetDrawDate());

                if(!((DateTime.Now.Year - dt.Year) >= 12)){
                    lotteryBetDao.UpdateTargetDrawDate(lotteryBet.GetId(), dt);
                }
            }
        }
    }
}
