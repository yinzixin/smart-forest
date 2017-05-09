using SF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SF.Web
{
    public class UserProfileFilter: FilterAttribute, IActionFilter 
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var user=(User)filterContext.HttpContext.Session["current_user"];
            if(user!=null)
            {
                filterContext.Controller.ViewBag.User = user;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
             
        }
    }
}