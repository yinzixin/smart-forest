using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Data
{
    public class Database
    {
        public static DbConnection GetConn()
        {
            var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
