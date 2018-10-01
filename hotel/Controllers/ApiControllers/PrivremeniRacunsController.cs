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
    public class PrivremeniRacunsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/PrivremeniRacuns
        public IEnumerable<PrivremeniRacunDto> GetPrivremeniRacuns()
        {
            return db.PrivremeniRacuns.Select(Mapper.Map<PrivremeniRacun, PrivremeniRacunDto>).ToList();
        }

        // GET: api/PrivremeniRacuns/5
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

        // PUT: api/PrivremeniRacuns/5
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

        // POST: api/PrivremeniRacuns
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

        // DELETE: api/PrivremeniRacuns/5
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

        [ResponseType(typeof(PrivremeniRacunViewModelDto))]
        [Route("api/StavkePrivremenogRacuna/prID/{prID}")]
        public IHttpActionResult GetSlobodneSobe(int prID)
        {           
            if(db.PrivremeniRacuns.Find(prID) is null)
            {
                return NotFound();
            }

            var stavkes = db.Stavkes.Where(x => x.PrivremeniRacunID == prID).ToList();
            var elementPonudes = db.ElementPonudes.ToList();
            PrivremeniRacunViewModelDto privremeniRacunViewModelDto = new PrivremeniRacunViewModelDto()
            {
                Stavkes = Mapper.Map<List<Stavke>, List<StavkeDto>>(stavkes),
                ElementPonudes = Mapper.Map<List<ElementPonude>, List<ElementPonudeDto>>(elementPonudes)
            };
                                 


            return Ok(privremeniRacunViewModelDto);
        }
    }
}