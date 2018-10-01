using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class Rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        public virtual Gost Gost { get; set; }
        public virtual Soba Soba { get; set; }
        public virtual IzdaniRacun IzdaniRacun { get; set; }
        public virtual ICollection<PrivremeniRacun> PrivremeniRacuns { get; set; }


    }
}