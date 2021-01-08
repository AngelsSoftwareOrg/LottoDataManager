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
                lotteryWinningBet.LotteryBetId = betDrawResult.GetID();

                if (betDrawResult.isDrawResulDetailsEmpty()) continue;

                //debug
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(lotteryBet.ToString());
                Console.WriteLine(betDrawResult.ToString());

                int matchingNumberCtr = 0;
                foreach(int bet in lotteryBet.GetBetNumbersAsArray())
                {
                    if (betDrawResult.isWithinDrawResult(bet))
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

                //debug
                Console.WriteLine("Matching Number: " + matchingNumberCtr);
                Console.WriteLine(lotteryWinningBet.ToString());

                lotteryWinningBetDao.InsertWinningBet(lotteryWinningBet);
            }
        }

        public void ProcessAdjustCorrectTargetDrawDate(GameMode gameMode)
        {
            LotteryWinningCombinationDao lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
            LotteryBetDao lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            List<LotteryBet> lotteryBetArr = lotteryBetDao.GetDashboardLatestBets(gameMode, DateTime.Now.AddDays(-9999));

            int count = 0; //debug
            foreach(LotteryBet lotteryBet in lotteryBetArr)
            {
/*                if (count <= 10)
                {
                    count++; //debug
                    continue;
                }*/
                DateTime dt = lotteryDrawResultDao.GetNextDrawDate(gameMode, lotteryBet.GetTargetDrawDate());

                if(!((DateTime.Now.Year - dt.Year) >= 12)){
                    lotteryBetDao.UpdateTargetDrawDate(lotteryBet.GetId(), dt);
                }

            }

            //GetNextDrawDate
        }
    }
}
