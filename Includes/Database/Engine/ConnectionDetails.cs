using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Database
{
    public class ConnectionDetails
    {
        private String connectionString;
        private String username;
        private String password;

        public ConnectionDetails(string connectionString, string username=null, string password=null)
        {
            this.connectionString = connectionString;
            this.username = username;
            this.password = password;
        }

        public string ConnectionString { get => connectionString; }
        public string Username { get => username;  }
        public string Password { get => password; }
    }
}
