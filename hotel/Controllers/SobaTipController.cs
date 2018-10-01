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
    public class SobaTipController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: SobaTip
        public ActionResult Index()
        {
            return View(db.SobaTips.ToList());
        }

        // GET: SobaTip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SobaTip sobaTip = db.SobaTips.Find(id);
            if (sobaTip == null)
            {
                return HttpNotFound();
            }
            return View(sobaTip);
        }

        // GET: SobaTip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SobaTip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Cijena")] SobaTip sobaTip)
        {
            if (ModelState.IsValid)
            {
                db.SobaTips.Add(sobaTip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sobaTip);
        }

        // GET: SobaTip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SobaTip sobaTip = db.SobaTips.Find(id);
            if (sobaTip == null)
            {
                return HttpNotFound();
            }
            return View(sobaTip);
        }

        // POST: SobaTip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Cijena")] SobaTip sobaTip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sobaTip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sobaTip);
        }

        // GET: SobaTip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SobaTip sobaTip = db.SobaTips.Find(id);
            if (sobaTip == null)
            {
                return HttpNotFound();
            }
            return View(sobaTip);
        }

        // POST: SobaTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SobaTip sobaTip = db.SobaTips.Find(id);
            db.SobaTips.Remove(sobaTip);
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
