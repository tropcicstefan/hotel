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
    public class GostsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Gosts
        public IEnumerable<GostDto> GetGosts()
        {
            return db.Gosts.ToList().Select(Mapper.Map<Gost, GostDto>);
        }

        // GET: api/Gosts/5
        [ResponseType(typeof(GostDto))]
        public IHttpActionResult GetGost(int id)
        {
            Gost gost = db.Gosts.Find(id);
            if (gost is null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Gost, GostDto>(gost));
        }

        // PUT: api/Gosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGost(int id, GostDto gostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gostDto.ID)
            {
                return BadRequest("Wrong id");
            }
            Gost gost = db.Gosts.SingleOrDefault(g => g.ID == id);

            if (gost is null)
            {
                return NotFound();
            }

            Mapper.Map(gostDto, gost);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/Gosts
        [ResponseType(typeof(GostDto))]
        public IHttpActionResult PostGost(GostDto gostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Gost gost = Mapper.Map<GostDto, Gost>(gostDto);

            db.Gosts.Add(gost);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + gost.ID), gostDto);
        }

        // DELETE: api/Gosts/5
        [ResponseType(typeof(GostDto))]
        public IHttpActionResult DeleteGost(int id)
        {
            Gost gost = db.Gosts.Find(id);
            if (gost is null)
            {
                return NotFound();
            }

            db.Gosts.Remove(gost);
            db.SaveChanges();

            return Ok(Mapper.Map<Gost, GostDto>(gost));
        }

    }
}