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
        public ActionResult Index()
        {
            var list = UserService.Query();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var opt = UserService.GetParentUser().Select(u => new SelectListItem { Text = u.DefaultArea, Value = u.ID.ToString() });
            ViewBag.ParentUserList = opt;
            return View();
        }

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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var opt = UserService.GetParentUser().Select(u => new SelectListItem { Text = u.DefaultArea, Value = u.ID.ToString() });
            ViewBag.ParentUserList = opt;

            var model = UserService.Query().Where(u => u.ID == id).SingleOrDefault();
            return View(model);
        }


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
    }
}