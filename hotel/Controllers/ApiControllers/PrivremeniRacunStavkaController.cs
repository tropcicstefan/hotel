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
    public class PrivremeniRacunStavkaController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/PrivremeniRacunStavka
        [HttpGet]
        public IEnumerable<StavkeDto> GetStavke()
        {
            return db.Stavkes.Select(Mapper.Map<Stavke, StavkeDto>).ToList();
        }

        //stavke specificnog privremenog racuna
        [HttpGet]
        [Route("api/PrivremeniRacunStavka/prID/{prID}")]
        public IHttpActionResult GetStavke(int prID)
        {
            if (db.PrivremeniRacuns.Find(prID) is null)
            {
                return NotFound();
            }

            var stavkes = db.Stavkes.Where(x => x.PrivremeniRacunID == prID).ToList();

            return Ok(Mapper.Map<List<Stavke>, List<StavkeDto>>(stavkes));
        }


        [HttpGet]
        [ResponseType(typeof(StavkeDto))]
        [Route("api/PrivremeniRacunStavka/prId/{prId}/epId/{epId}")]
        public IHttpActionResult GetStavke(int prId, int epId)
        {
            Stavke stavke = db.Stavkes.SingleOrDefault(s => s.PrivremeniRacunID == prId && s.ElementPonudeID == epId);
            if (stavke == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Stavke, StavkeDto>(stavke));
        }

        // PUT: api/PrivremeniRacunStavka
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavke(StavkeDto stavkeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stavke stavke = db.Stavkes.SingleOrDefault(s => s.PrivremeniRacunID == stavkeDto.PrivremeniRacunID && s.ElementPonudeID == stavkeDto.ElementPonudeID);

            if(stavke is null)
            {
                return NotFound();
            }
            Mapper.Map(stavkeDto, stavke);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/PrivremeniRacunStavka
        [HttpPost]
        [ResponseType(typeof(StavkeDto))]
        public IHttpActionResult PostStavke(StavkeDto stavkeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Stavke postojecaStavka= db.Stavkes
                .SingleOrDefault(s => s.PrivremeniRacunID == stavkeDto.PrivremeniRacunID && s.ElementPonudeID == stavkeDto.ElementPonudeID);
            if(postojecaStavka is null)
            {
                Stavke stavke = Mapper.Map<StavkeDto, Stavke>(stavkeDto);
                db.Stavkes.Add(stavke);
                db.SaveChanges();
                return Created(new Uri(Request.RequestUri + "/" + stavke.PrivremeniRacunID), stavkeDto);
            }
            else
            {
                postojecaStavka.Kolicina += stavkeDto.Kolicina;
                db.SaveChanges();
                return Created(new Uri(Request.RequestUri + "/" + postojecaStavka.PrivremeniRacunID), Mapper.Map<Stavke, StavkeDto>(postojecaStavka));
            }
            
        }

        [HttpDelete]
        [ResponseType(typeof(StavkeDto))]
        public IHttpActionResult DeleteStavke(StavkeDto stavkeDto)
        {
            Stavke stavke = db.Stavkes.SingleOrDefault(s => s.PrivremeniRacunID == stavkeDto.PrivremeniRacunID && s.ElementPonudeID == stavkeDto.ElementPonudeID);
            if (stavke == null)
            {
                return NotFound();
            }

            db.Stavkes.Remove(stavke);
            db.SaveChanges();

            return Ok(Mapper.Map<Stavke, StavkeDto>(stavke));
        }

    }
}