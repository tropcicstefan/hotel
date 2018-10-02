using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
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
    public class SlobodneSobeController: ApiController
    {
        private HotelContext db = new HotelContext();

        [ResponseType(typeof(SlobodneSobeDto))]
        [HttpGet]
        public IHttpActionResult GetSlobodneSobe([FromUri]DatumiViewModelDto datumiViewModelDto)
        {
            Gost gost = db.Gosts.SingleOrDefault(g=>g.ID == datumiViewModelDto.GostID);
            if (gost is null)
            {
                return NotFound();
            }


            if (datumiViewModelDto.DatumOd < DateTime.Now)
            {
                return BadRequest("bad date");
            }

            var rezervacije = db.Rezervacijas.Where(r => (datumiViewModelDto.DatumOd > r.DatumOd && datumiViewModelDto.DatumOd < r.DatumDo) || (datumiViewModelDto.DatumOd > r.DatumOdDolaska && datumiViewModelDto.DatumOd < r.DatumDoDolaska)
                                                      || (datumiViewModelDto.DatumDo > r.DatumOd && datumiViewModelDto.DatumDo < r.DatumDo) || (datumiViewModelDto.DatumDo > r.DatumOdDolaska && datumiViewModelDto.DatumDo < r.DatumDoDolaska));

            var sID = rezervacije.Select(r => r.SobaID).ToList();
            var sobas = db.Sobas.Where(s => !sID.Contains(s.ID)).ToList();

            SlobodneSobeDto slobodneSobe = new SlobodneSobeDto()
            {
                SlobodneSobas = Mapper.Map<List<Soba>, List<SobaDto>>(sobas)                
            };

                                                  
            return Ok(slobodneSobe);
        }
    }
}