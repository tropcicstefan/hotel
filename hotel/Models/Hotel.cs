using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class Hotel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
        [Required]
        [StringLength(255)]
        public string Adresa { get; set; }

        public virtual ICollection<Soba> Sobas { get; set; }

    }
}