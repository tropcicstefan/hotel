using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel.Models
{
    public class Stavke
    {
        [Required]        
        public int Kolicina { get; set; }

        [Key, Column(Order = 0)]
        public int PrivremeniRacunID { get; set; }
        [Key, Column(Order = 1)]
        public int ElementPonudeID { get; set; }


        public virtual PrivremeniRacun PrivremeniRacun { get; set; }
        public virtual ElementPonude ElementPonude { get; set; }

    }
}