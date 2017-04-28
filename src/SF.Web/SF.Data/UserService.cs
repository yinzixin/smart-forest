﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Model;
using Dapper;
using DapperExtensions;

namespace SF.Data
{
    public static class UserService
    {
        static UserService()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
        }
        public static long Create(User model)
        {
            using (var conn = Database.GetConn())
            {
                long id = conn.Insert(model);
                return id;
            }
        }

        public static void Update(User model)
        {
            using (var conn = Database.GetConn())
            {
                 conn.Update(model);         
            }
        }

        public static List<User> Query()
        {
            var sql = "select * from `User` where IsDelete=0";
            using (var conn = Database.GetConn())
            {
                return conn.Query<User>(sql).ToList();
            }
        }

        public static List<User> GetParentUser()
        {
            var sql = "select * from `User` where IsDelete=0 and level=2";
            using (var conn = Database.GetConn())
            {
                return conn.Query<User>(sql).ToList();
            }
        }
    }
}