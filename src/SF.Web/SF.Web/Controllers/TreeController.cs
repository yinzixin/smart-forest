using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SF.Data;
using SF.Model;

namespace SF.Web.Controllers
{
    public class TreeController :BaseController
    {

        [HttpPost]
        public ActionResult Create(Tree model)
        {
            if (ModelState.IsValid)
            {
                var user = GetUser();
                model.UserID = user.ID;
                TreeService.Create(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

         [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

         private static Tree ConvertViewModel(  Tree model)
         {
             model.LonText = model.Longtitude.ToString();// = convertDegree(model.LonText);
             model.LatText = model.Latitude.ToString();// = convertDegree(model.LatText);
             model.Age = DateTime.Now.Year - model.YearOfBirth;// = DateTime.Now.Year - model.Age;
             return model;
         }

        [HttpGet]
        public ActionResult Edit(long id)
         {

             var model = TreeService.Get(id);
             ConvertViewModel(  model);
             return View(model);
         }
        [HttpPost]
        public ActionResult Edit(Tree model)
        {
            if (ModelState.IsValid)
            { 
                TreeService.Update(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        public ActionResult Index(Models.TreeQueryModel q)
        {
            var user = GetUser();
            if (user != null)
            {
                var models = TreeService.Query(user.ID).ToList();
                var result = DoQuery(q, models);
                ViewBag.q = q;
                int pageSize = 2;
                int count = result.Count() % pageSize == 0 ? result.Count() / pageSize : result.Count() / pageSize + 1;
                int pageStart = q.Current - pageSize < 1 ? 1 : q.Current - pageSize;
                int pageEnd = q.Current + 2 > count ? count : q.Current + 2;

                List<int> pages = new List<int>();
                for (int i = pageStart; i <= pageEnd;i++ )
                {
                    pages.Add(i);
                }
                ViewBag.page = pages;

                result = result.Skip(q.Current * pageSize - pageSize).Take(pageSize).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        IEnumerable<Tree> DoQuery(Models.TreeQueryModel q, IEnumerable<Tree> source)
        {
            IEnumerable<Tree> r = source;
            if (!string.IsNullOrEmpty(q.Area))
                r = r.Where(s => s.County.Contains(q.Area) || s.City.Contains(q.Area) || s.Address.Contains(q.Area));


            if (!string.IsNullOrEmpty(q.IDName))
                r = r.Where(s => s.Number.Contains(q.IDName) || s.Name.Contains(q.IDName));

            if (q.Age_Start.HasValue)
                r = r.Where(s => s.Age >= q.Age_Start);

            if (q.Age_End.HasValue)
                r = r.Where(s => s.Age <= q.Age_End);

            return r;
        }
 
         
        public ActionResult Map()
        {
            return View();
        }

        public JsonResult MapData()
        {
            var user = GetUser();

            if(user!=null)
            {
                var data=TreeService.Query(user.ID);
                decimal x=0m,y=0m;
                if (data.Any())
                {
                      x = data.Average(t => t.Longtitude);
                      y = data.Average(t => t.Latitude);
                }
                dynamic result = new { x = x, y = y, data = data.Select(d=>ConvertViewModel( d)) };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
    }
}