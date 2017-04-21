using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SF.Model;

namespace SF.Web
{
    public class BaseController:Controller
    {
        public User GetUser()
        {
            return new User { ID = 1, DefaultCity = "无锡" };
        }
    }
}