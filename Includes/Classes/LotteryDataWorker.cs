using System;
using System.Collections.Generic;
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
        private static LotteryDataWorker lotteryDataWorker;
        private LotteryDataWorker() { }
        public static LotteryDataWorker GetInstance()
        {
            if (lotteryDataWorker == null)
            {
                lotteryDataWorker = new LotteryDataWorker();
            }
            return lotteryDataWorker;
        }

        public void ProcessCheckingForWinningBets(GameMode gameMode)
        {
            LotteryBetDao lotteryBetDao = LotteryBetDaoImpl.GetInstance();
            List<LotteryBet> lotteryBetArr = lotteryBetDao.ExtractLotteryBetsCheckWinningNumber(gameMode);
            foreach (LotteryBet lotteryBet in lotteryBetArr)
            {
                ProcessWinningBet(lotteryBet);
            }
        }

        public void ProcessWinningBet(LotteryBet lotteryBet)
        {
            GameMode gameMode = ClassReflectionUtil.FindGameMode(lotteryBet.GetGameCode());
            LotteryWinningCombinationDao lotteryWinningCombinationDao = LotteryWinningCombinationDaoImpl.GetInstance();
            LotteryWinningCombination lotteryWinningCombination = lotteryWinningCombinationDao.GetLotteryWinningCombination(gameMode);

            LotteryWinningBetDao lotteryWinningBetDao = LotteryWinningBetDaoImpl.GetInstance();
            LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            LotteryDrawResult betDrawResult = lotteryDrawResultDao.GetLotteryDrawResultByDrawDate(
                            gameMode, lotteryBet.GetTargetDrawDate());
            LotteryWinningBetSetup lotteryWinningBet = new LotteryWinningBetSetup();
            lotteryWinningBet.LotteryBetId = lotteryBet.GetId();

            if (betDrawResult == null) return;
            if (betDrawResult.IsDrawResulDetailsEmpty()) return;

            int matchingNumberCtr = 0;
            foreach (int bet in lotteryBet.GetBetNumbersAsArray())
            {
                if (betDrawResult.IsWithinDrawResult(bet))
                {
                    matchingNumberCtr++;
                    lotteryWinningBet.FillNumberBySeq(matchingNumberCtr, bet);
                }
            }

            if (lotteryWinningBet.IsNumberSequenceMatchesAll(betDrawResult.GetAllNumberSequence()))
            {
                lotteryWinningBet.WinningAmount = betDrawResult.GetJackpotAmt();
            }
            else
            {
                lotteryWinningBet.WinningAmount = lotteryWinningCombination.GetWinningAmount(matchingNumberCtr);
            }

            lotteryWinningBetDao.InsertWinningBet(lotteryWinningBet);
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
