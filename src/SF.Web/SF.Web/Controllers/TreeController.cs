using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SF.Data;
using SF.Model;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Imaging;

namespace SF.Web.Controllers
{
    public class TreeController :BaseController
    {

        [UserProfileFilter]
        [HttpPost]
        public ActionResult Create(Tree model)
        {
            if (ModelState.IsValid)
            {
                var user = GetUser();
                model.UserID = user.ID;
                TreeService.Create(model);

                var path = Server.MapPath("/label");
                var bytes = TreeTagPainter.Paint(model, HttpContext.Request.Url.Host);
                System.IO.File.WriteAllBytes(path + "/" + model.ID + ".png", bytes);


                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

         [UserProfileFilter]
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
         [UserProfileFilter]
        [HttpGet]
        public ActionResult Edit(long id)
         {

             var model = TreeService.Get(id);
             ConvertViewModel(  model);
             return View(model);
         }
         [UserProfileFilter]
        [HttpPost]
        public ActionResult Edit(Tree model)
        {
            if (ModelState.IsValid)
            { 
                TreeService.Update(model);

                var path=Server.MapPath("/label");
                var bytes = TreeTagPainter.Paint(model, HttpContext.Request.Url.Host);
                System.IO.File.WriteAllBytes(path + "/" + model.ID + ".png", bytes);

                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

         [UserProfileFilter]
        public ActionResult Index(Models.TreeQueryModel q)
        {
            var user = GetUser();
            if (user != null)
            {
                if (q.Jump.HasValue)
                {
                    q.Current = q.Jump.Value;
                    q.Jump = null;
                }
                var models = TreeService.Query(user.ID).ToList();
                var result = DoQuery(q, models);
                ViewBag.q = q;
                int pageSize = 50;
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

        public ActionResult Upload()
         {
             HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
             if (files.Count == 0) return Content("failed"); // Json("Faild", JsonRequestBehavior.AllowGet);
        
          
             string FileEextension = Path.GetExtension(files[0].FileName);
             string uploadDate = DateTime.Now.ToString("yyyyMMdd");
             string virtualPath = string.Format("/upload/{0}/{1}{2}", uploadDate, Guid.NewGuid().ToString(), FileEextension);
             string fullFileName = Server.MapPath(virtualPath);
             //创建文件夹，保存文件
             string path = Path.GetDirectoryName(fullFileName);
             Directory.CreateDirectory(path);
             if (!System.IO.File.Exists(fullFileName))
             {
                 files[0].SaveAs(fullFileName);
             }
             string fileName = files[0].FileName.Substring(files[0].FileName.LastIndexOf("\\") + 1, files[0].FileName.Length - files[0].FileName.LastIndexOf("\\") - 1);
             var str=Newtonsoft.Json.JsonConvert.SerializeObject(new { FileName = fileName, FilePath = virtualPath });
            // return Json(new { FileName = fileName, FilePath = virtualPath },  JsonRequestBehavior.AllowGet);
             return Content(str,"text/html");
         }
        IEnumerable<Tree> DoQuery(Models.TreeQueryModel q, IEnumerable<Tree> source)
        {
            IEnumerable<Tree> r = source.Select(t=>ConvertViewModel(t));
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

        public ActionResult TreeLabel(long id)
        {
            var tree = TreeService.Get(id);
            var data = TreeTagPainter.Paint(tree, HttpContext.Request.Url.Host);
           return File(data, "image/jpeg");
        }

        public ActionResult Barcode(long id)
        {
            var codec = new QRCodeEncoder();
            codec.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            codec.QRCodeScale = 4;
            var barcode = codec.Encode("http://" + HttpContext.Request.Url.Host + "/tree/view/" + id);
             MemoryStream stream = new MemoryStream();
             barcode.Save(stream, ImageFormat.Png);
             return File(stream.ToArray(), "image/png");
        }
        public ActionResult DownloadLabel(string ids)
        {
            var id=ids.Split(',').Select(c => long.Parse(c));
            MemoryStream memory = new MemoryStream();
            using (var output = new ZipOutputStream(memory))
            {
                foreach (var i in id)
                {
                    var tree = TreeService.Get(i);
                    var data = TreeTagPainter.Paint(tree, HttpContext.Request.Url.Host);

                    ZipEntry entry = new ZipEntry(tree.Name + "-" + tree.ID + ".png");
                    entry.DateTime = DateTime.Now;
                    output.PutNextEntry(entry);
                    output.Write(data, 0, data.Length);
                }
                output.Finish();
                output.Close();
            }

            return File(memory.ToArray(),"application/x-zip-compressed","tree-label.zip");
        }

        
        public string Delete(long id)
        {
            TreeService.Delete(id);
            return "OK";
        }

        public ActionResult View(long id)
        {
            var tree = TreeService.Get(id);
            return View(tree);
        }

          [UserProfileFilter]
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