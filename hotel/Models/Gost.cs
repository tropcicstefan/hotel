using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class Gost
    {
        [Required]        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "OIB")]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Ime { get; set; }
        [Required]
        [StringLength(255)]
        public string Prezime { get; set; }

        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}