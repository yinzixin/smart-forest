using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF.Data;
using SF.Model;
//using DapperExtensions.Sql
namespace SF.Test
{
    [TestClass]
    public class UnitTest1
    {
        //string conn = "Server=172.200.2.3;Database=forest;User=root;Password=123;Charset=utf8;";
        [TestMethod]
        public void TestTreeCreate()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
            Tree tree = new Tree
            {
                Address = "xxx街道",
                AddressType = "城市",
                YearOfBirth = 1900,
                Name = "银杏",
                Checker = "yzx",
                RootSize = 10,
                BodyBug = "abc",
                County = "jiangsu",
                Creator = "lyy",
                CheckTime = DateTime.Now,
                ChestSize = 20,
                UserID = 1,
                Town = "xinan",
                Latitude = 30.1022436475m,
                Longtitude = 118.0022436475m,
                Photo = "test",
                Height = 10m,
                City = "wuxi",
                Story = "afasdfsa",
                Number = "c1001",
                NameLatin = "latin",
                IsFamous = true,Dutier="abc",Health="ok", CrownDeviated=true
            };

            Tree tree2 = new Tree
            {
                Address = "xxx街道",
                AddressType = "城市",
                YearOfBirth = 1900,
                Name = "银杏2",
                Checker = "yzx",
                RootSize = 10,
                BodyBug = "abc",
                County = "jiangsu",
                Creator = "lyy",
                CheckTime = DateTime.Now,
                ChestSize = 20,
                UserID = 1,
                Town = "xinan",
                Latitude = 30.9622436475m,
                Longtitude = 118.7022436475m,
                Photo = "test",
                Height = 10m,
                City = "wuxi",
                Story = "afasdfsa",
                Number = "c1001",
                NameLatin = "latin",
                IsFamous = true,
                Dutier = "abc",
                Health = "ok",
                CrownDeviated = true
            };

            var id = TreeService.Create(tree);
            TreeService.Create(tree2);
            Assert.IsTrue(id > 0);

        }
    }
}
