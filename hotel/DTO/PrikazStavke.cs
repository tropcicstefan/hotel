using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class PrikazStavke
    {
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public int JedinicnaCijena { get; set; }
    }
}