using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.ViewModels
{
    public class OdaberiRezervacijuViewModel
    {
        public Rezervacija Rezervacija { get; set; }
        public IEnumerable<Rezervacija> TrenutacneRezervacije { get; set; }
        public DateTime DanasnjiDatum { get; set; }
    }
}