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
    public class PrivremeniRacunController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/PrivremeniRacun
        [HttpGet]
        public IEnumerable<PrivremeniRacunDto> GetPrivremeniRacun()
        {
            return db.PrivremeniRacuns.Select(Mapper.Map<PrivremeniRacun, PrivremeniRacunDto>).ToList();
        }

        // GET: api/PrivremeniRacun/5
        [HttpGet]
        [ResponseType(typeof(PrivremeniRacunDto))]
        public IHttpActionResult GetPrivremeniRacun(int id)
        {
            PrivremeniRacun privremeniRacun = db.PrivremeniRacuns.Find(id);
            if (privremeniRacun == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PrivremeniRacun, PrivremeniRacunDto>(privremeniRacun));
        }

        // PUT: api/PrivremeniRacun
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrivremeniRacun(PrivremeniRacunDto privremeniRacunDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           

            PrivremeniRacun privremeniRacun = db.PrivremeniRacuns.Find(privremeniRacunDto.ID);
            if(privremeniRacun is null)
            {
                return NotFound();
            }

            Mapper.Map(privremeniRacunDto, privremeniRacun);
            db.SaveChanges();


            return Ok();
        }

        // POST: api/PrivremeniRacun
        [HttpPost]
        [ResponseType(typeof(PrivremeniRacunDto))]
        public IHttpActionResult PostPrivremeniRacun(PrivremeniRacunDto privremeniRacunDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PrivremeniRacun privremeniRacun = Mapper.Map<PrivremeniRacunDto, PrivremeniRacun>(privremeniRacunDto);

            db.PrivremeniRacuns.Add(privremeniRacun);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + privremeniRacun.ID), privremeniRacunDto);
        }

        // DELETE: api/PrivremeniRacun/5
        [HttpDelete]
        [ResponseType(typeof(PrivremeniRacun))]
        public IHttpActionResult DeletePrivremeniRacun(int id)
        {
            PrivremeniRacun privremeniRacun = db.PrivremeniRacuns.Find(id);
            if (privremeniRacun == null)
            {
                return NotFound();
            }

            db.PrivremeniRacuns.Remove(privremeniRacun);
            db.SaveChanges();

            return Ok(Mapper.Map<PrivremeniRacun, PrivremeniRacunDto>(privremeniRacun));
        }

        
    }
}