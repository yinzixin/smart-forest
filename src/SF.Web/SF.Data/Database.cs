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
            var str = "Server=172.200.2.3;Database=forest;User=root;Password=123;Charset=utf8;";
            //var str = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            var conn = new MySqlConnection(str);
            conn.Open();
            return conn;
        }
 
    }
}
