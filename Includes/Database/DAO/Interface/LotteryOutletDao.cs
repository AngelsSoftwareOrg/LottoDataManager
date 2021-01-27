using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Model.Details;

namespace LottoDataManager.Includes.Database.DAO.Interface
{
    public interface LotteryOutletDao
    {
        List<LotteryOutlet> GetLotteryOutlets();
    }
}
