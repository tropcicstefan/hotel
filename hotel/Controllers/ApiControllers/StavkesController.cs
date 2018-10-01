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
    public class StavkesController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Stavkes
        public IEnumerable<StavkeDto> GetStavkes()
        {
            return db.Stavkes.ToList().Select(Mapper.Map<Stavke, StavkeDto>);
        }

        // GET: api/Stavkes/5
        [ResponseType(typeof(StavkeDto))]
        public IHttpActionResult GetStavke(int id)
        {
            Stavke stavke = db.Stavkes.Find(id);
            if (stavke == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Stavke, StavkeDto>(stavke));
        }

        // PUT: api/Stavkes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavke(int id, StavkeDto stavkeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavkeDto.PrivremeniRacunID)
            {
                return BadRequest();
            }
            Stavke stavke = db.Stavkes.SingleOrDefault(s => s.PrivremeniRacunID == id && s.ElementPonudeID == stavkeDto.ElementPonudeID);

            if(stavke is null)
            {
                return NotFound();
            }
            Mapper.Map(stavkeDto, stavke);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/Stavkes
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

        // DELETE: api/Stavkes/5
        //jel se u slucaju composite kljuceva pisu custom routes ili????
        [ResponseType(typeof(StavkeDto))]
        [Route("api/Stavkes/PrivremeniRacun/{prId}/ElementPonude/{epId}")]
        public IHttpActionResult DeleteStavke(int prId, int epId)
        {
            Stavke stavke = db.Stavkes.SingleOrDefault(s => s.PrivremeniRacunID == prId && s.ElementPonudeID == epId);
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