using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Model;
using Dapper;
using DapperExtensions;
using SF.Model;

namespace SF.Data
{
    public static class TreeService
    {
        static TreeService()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
        }
        public static long Create(Tree model)
        {
            using(var conn=Database.GetConn())
            {
                long id=conn.Insert(model);                
                return id;
            }
        }

        public static Tree Get(long id)
        {
            using(var conn=Database.GetConn())
            {
               var res=conn.Get<Tree>(id);
               return res;
            }
        }

        public static IEnumerable<Tree> Query(int userID)
        {
            using(var conn=Database.GetConn())
            {
                var res = conn.GetList<Tree>();
                return res;
            }
        }
    }
}
