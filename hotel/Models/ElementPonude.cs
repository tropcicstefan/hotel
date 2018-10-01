using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class ElementPonude
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]        
        public int JedinicnaCijena { get; set; }
        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        public virtual ICollection<Stavke> Stavkes { get; set; }

    }
}