using HandJWebApp.Models.DataContext;
using HandJWebApp.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HandJWebApp.Controllers
{
    public class IdentityController : Controller
    {
        BusinessWebDBContext db = new BusinessWebDBContext();
        // GET: Identity
        public ActionResult Index()
        {
            return View(db.Identity.ToList());
        }




        // GET: Identity/Edit/5
        public ActionResult Edit(int id)
        {
            var identity = db.Identity.Where(x => x.IdentityId == id).SingleOrDefault();
            return View(identity);
        }

        // POST: Identity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Identity ıdentity, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid) 
            {
                var ı = db.Identity.Where(x => x.IdentityId == id).SingleOrDefault();

                if (LogoURL != null)

                {
                    if (System.IO.File.Exists(Server.MapPath(ıdentity.LogoURL)))

                    {
                        System.IO.File.Delete(Server.MapPath(ıdentity.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    string logoname = LogoURL.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Identity/"+ logoname);

                    ı.LogoURL = "/Uploads/Identity/" + logoname;


                }
              
                ı.Title = ıdentity.Title;
                ı.Keywords = ıdentity.Keywords;
                ı.Description = ıdentity.Description;
                ı.Unvan = ıdentity.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(ıdentity);


        }
    }
}
