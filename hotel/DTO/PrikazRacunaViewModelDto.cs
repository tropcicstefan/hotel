using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class PrikazRacunaViewModelDto
    {
        public RezervacijaDto Rezervacija { get; set; }
        public List<PrikazStavke> Stavkes { get; set; }
    }
}