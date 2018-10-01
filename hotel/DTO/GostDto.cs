using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class GostDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Ime { get; set; }
        [Required]
        [StringLength(255)]
        public string Prezime { get; set; }
    }
}