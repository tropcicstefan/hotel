using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class Soba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SobaTipID { get; set; }
        public int HotelID { get; set; }


        public virtual SobaTip SobaTip { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}