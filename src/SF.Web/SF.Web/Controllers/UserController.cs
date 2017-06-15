using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SF.Model;
using SF.Data;

namespace SF.Web.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
         [UserProfileFilter]
        public ActionResult Index(string IDName,int? jump,int Current=1)
        {
            ViewBag.IDName = IDName;
            ViewBag.jump = jump;

            var result = UserService.Query();

            if (!string.IsNullOrEmpty(IDName))
            {
                result = result.Where(r => r.RealName.Contains(IDName) || r.UserName.Contains(IDName) || r.ID.ToString().Contains(IDName) || r.CompanyName.Contains(IDName)).ToList();
            }
            int pageSize = 10;
            int count = result.Count() % pageSize == 0 ? result.Count() / pageSize : result.Count() / pageSize + 1;
            int pageStart = Current - pageSize < 1 ? 1 : Current - pageSize;
            int pageEnd = Current + 2 > count ? count : Current + 2;

            List<int> pages = new List<int>();
            for (int i = pageStart; i <= pageEnd; i++)
            {
                pages.Add(i);
            }
            ViewBag.page = pages;
            result = result.Skip(Current * pageSize - pageSize).Take(pageSize).ToList();
            return View(result);
        }

         [UserProfileFilter]
        [HttpGet]
        public ActionResult Create()
        {
            var opt = UserService.GetParentUser().Select(u => new SelectListItem { Text = u.DefaultArea, Value = u.ID.ToString() });
            ViewBag.ParentUserList = opt;
            return View();
        }
         [UserProfileFilter]
        [HttpPost]
        public ActionResult Create(User model)
        {
            var opt = UserService.GetParentUser().Select(u => new SelectListItem { Text = u.DefaultArea, Value = u.ID.ToString() });
            ViewBag.ParentUserList = opt;

            if (ModelState.IsValid)
            {
                UserService.Create(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

         [UserProfileFilter]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var opt = UserService.GetParentUser().Select(u => new SelectListItem { Text = u.DefaultArea, Value = u.ID.ToString() });
            ViewBag.ParentUserList = opt;

            var model = UserService.Query().Where(u => u.ID == id).SingleOrDefault();
            return View(model);
        }

         [UserProfileFilter]
        [HttpPost]
        public ActionResult Edit(User model)
        {
            var opt = UserService.GetParentUser().Select(u => new SelectListItem { Text = u.DefaultArea, Value = u.ID.ToString() });
            ViewBag.ParentUserList = opt;

            if (ModelState.IsValid)
            {
                UserService.Update(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

         public string Del(int id)
         {
             UserService.Del(id);
             return "ok";
         }

         public string Pause(int id)
         {
             var user= UserService.Query().Where(u=>u.ID==id).SingleOrDefault();
             user.IsPause = !user.IsPause;
             UserService.Update(user);
             return "ok";
         }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user=UserService.Login(model.User,model.Password);

            var log = new LoginLog
            {
                CreateTime = DateTime.Now,
                IDUser = user == null ? -1 : user.ID,
                LoginName = model.User,
                IsPass = (user != null),
                IP=GetIP()
            };


            UserService.Log(log);
            
            if(user!=null)
            {
                this.SetCurrentUser(user);
                return RedirectToAction("Index", "tree");
            }
            else
            {
                ModelState.AddModelError("msg", "用户名或密码不正确.");
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            Session["current_user"] = null;
            return RedirectToAction("Login", "User");
        }

        public ActionResult Log()
        {
            var m = UserService.GetLog();
            return View(m);
        }


        public   string GetIP()
        {
            //如果客户端使用了代理服务器，则利用HTTP_X_FORWARDED_FOR找到客户端IP地址
            string userHostAddress = "";// this.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            //否则直接读取REMOTE_ADDR获取客户端IP地址
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = this.Request.ServerVariables["REMOTE_ADDR"];
            }
            //前两者均失败，则利用Request.UserHostAddress属性获取IP地址，但此时无法确定该IP是客户端IP还是代理IP
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = this.Request.UserHostAddress;
            }
            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }

    public class LoginModel
    {
        public string User { get; set; }

        public string Password { get; set; }
    }
}