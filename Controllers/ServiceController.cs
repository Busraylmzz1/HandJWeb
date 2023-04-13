using HandJWebApp.Models.DataContext;
using HandJWebApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HandJWebApp.Controllers
{
    public class ServiceController : Controller
    {
        private BusinessWebDBContext db = new BusinessWebDBContext();
        // GET: Service
        public ActionResult Index()
        {
            return View(db.Service.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Service service, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (ImageURL != null)

                {

                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string filename = ImageURL.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Service/" + filename);

                    service.ImageURL = "/Uploads/Service/" + filename;


                }
                db.Service.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Hizmet Bulunamadı";
            }
            var service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            return View(service);
        }
        [HttpPost]
        [ValidateInput((false))]
        public ActionResult Edit(int? id, Service service, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                var s = db.Service.Where(x => x.ServiceId == id).SingleOrDefault();
                if (ImageURL != null)


                {
                    if (System.IO.File.Exists(Server.MapPath(s.ImageURL)))

                    {
                        System.IO.File.Delete(Server.MapPath(s.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string servicename = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Service/" + servicename);

                    s.ImageURL = "/Uploads/Service/" + servicename;

                }


                s.Title = service.Title;
                s.Explanition = service.Explanition;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View();

        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var s = db.Service.Find(id);
            if (s == null)
            {
                return HttpNotFound();

            }

            db.Service.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}

  