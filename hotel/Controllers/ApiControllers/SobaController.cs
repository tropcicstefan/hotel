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
    public class SobaController : ApiController
    {
        private IHotelContext db = new HotelContext();

        public SobaController() { }
        public SobaController(IHotelContext context)
        {
            db = context;
        }

        // GET: api/Soba
        [HttpGet]
        public IEnumerable<SobaDto> GetSobas()
        {
            return db.Sobas.Select(Mapper.Map<Soba, SobaDto>).ToList();
        }

        // GET: api/Soba/5
        [HttpGet]
        [ResponseType(typeof(SobaDto))]
        public IHttpActionResult GetSoba(int id)
        {
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Soba, SobaDto>(soba));
        }

        // PUT: api/Soba
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSoba(SobaDto sobaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            Soba soba = db.Sobas.Find(sobaDto.ID);

            if (soba is null)
            {
                return NotFound();
            }

            Mapper.Map(sobaDto, soba);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/Soba
        [HttpPost]
        [ResponseType(typeof(SobaDto))]
        public IHttpActionResult PostSoba(SobaDto sobaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Soba soba = Mapper.Map<SobaDto, Soba>(sobaDto);

            db.Sobas.Add(soba);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = soba.ID }, sobaDto);
        }

        // DELETE: api/Soba/5
        [HttpDelete]
        [ResponseType(typeof(SobaDto))]
        public IHttpActionResult DeleteSoba(int id)
        {
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return NotFound();
            }

            db.Sobas.Remove(soba);
            db.SaveChanges();

            return Ok(Mapper.Map<Soba, SobaDto>(soba));
        }

    }
}