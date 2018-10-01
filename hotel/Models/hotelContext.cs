using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hotel.Models
{
    public class hotelContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public hotelContext() : base("name=hotelContext")
        {
        }

        public System.Data.Entity.DbSet<hotel.Models.Gost> Gosts { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.ElementPonude> ElementPonudes { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.Soba> Sobas { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.Hotel> Hotels { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.SobaTip> SobaTips { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.IzdaniRacun> IzdaniRacuns { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.Rezervacija> Rezervacijas { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.PrivremeniRacun> PrivremeniRacuns { get; set; }

        public System.Data.Entity.DbSet<hotel.Models.Stavke> Stavkes { get; set; }
    }
}
