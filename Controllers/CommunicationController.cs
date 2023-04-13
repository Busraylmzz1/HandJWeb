using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HandJWebApp.Models.DataContext;
using HandJWebApp.Models.Model;

namespace HandJWebApp.Controllers
{
    public class CommunicationController : Controller
    {
        private BusinessWebDBContext db = new BusinessWebDBContext();

        // GET: Communication
        public ActionResult Index()
        {
            return View(db.Communication.ToList());
        }

        // GET: Communication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communication.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // GET: Communication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Communication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommunicationId,Adress,Tel,Fax,WhatsApp,Facebook,Twitter,Linkedln,Instagram")] Communication communication)
        {
            if (ModelState.IsValid)
            {
                db.Communication.Add(communication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(communication);
        }

        // GET: Communication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communication.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // POST: Communication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommunicationId,Adress,Tel,Fax,WhatsApp,Facebook,Twitter,Linkedln,Instagram")] Communication communication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(communication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(communication);
        }

        // GET: Communication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communication.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // POST: Communication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Communication communication = db.Communication.Find(id);
            db.Communication.Remove(communication);
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
