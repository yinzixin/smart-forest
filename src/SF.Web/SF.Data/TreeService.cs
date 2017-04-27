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
                model.Longtitude = convertDegree(model.LonText);
                model.Latitude = convertDegree(model.LatText);

                long id=conn.Insert(model);                
                return id;
            }
        }

        static decimal convertDegree(string s)
        {
            decimal deg=0m;
            try
            {
                deg = decimal.Parse(s);
            }
            catch (Exception)
            {

            }
            return deg;
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
