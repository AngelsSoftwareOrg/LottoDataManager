using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Database.DAO.Interface;

namespace LottoDataManager.Includes.Database.DAO.Impl
{
    public class TestingDatabaseSourceFileDaoImpl: TestingDatabaseSourceFileDao
    {
        private static TestingDatabaseSourceFileDaoImpl testingDatabaseSourceFileDaoImpl;
        private TestingDatabaseSourceFileDaoImpl() { }
        public static TestingDatabaseSourceFileDao GetInstance()
        {
            if (testingDatabaseSourceFileDaoImpl == null)
            {
                testingDatabaseSourceFileDaoImpl = new TestingDatabaseSourceFileDaoImpl();
            }
            return testingDatabaseSourceFileDaoImpl;
        }

        public bool TestConnection(String msAccessDBSourcePath)
        {
            try
            {
                using (OleDbConnection conn = DatabaseConnectionFactory.GetMSAccessConnectionDetails(msAccessDBSourcePath))
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = " SELECT TOP 1 * FROM `app_versioning` ORDER BY `datetimeapplied` DESC ";
                    command.Connection = conn;
                    conn.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int result = 0;
                            bool x = int.TryParse(reader["ID"].ToString(), out result);
                            return result > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
