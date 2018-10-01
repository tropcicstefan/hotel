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
    public class RacunController : Controller
    {
        private HotelContext db = new HotelContext();


        //db.Configuration.ProxyCreationEnabled = true;    
        //db.Configuration.LazyLoadingEnabled = true; 
        // GET: Racun
        public ActionResult Index()
        {
            var viewModel = new OdaberiRezervacijuViewModel()
            {
                TrenutacneRezervacije = db.Rezervacijas.Where(x => (x.DatumOdDolaska != new DateTime(1900, 1, 1)) && (x.DatumDoDolaska == new DateTime(1900, 1, 1) || x.DatumDoDolaska >= DateTime.Now)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]        
        public ActionResult OdabranaRezervacija(int id)
        {
            Rezervacija rezervacijaOdabrana = db.Rezervacijas.Single(x => x.ID == id);
            rezervacijaOdabrana.DatumDoDolaska = DateTime.Now;

            db.Entry(rezervacijaOdabrana).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("PrikazRacuna", rezervacijaOdabrana);
        }

        public ActionResult PrikazRacuna(Rezervacija rezervacija)
        {
            var privremeniRacuns = db.PrivremeniRacuns.Where(p => p.RezervacijaID == rezervacija.ID).ToList();
            var prID = privremeniRacuns.Select(p => p.ID).ToList();

            var stavke = db.Stavkes.Where(s => prID.Contains(s.PrivremeniRacunID)).ToList();


            rezervacija.Soba = db.Sobas.SingleOrDefault(s => s.ID == rezervacija.SobaID);

            var viewModel = new PrikazRacunaViewModel()
            {
                Stavkes = stavke,
                Rezervacija = rezervacija
            };

            return View("PrikazRacuna", viewModel);
        }

        [HttpPost]        
        public ActionResult ZavrsiRacun(Rezervacija rezervacija)
        {

            db.PrivremeniRacuns.Where(p => p.RezervacijaID == rezervacija.ID).ForEachAsync(async p => {
                p.Placeno = true;
                db.Entry(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
            });

            

            return RedirectToAction("Index", "Home");


        }
    }
}