using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class SobaRezervacijaDto
    {
        public RezervacijaDto Rezervacija { get; set; }
        public List<SobaDto> SlobodneSobas { get; set; }
        public int soba { get; set; }
    }
}