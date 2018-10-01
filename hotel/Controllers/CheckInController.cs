using hotel.DAL;
using hotel.Models;
using hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    public class CheckInController : Controller
    {
        private HotelContext db = new HotelContext();
        // GET: CheckIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OdaberiRezervaciju()
        {
            var viewModel = new OdaberiRezervacijuViewModel()
            {
                TrenutacneRezervacije = db.Rezervacijas.Where(x => x.DatumOdDolaska == new DateTime(1900, 1, 1)).ToList(),
                DanasnjiDatum = DateTime.Now
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckInRezervacije(Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("OdaberiRezervaciju");
        }


        /// <summary>
        /// osoba bez rezervacije
        /// </summary>
        /// <returns></returns>
        public ActionResult NapraviCheckIn()
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
                return RedirectToAction("DatumCheckIn", new { gostID = gost.ID });

            }
            return RedirectToAction("NapraviCheckIn");
        }

        [Route("CheckIn/DatumCheckIn/gost={gostID}")]
        public ActionResult DatumCheckIn(int gostID)
        {

            DatumiViewModel viewModel = new DatumiViewModel()
            {
                GostID = gostID
            };

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult SpremanjeDatuma(DatumiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SobaRezervacija", viewModel);
            }

            return RedirectToAction("DatumRezervacija");

        }

        public ActionResult SobaRezervacija(DatumiViewModel viewModel)
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
                    DatumOd = new DateTime(1900, 1, 1),
                    DatumDo = new DateTime(1900, 1, 1),
                    GostID = viewModel.GostID,
                    DatumOdDolaska = viewModel.DatumOd,
                    DatumDoDolaska = viewModel.DatumDo
                }
            };



            return View(SobeViewModel);

        }

        [HttpPost]

        public ActionResult SpremanjeSobe(Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("PregledCheckIn", rezervacija);
            }
            return RedirectToAction("PregledCheckIn", rezervacija);
        }

        public ActionResult PregledCheckIn(Rezervacija rezervacija)
        {
            ModelState.Clear();
            return View(rezervacija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SpremanjeCheckIn([Bind(Include = "ID, SobaID, GostID, DatumOd, DatumDo, DatumOdDolaska, DatumDoDolaska, Popust")] Rezervacija rezervacija)
        {
            if (rezervacija.ID == 0)
            {
                db.Rezervacijas.Add(rezervacija);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("PregledCheckIn", rezervacija);
        }
    }
}