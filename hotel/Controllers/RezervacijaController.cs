using hotel.DAL;
using hotel.Models;
using hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hotel.Controllers
{
    public class RezervacijaController : Controller
    {
        private HotelContext db = new HotelContext();
        

        // GET: Rezervacija
        public ActionResult GostRezervacija()
        {

            var viewModel = new RezervacijaViewModel()
            {
                Gosts = db.Gosts.ToList()
            };     
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGost([Bind(Include = "ID,Ime,Prezime")] Gost gost)
        {
            if (ModelState.IsValid)
            {
                db.Gosts.Add(gost);
                db.SaveChanges();
                return RedirectToAction("DatumRezervacija", new { gostID = gost.ID });


            }
            return RedirectToAction("GostRezervacija");
        }

       [Route("Rezervacija/DatumRezervacija/g={gostID}")]
        public ActionResult DatumRezervacija(int gostID)
        {
            
            DatumiViewModel viewModel = new DatumiViewModel()
            {
                GostID=gostID
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SpremanjeDatuma(DatumiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SobaRezervacija", viewModel);
            }

            return RedirectToAction("DatumRezervacija", new { gostID = viewModel.GostID });

        }

        public  ActionResult SobaRezervacija(DatumiViewModel viewModel)
        {

            var p0 = viewModel.DatumOd;
            var p1 = viewModel.DatumDo;

            var rezervacije = db.Rezervacijas.Where(r => (p0 > r.DatumOd && p0 < r.DatumDo) || (p0 > r.DatumOdDolaska && p0 < r.DatumDoDolaska)
                                                      || (p1 > r.DatumOd && p1 < r.DatumDo) || (p1 > r.DatumOdDolaska && p1 < r.DatumDoDolaska));

            var sID = rezervacije.Select(r => r.SobaID).ToList();


            var SobeViewModel = new SobaRezervacija()
            {
                SlobodneSobas = db.Sobas.Where(s => !sID.Contains(s.ID)).ToList(),
                Rezervacija = new Rezervacija()
                {
                    DatumOd = viewModel.DatumOd,
                    DatumDo = viewModel.DatumDo,
                    GostID = viewModel.GostID,
                    DatumOdDolaska = new DateTime(1900, 1, 1),
                    DatumDoDolaska = new DateTime(1900, 1, 1)
                }
            };

            return View(SobeViewModel);

        }

        [HttpPost]
        
        public ActionResult SpremanjeSobe(Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("PregledRezervacija", rezervacija);
            }
            return RedirectToAction("GostRezervacija");
        }


        public ActionResult PregledRezervacija(Rezervacija rezervacija)
        {
            ModelState.Clear();
            return View(rezervacija);
        }

        [HttpPost]        
        public ActionResult SpremanjeRezervacija(Rezervacija rezervacija)
        {
            if (rezervacija.ID == 0)
            {
                db.Rezervacijas.Add(rezervacija);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("PregledRezervacija", rezervacija);
        }


    }
}