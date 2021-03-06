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
    public class ElementPonudeController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/ElementPonude
        [HttpGet]
        public IEnumerable<ElementPonudeDto> GetElementPonude()
        {
           
            return db.ElementPonudes.Select(Mapper.Map<ElementPonude, ElementPonudeDto>).ToList();
        }

        // GET: api/ElementPonude/5
        [HttpGet]
        [ResponseType(typeof(ElementPonudeDto))]
        public IHttpActionResult GetElementPonude(int id)
        {
            ElementPonude elementPonude = db.ElementPonudes.Find(id);
            if (elementPonude is null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ElementPonude, ElementPonudeDto>(elementPonude));
        }

        // PUT: api/ElementPonude
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElementPonude(ElementPonudeDto elementPonudeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            ElementPonude element = db.ElementPonudes.SingleOrDefault(e => e.ID == elementPonudeDto.ID);

            if (element is null)
            {
                return NotFound();
            }

            Mapper.Map(elementPonudeDto, element);
            db.SaveChanges();

            return Ok();

        }

        // POST: api/ElementPonude
        [HttpPost]
        [ResponseType(typeof(ElementPonudeDto))]
        public IHttpActionResult PostElementPonude(ElementPonudeDto elementPonudeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ElementPonude elementPonude = Mapper.Map<ElementPonudeDto, ElementPonude>(elementPonudeDto);

            db.ElementPonudes.Add(elementPonude);
            db.SaveChanges();
            

            return Created(new Uri(Request.RequestUri + "/" + elementPonude.ID), elementPonudeDto);
        }

        // DELETE: api/ElementPonude/5
        [HttpDelete]
        [ResponseType(typeof(ElementPonudeDto))]
        public IHttpActionResult DeleteElementPonude(int id)
        {
            ElementPonude elementPonude = db.ElementPonudes.Find(id);
            if (elementPonude == null)
            {
                return NotFound();
            }

            db.ElementPonudes.Remove(elementPonude);
            db.SaveChanges();

            return Ok(Mapper.Map<ElementPonude, ElementPonudeDto>(elementPonude));
        }

    }
}