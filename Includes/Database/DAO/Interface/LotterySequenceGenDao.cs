﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface LotterySequenceGenDao
    {
        List<LotterySequenceGenerator> GetAllSeqGenerators();
        LotterySequenceGenerator GetSeqGenerator(int seqGenId);
        LotterySequenceGenerator GetSeqGeneratorByCode(int seqGenCode);
        void UpdateDescription(LotterySequenceGenerator updatedModel);
        bool IsDescriptionExisting(String seqGenDescription);
       int InsertSequenceGenerator(LotterySequenceGenerator seqGen);
    }
}
