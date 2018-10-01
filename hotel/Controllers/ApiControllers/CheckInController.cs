using AutoMapper;
using hotel.DAL;
using hotel.DTO;
using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace hotel.Controllers.ApiControllers
{
    public class CheckInController : ApiController
    {
        private HotelContext db = new HotelContext();
        //koristiti za checkin bez rezervacije
        [HttpPost]
        [ResponseType(typeof(RezervacijaDto))]
        public IHttpActionResult PostCheckIn(RezervacijaDto rezervacijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            rezervacijaDto.DatumOd = new DateTime(1900, 1, 1);
            rezervacijaDto.DatumDo = new DateTime(1900, 1, 1);
            Rezervacija rezervacija = Mapper.Map<RezervacijaDto, Rezervacija>(rezervacijaDto);

            db.Rezervacijas.Add(rezervacija);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + rezervacija.ID), rezervacijaDto);

        }
        //sve checkinane
        [Route("api/TrenutacniCheckIn")]
        [HttpGet]
        public IEnumerable<RezervacijaDto> GetTrenutacniCheckIn()
        {
            return db.Rezervacijas.Where(x =>
            (x.DatumOdDolaska != new DateTime(1900, 1, 1)) &&
            ((x.DatumDoDolaska == new DateTime(1900, 1, 1)) || (x.DatumDoDolaska >= DateTime.Now))).Select(Mapper.Map<Rezervacija, RezervacijaDto>).ToList();

        }
    }
}
