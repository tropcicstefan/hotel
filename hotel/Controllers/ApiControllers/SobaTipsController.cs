﻿using System;
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
    public class SobaTipsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/SobaTips
        public IEnumerable<SobaTipDto> GetSobaTips()
        {
            return db.SobaTips.ToList().Select(Mapper.Map<SobaTip, SobaTipDto>);
        }

        // GET: api/SobaTips/5
        [ResponseType(typeof(SobaTipDto))]
        public IHttpActionResult GetSobaTip(int id)
        {
            SobaTip sobaTip = db.SobaTips.Find(id);
            if (sobaTip == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SobaTip, SobaTipDto>(sobaTip));
        }

        // PUT: api/SobaTips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSobaTip(int id, SobaTipDto sobaTipDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            SobaTip sobaTip = db.SobaTips.Find(id);

            if(sobaTip == null)
            {
                return NotFound();
            }
            Mapper.Map(sobaTipDto, sobaTip);
            db.SaveChanges();

            return Ok();
      
        }

        // POST: api/SobaTips
        [ResponseType(typeof(SobaTipDto))]
        public IHttpActionResult PostSobaTip(SobaTipDto sobaTipDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SobaTip sobaTip = Mapper.Map<SobaTipDto, SobaTip>(sobaTipDto);


            db.SobaTips.Add(sobaTip);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + sobaTip.ID), sobaTipDto);
        }

        // DELETE: api/SobaTips/5
        [ResponseType(typeof(SobaTipDto))]
        public IHttpActionResult DeleteSobaTip(int id)
        {
            SobaTip sobaTip = db.SobaTips.Find(id);
            if (sobaTip == null)
            {
                return NotFound();
            }

            db.SobaTips.Remove(sobaTip);
            db.SaveChanges();

            return Ok(Mapper.Map<SobaTip, SobaTipDto>(sobaTip));
        }        
    }
}