using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.ViewModels
{
    public class PrivremeniRacunViewModel
    {
        public IEnumerable<Stavke> Stavkes { get; set; }

        public IEnumerable<ElementPonude> ElementPonudes { get; set; }

        public Stavke Stavka { get; set; }
      
    }
}