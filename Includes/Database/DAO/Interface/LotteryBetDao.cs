﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface LotteryBetDao
    {
        List<LotteryBet> GetDashboardLatestBets(GameMode gameMode, DateTime sinceWhen, DateTime dateTo);
        List<LotteryBet> ExtractLotteryBetsCheckWinningNumber(GameMode gameMode);
        void UpdateTargetDrawDate(long id, DateTime newTargetDrawDate);
        void InsertLotteryBet(List<LotteryBet> lotteryBetArr);
        void RemoveLotteryBet(long id);
        bool IsBetExisting(LotteryBet lotteryBet);
        int InsertLotteryBet(LotteryBet lotteryBet);
        List<LotteryBet> GetLotteryBets(GameMode gameMode, DateTime betDrawDate);
        double GetTotalAmountBetted(GameMode gameMode, DateTime dateFrom, DateTime dateTo);
        int GetTotalYearsOfBetting(GameMode gameMode);
        DateTime GetLastTimeWon(GameMode gameMode);
        int GetTotalBetMade(GameMode gameMode);
        int[] GetTotalNumberOfClaims(GameMode gameMode);
        double[] GetTotalLuckyPickWinAndLoose(GameMode gameMode);
        double[] GetMonthlySpending(GameMode gameMode, int year);
        List<LotteryBet> GetLotteryBetsCurrentSeason(GameMode gameMode);
        List<LotteryBet> GetAllRedeemedClaims(GameMode gameMode, bool isGetClaimedStatus);
        DateTime[] GetMinMaxYearsOfBetting(GameMode gameMode);
        List<double[]> GetTabularAllBetsSpending(List<int> gameCodes);
        List<LotteryBet> GetLotterybetsQueued(GameMode gameMode);
    }
}
