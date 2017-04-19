using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Model;
using Dapper;
using DapperExtensions;

namespace SF.Data
{
    public static class TreeService
    {
        public static long Create(Tree model)
        {
            using(var conn=Database.GetConn())
            {
                long id=conn.Insert(model);
                return id;
            }
        }
    }
}
