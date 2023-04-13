using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HandJWebApp.Models.DataContext;
using HandJWebApp.Models.Model;

namespace HandJWebApp.Controllers
{
    public class SliderController : Controller
    {
        private BusinessWebDBContext db = new BusinessWebDBContext();

        // GET: Sliders
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,Title,Explanation,ImageURL")] Slider slider, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (ImageURL != null)


                {


                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + sliderimgname);

                    slider.ImageURL = "/Uploads/Slider/" + sliderimgname;
                }
                 db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,Baslik,Aciklama,ResimURL")] Slider slider, HttpPostedFileBase ImageURL, int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();
                if (ImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + sliderimgname);

                    s.ImageURL = "/Uploads/Slider/" + sliderimgname;
                }
                s.Title = slider.Title;
                s.Explanation = slider.Explanation;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }


        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Slider slider = db.Slider.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
            // POST: Sliders/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Slider slider = db.Slider.Find(id);
                if (System.IO.File.Exists(Server.MapPath(slider.ImageURL)))
                {
                    System.IO.File.Delete(Server.MapPath(slider.ImageURL));
                }
                db.Slider.Remove(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}