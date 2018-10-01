using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotel.DAL;
using hotel.Models;

namespace hotel.Controllers
{
    public class GostController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Gost
        public ActionResult Index()
        {
            return View(db.Gosts.ToList());
        }

        // GET: Gost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gost gost = db.Gosts.Find(id);
            if (gost == null)
            {
                return HttpNotFound();
            }
            return View(gost);
        }

        // GET: Gost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime")] Gost gost)
        {
            if (ModelState.IsValid)
            {
                db.Gosts.Add(gost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gost);
        }

        // GET: Gost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gost gost = db.Gosts.Find(id);
            if (gost == null)
            {
                return HttpNotFound();
            }
            return View(gost);
        }

        // POST: Gost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime")] Gost gost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gost);
        }

        // GET: Gost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gost gost = db.Gosts.Find(id);
            if (gost == null)
            {
                return HttpNotFound();
            }
            return View(gost);
        }

        // POST: Gost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gost gost = db.Gosts.Find(id);
            db.Gosts.Remove(gost);
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
