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
        public ActionResult Index()
        {
            var list = UserService.Query();
            return View(list);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user=UserService.Login(model.User,model.Password);
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
    }

    public class LoginModel
    {
        public string User { get; set; }

        public string Password { get; set; }
    }
}