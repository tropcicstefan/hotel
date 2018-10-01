using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.ViewModels
{
    public class RezervacijaViewModel
    {
        public Gost Gost { get; set; }
        public IEnumerable<Gost> Gosts { get; set; }
    }
}