using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.ViewModels
{
    public class SobaRezervacija
    {
        public Rezervacija Rezervacija { get; set; }
        public IEnumerable<Soba> SlobodneSobas { get; set; }
        public int soba { get; set; }
    }
}

