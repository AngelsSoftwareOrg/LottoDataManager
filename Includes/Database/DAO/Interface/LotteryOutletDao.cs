using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface LotteryOutletDao
    {
        List<LotteryOutlet> GetLotteryOutlets();
        void UpdateDescription(LotteryOutlet updatedModel);
        bool IsLotteryOutletUsed(int outletCd);
        void RemoveOutlet(LotteryOutlet modelToRemove);
        bool IsDescriptionExisting(String outletDescription);
        int InsertLotteryOutlet(String outletDescription);
        int GetNextOutletCode();
        LotteryOutlet GetDefaultLotteryOutlet();
    }
}
