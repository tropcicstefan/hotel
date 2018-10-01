using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class RezervacijaDto
    {
        public int ID { get; set; }
        public int GostID { get; set; }
        public int SobaID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumOd { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumDo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumOdDolaska { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumDoDolaska { get; set; }
        public int Popust { get; set; }
    }
}