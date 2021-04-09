using System;
using System.Collections.Generic;
using System.Data;
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
        protected bool ColumnExists(IDataReader reader, string columnName)
        {
            return reader.GetSchemaTable()
                         .Rows
                         .OfType<DataRow>()
                         .Any(row => (String)row["ColumnName"] == columnName);
        }
        protected String GetMultipleGameCodeSQLPredicate(List<int> gameCodes)
        {
            return String.Format("game_cd IN ({0}) ", string.Join<int>(",", gameCodes));
        }
    }
}
