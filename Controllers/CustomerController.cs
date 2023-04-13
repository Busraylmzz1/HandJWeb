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
    public class CustomerController : Controller
    {
        private BusinessWebDBContext db = new BusinessWebDBContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public ActionResult Create(Customer customer, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
            if (LogoURL != null)


            {

                WebImage img = new WebImage(LogoURL.InputStream);
                FileInfo imginfo = new FileInfo(LogoURL.FileName);

                string customerimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(400, 173);
                img.Save("~/Uploads/Customer/" + customerimgname);

                customer.LogoURL = "/Uploads/Customer/" + customerimgname;
            }
            db.Customer.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Name,LogoURL")] Customer customer, HttpPostedFileBase LogoURL,int id)
        {
            var c = db.Customer.Where(x => x.CustomerId == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                
                
                if (LogoURL != null)


                {
                    if (System.IO.File.Exists(Server.MapPath(c.LogoURL)))

                    {
                        System.IO.File.Delete(Server.MapPath(c.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    string customerimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Customer/" + customerimgname);

                    customer.LogoURL = "/Uploads/Customer/" + customerimgname;

                }
                c.Name = customer.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
