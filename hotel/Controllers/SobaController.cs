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
    public class SobaController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Soba
        public ActionResult Index()
        {
            var sobas = db.Sobas.Include(s => s.Hotel).Include(s => s.SobaTip);
            return View(sobas.ToList());
        }

        // GET: Soba/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return HttpNotFound();
            }
            return View(soba);
        }

        // GET: Soba/Create
        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Naziv");
            ViewBag.SobaTipID = new SelectList(db.SobaTips, "ID", "Naziv");
            return View();
        }

        // POST: Soba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SobaTipID,HotelID")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                db.Sobas.Add(soba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Naziv", soba.HotelID);
            ViewBag.SobaTipID = new SelectList(db.SobaTips, "ID", "Naziv", soba.SobaTipID);
            return View(soba);
        }

        // GET: Soba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Naziv", soba.HotelID);
            ViewBag.SobaTipID = new SelectList(db.SobaTips, "ID", "Naziv", soba.SobaTipID);
            return View(soba);
        }

        // POST: Soba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SobaTipID,HotelID")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Naziv", soba.HotelID);
            ViewBag.SobaTipID = new SelectList(db.SobaTips, "ID", "Naziv", soba.SobaTipID);
            return View(soba);
        }

        // GET: Soba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return HttpNotFound();
            }
            return View(soba);
        }

        // POST: Soba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soba soba = db.Sobas.Find(id);
            db.Sobas.Remove(soba);
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
