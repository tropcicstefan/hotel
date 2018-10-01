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
    public class ElementPonudeController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: ElementPonude
        public ActionResult Index()
        {
            return View(db.ElementPonudes.ToList());
        }

        // GET: ElementPonude/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementPonude elementPonude = db.ElementPonudes.Find(id);
            if (elementPonude == null)
            {
                return HttpNotFound();
            }
            return View(elementPonude);
        }

        // GET: ElementPonude/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElementPonude/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JedinicnaCijena,Naziv")] ElementPonude elementPonude)
        {
            if (ModelState.IsValid)
            {
                db.ElementPonudes.Add(elementPonude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(elementPonude);
        }

        // GET: ElementPonude/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementPonude elementPonude = db.ElementPonudes.Find(id);
            if (elementPonude == null)
            {
                return HttpNotFound();
            }
            return View(elementPonude);
        }

        // POST: ElementPonude/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JedinicnaCijena,Naziv")] ElementPonude elementPonude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elementPonude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(elementPonude);
        }

        // GET: ElementPonude/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementPonude elementPonude = db.ElementPonudes.Find(id);
            if (elementPonude == null)
            {
                return HttpNotFound();
            }
            return View(elementPonude);
        }

        // POST: ElementPonude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ElementPonude elementPonude = db.ElementPonudes.Find(id);
            db.ElementPonudes.Remove(elementPonude);
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
