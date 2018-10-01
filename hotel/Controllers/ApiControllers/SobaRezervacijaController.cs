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
    public class SobaRezervacijaController: ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Gosts/5
        [ResponseType(typeof(SobaRezervacijaDto))]
        [Route("api/SobaRezervacija/GostID/{gostID}/DatumOd/{datumO}/DatumDo/{datumD}")]
        public IHttpActionResult GetSlobodneSobe(int gostId, string datumO, string datumD)
        {
            Gost gost = db.Gosts.Find(gostId);
            if (gost is null)
            {
                return NotFound();
            }
            
            DateTime datumOd = DateTime.ParseExact(datumO, "d-M-yyyy", CultureInfo.InvariantCulture);
            DateTime datumDo = DateTime.ParseExact(datumD, "d-M-yyyy", CultureInfo.InvariantCulture);

            if (datumOd < DateTime.Now)
            {
                return BadRequest("bad date");
            }

            var rezervacije = db.Rezervacijas.Where(r => (datumOd > r.DatumOd && datumOd < r.DatumDo) || (datumOd > r.DatumOdDolaska && datumOd < r.DatumDoDolaska)
                                                      || (datumDo > r.DatumOd && datumDo < r.DatumDo) || (datumDo > r.DatumOdDolaska && datumDo < r.DatumDoDolaska));

            var sID = rezervacije.Select(r => r.SobaID).ToList();
            var sobas = db.Sobas.Where(s => !sID.Contains(s.ID)).ToList();

            SobaRezervacijaDto sobaRezervacijaDto = new SobaRezervacijaDto()
            {
                SlobodneSobas = Mapper.Map<List<Soba>, List<SobaDto>>(sobas),
                Rezervacija = new RezervacijaDto()
                {
                    DatumOd = datumOd,
                    DatumDo = datumDo,
                    GostID = gostId,
                    DatumOdDolaska = new DateTime(1900, 1, 1),
                    DatumDoDolaska = new DateTime(1900, 1, 1)
                }
            };

                                                  
            return Ok(sobaRezervacijaDto);
        }
    }
}