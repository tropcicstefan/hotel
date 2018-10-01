using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class PrivremeniRacun
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int RezervacijaID { get; set; }
        public bool Placeno { get; set; }

        public virtual Rezervacija Rezervacija { get; set; }
        public virtual ICollection<Stavke> Stavkes { get; set; }
    }
}