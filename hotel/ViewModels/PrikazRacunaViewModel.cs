using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.ViewModels
{
    public class PrikazRacunaViewModel
    {
        public Rezervacija Rezervacija { get; set; }
        public IEnumerable<Stavke> Stavkes { get; set; }
    }
}