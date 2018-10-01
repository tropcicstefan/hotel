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
    public class DatumiViewModelController : ApiController
    {
        private HotelContext db = new HotelContext();

        
        [ResponseType(typeof(DatumiViewModelDto))]
        [Route("api/DatumiViewModel/GostID/{gostId}/DatumOd/{datumOd}/DatumDo/{datumDo}")]
        public IHttpActionResult GetDatumi(int gostId, DateTime datumOd, DateTime datumDo)
        {
            Gost gost = db.Gosts.Find(gostId);
            if(gost is null)
            {
                return NotFound();
            }
            if(datumOd < DateTime.Now)
            {
                return BadRequest("bad date");
            }
            DatumiViewModelDto dvmd = new DatumiViewModelDto()
            {
                GostID = gostId,
                DatumOd = datumOd,
                DatumDo = datumDo
            };
            return Ok(dvmd);
        }

        //[ResponseType(typeof(DatumiViewModelDto))]
        //public IHttpActionResult PostDatumiViewModel(DatumiViewModelDto datumiViewDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //}



    }
}
