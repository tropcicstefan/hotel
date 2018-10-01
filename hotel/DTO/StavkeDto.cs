using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class StavkeDto
    {
        [Required]
        public int Kolicina { get; set; }

        [Key, Column(Order = 0)]
        public int PrivremeniRacunID { get; set; }
        [Key, Column(Order = 1)]
        public int ElementPonudeID { get; set; }
    }
}