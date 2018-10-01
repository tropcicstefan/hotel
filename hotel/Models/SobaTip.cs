using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class SobaTip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }

        public virtual ICollection<Soba> Sobas { get; set; }
    }
}