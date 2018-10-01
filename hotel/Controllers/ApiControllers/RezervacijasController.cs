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
    public class RezervacijasController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Rezervacijas
        public IEnumerable<RezervacijaDto> GetRezervacijas()
        {
            return db.Rezervacijas.ToList().Select(Mapper.Map<Rezervacija, RezervacijaDto>);
        }

        [Route("api/TrenutacneRezervacijas")]
        public IEnumerable<RezervacijaDto> GetTrenutacneRezervacijas()
        {
            return db.Rezervacijas.Where(x => (x.DatumOdDolaska != new DateTime(1900, 1, 1)) && ((x.DatumDoDolaska == new DateTime(1900, 1, 1)) || (x.DatumDoDolaska >= DateTime.Now))).ToList().Select(Mapper.Map<Rezervacija, RezervacijaDto>);
            
        }

        // GET: api/Rezervacijas/5
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

        // PUT: api/Rezervacijas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRezervacija(int id, RezervacijaDto rezervacijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rezervacijaDto.ID)
            {
                return BadRequest("Wrong id");
            }
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            if(rezervacija is null)
            {
                return NotFound();
            }
            Mapper.Map(rezervacijaDto, rezervacija);
            db.SaveChanges();
            return Ok();
        }

        // POST: api/Rezervacijas
        [ResponseType(typeof(RezervacijaDto))]
        public IHttpActionResult PostRezervacija(RezervacijaDto rezervacijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Rezervacija rezervacija = Mapper.Map<RezervacijaDto, Rezervacija>(rezervacijaDto);

            db.Rezervacijas.Add(rezervacija);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + rezervacija.ID), rezervacijaDto);

        }

        // DELETE: api/Rezervacijas/5
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