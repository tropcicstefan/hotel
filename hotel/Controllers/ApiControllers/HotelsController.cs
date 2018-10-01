using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using hotel.DAL;
using hotel.DTO;
using hotel.Models;

namespace hotel.Controllers.ApiControllers
{
    public class HotelsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Hotels
        [HttpGet]
        public IEnumerable<HotelDto> GetHotels()
        {
            return db.Hotels.Select(Mapper.Map<Hotel, HotelDto>).ToList();
        }

        // GET: api/Hotels/5
        [HttpGet]
        [ResponseType(typeof(HotelDto))]
        public IHttpActionResult GetHotel(int id)
        {
            Hotel hotel = db.Hotels.SingleOrDefault(h => h.ID == id);

            if (hotel is null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Hotel, HotelDto>(hotel));
        }

        // PUT: api/Hotels/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotel(int id, HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Hotel hotel = db.Hotels.SingleOrDefault(h => h.ID == id);

            if(hotel is null)
            {
                return NotFound();
            }

            Mapper.Map(hotelDto, hotel);
            db.SaveChanges();    

            return Ok();
        }

        // POST: api/Hotels
        [HttpPost]
        [ResponseType(typeof(HotelDto))]
        public IHttpActionResult PostHotel(HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Hotel hotel = Mapper.Map<HotelDto, Hotel>(hotelDto);

            db.Hotels.Add(hotel);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + hotel.ID), hotelDto);
        }



        // DELETE: api/Hotels/5
        [HttpDelete]
        [ResponseType(typeof(HotelDto))]
        public IHttpActionResult DeleteHotel(int id)
        {
            Hotel hotel = db.Hotels.SingleOrDefault(h => h.ID == id);

            if (hotel is null)
            {
                return NotFound();
            }

            db.Hotels.Remove(hotel);
            db.SaveChanges();
            

            return Ok(Mapper.Map<Hotel, HotelDto>(hotel));
        }

    }
}