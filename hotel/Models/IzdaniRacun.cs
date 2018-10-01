using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class IzdaniRacun
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Rezervacija")]
        public int ID { get; set; }        
        public DateTime Datum { get; set; }

        public virtual Rezervacija Rezervacija { get; set; }
    }
}