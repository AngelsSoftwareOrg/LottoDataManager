using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public abstract class LotteryDaoImplCommon
    {
        protected readonly string QUERY_LAST_INSERT_ID = "Select @@Identity";


        protected int GetLastInsertedID(OleDbCommand command)
        {
            command.CommandText = QUERY_LAST_INSERT_ID;
            int modified = (int)command.ExecuteScalar();
            return modified;
        }

    }
}
