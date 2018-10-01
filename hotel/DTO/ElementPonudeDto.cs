using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class ElementPonudeDto
    {
        [Required]
        public int JedinicnaCijena { get; set; }
        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
    }
}