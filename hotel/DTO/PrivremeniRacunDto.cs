using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class PrivremeniRacunDto
    {
        public int ID { get; set; }
        public int RezervacijaID { get; set; }
        public bool Placeno { get; set; }
    }
}