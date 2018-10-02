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
    public class RezervacijaController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Rezervacijas
        [HttpGet]
        public IEnumerable<RezervacijaDto> GetRezervacija()
        {
            return db.Rezervacijas.Select(Mapper.Map<Rezervacija, RezervacijaDto>).ToList();
        }

        [Route("api/TrenutacneRezervacije")]
        [HttpGet]
        public IEnumerable<RezervacijaDto> GetTrenutacneRezervacije()
        {
            return db.Rezervacijas.Where(x => 
            (x.DatumOdDolaska == new DateTime(1900, 1, 1))).Select(Mapper.Map<Rezervacija, RezervacijaDto>).ToList();
            
        }

        // GET: api/Rezervacijas/5
        [HttpGet]
        [ResponseType(typeof(RezervacijaDto))]
        public IHttpActionResult GetRezervacija(int id)
        {
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Rezervacija, RezervacijaDto>(rezervacija));
        }

        // PUT: api/Rezervacija
        //koristiti kod checkina rezervacije
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRezervacija(RezervacijaDto rezervacijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                        
            Rezervacija rezervacija = db.Rezervacijas.Find(rezervacijaDto.ID);
            if(rezervacija is null)
            {
                return NotFound();
            }
            Mapper.Map(rezervacijaDto, rezervacija);
            db.SaveChanges();
            return Ok();
        }

        // POST: api/Rezervacija
        //rezervacija za buducnost
        //vjerojatno treba provjera jel soba slobodna ali ako se koristi api za slobodne sobe ne bi trebalo bit problema
        [HttpPost]
        [ResponseType(typeof(RezervacijaDto))]
        public IHttpActionResult PostRezervacija(RezervacijaDto rezervacijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            rezervacijaDto.DatumOdDolaska = new DateTime(1900, 1, 1);
            rezervacijaDto.DatumDoDolaska = new DateTime(1900, 1, 1);
            Rezervacija rezervacija = Mapper.Map<RezervacijaDto, Rezervacija>(rezervacijaDto);

            db.Rezervacijas.Add(rezervacija);
            db.SaveChanges();

            rezervacijaDto.ID = rezervacija.ID;

            return Created(new Uri(Request.RequestUri + "/" + rezervacija.ID), rezervacijaDto);

        }

        // DELETE: api/Rezervacija/5
        [HttpDelete]
        [ResponseType(typeof(Rezervacija))]
        public IHttpActionResult DeleteRezervacija(int id)
        {
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            db.Rezervacijas.Remove(rezervacija);
            db.SaveChanges();

            return Ok(Mapper.Map<Rezervacija, RezervacijaDto>(rezervacija));
        }
    }
}