using hotel.DAL;
using hotel.Models;
using hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    public class PrivremeniRacunController : Controller
    {
        private HotelContext db = new HotelContext();



        public ActionResult OdaberiRezervaciju()
        {
            var viewModel = new OdaberiRezervacijuViewModel()
            {
                TrenutacneRezervacije = db.Rezervacijas.Where(x => (x.DatumOdDolaska != new DateTime(1900, 1, 1)) && ((x.DatumDoDolaska == new DateTime(1900, 1, 1)) || (x.DatumDoDolaska >= DateTime.Now))).ToList()
            };
            return View(viewModel);
        }



        [HttpPost]
        public ActionResult OdabranaRezervacija(int id)
        {
            PrivremeniRacun privremeniRacun = new PrivremeniRacun()
            {
                RezervacijaID = id,
                Placeno = false
            };

            db.PrivremeniRacuns.Add(privremeniRacun);
            db.SaveChanges();


            int za = privremeniRacun.ID;

            return RedirectToAction("Index", new { pRId = za });
        }



        public ActionResult Index(int pRId)
        {
            var viewmodel = new PrivremeniRacunViewModel()
            {
                Stavkes = db.Stavkes.Where(x => x.PrivremeniRacunID == pRId).ToList(),
                ElementPonudes = db.ElementPonudes.ToList(),
                Stavka = new Stavke()
                {
                    PrivremeniRacunID = pRId
                }
            };

            return View(viewmodel);
        }



        [HttpPost]
        public ActionResult DodajStavku(Stavke stavka)
        {
            Stavke proba = db.Stavkes.SingleOrDefault(s => s.PrivremeniRacunID == stavka.PrivremeniRacunID
                                        && s.ElementPonudeID == stavka.ElementPonudeID);
            if (proba is null)
            {
                db.Stavkes.Add(stavka);
            }
            else
            {
                proba.Kolicina += stavka.Kolicina;
                db.Entry(proba).State = EntityState.Modified;
            }

            db.SaveChanges();

            return RedirectToAction("Index", new { pRId = stavka.PrivremeniRacunID });
        }

        [HttpPost]
        public ActionResult ZavrsiRacun(int privremeniRacunId)
        {
            PrivremeniRacun privremeniRacun = db.PrivremeniRacuns.Single(x => x.ID == privremeniRacunId);

            privremeniRacun.Placeno = true;
            db.Entry(privremeniRacun).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ObrisiRacun(int privremeniRacunId)
        {
            PrivremeniRacun privremeniRacun = db.PrivremeniRacuns.Single(x => x.ID == privremeniRacunId);

            var stavke = db.Stavkes.Where(s => s.PrivremeniRacunID == privremeniRacunId).ToList();

            stavke.ForEach(s => db.Stavkes.Remove(s));

            db.PrivremeniRacuns.Remove(privremeniRacun);

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}