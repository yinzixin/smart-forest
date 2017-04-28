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
        public ActionResult Index()
        {
            var models = TreeService.Query(1);

            return View(models);
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