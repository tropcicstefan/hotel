using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using hotel.DAL;
using hotel.DTO;
using hotel.Models;

namespace hotel.Controllers.ApiControllers
{
    public class IzdaniRacunsController : ApiController
    {
        private HotelContext db = new HotelContext();


        // GET: api/IzdaniRacuns/5(id rezervacije)
        [HttpGet]
        [ResponseType(typeof(PrikazRacunaViewModelDto))]
        public IHttpActionResult GetIzdaniRacun(int id)
        {
            Rezervacija rezervacija = db.Rezervacijas.SingleOrDefault(p => p.ID == id);
            if(rezervacija is null)
            {
                return NotFound();
            }
            var privremeniRacuns = db.PrivremeniRacuns.Where(p => p.RezervacijaID == id).ToList();
            var prID = privremeniRacuns.Select(p => p.ID).ToList();
            var stavke = db.Stavkes.Where(s => prID.Contains(s.PrivremeniRacunID)).ToList();

            PrikazRacunaViewModelDto prikazRacunaView = new PrikazRacunaViewModelDto()
            {
                Rezervacija = Mapper.Map<Rezervacija, RezervacijaDto>(rezervacija),
                Stavkes = new List<PrikazStavke>()
            };

            for (int i = 0; i < stavke.Count; i++)
            {
                prikazRacunaView.Stavkes.Add(new PrikazStavke()
                {
                    JedinicnaCijena = stavke[i].ElementPonude.JedinicnaCijena,
                    Kolicina = stavke[i].Kolicina,
                    Naziv = stavke[i].ElementPonude.Naziv
                });
                
            }
            prikazRacunaView.Stavkes.Add(new PrikazStavke()
            {
                JedinicnaCijena = Convert.ToInt32(rezervacija.Soba.SobaTip.Cijena),
                Kolicina = Convert.ToInt32((rezervacija.DatumDoDolaska - rezervacija.DatumOdDolaska).TotalDays),
                Naziv = rezervacija.Soba.SobaTip.Naziv
            });

            return Ok(prikazRacunaView);
        }


    }
}