using HandJWebApp.Models.DataContext;
using HandJWebApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HandJWebApp.Controllers
{
    public class AboutUsController : Controller
    {
        BusinessWebDBContext db = new BusinessWebDBContext();

        // GET: AboutUs
        public ActionResult Index()
        {
            var a = db.AboutUs.ToList();
            return View(a);
        }
     

        public ActionResult Edit(int id)
        {
            var a= db.AboutUs.Where(x => x.AboutUsId == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit (int id, AboutUs a)
        {
            if (ModelState.IsValid)
            {
              var AboutUs = db.AboutUs.Where(x => x.AboutUsId == id).SingleOrDefault();
                AboutUs.Comment= a.Comment;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
    }
}
