using hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace hotel.DAL
{
    public class HotelContext : DbContext, IHotelContext
    {
        public HotelContext() : base("HotelDB")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Gost> Gosts { get; set; }
        public DbSet<Rezervacija> Rezervacijas { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Soba> Sobas { get; set; }
        public DbSet<SobaTip> SobaTips { get; set; }
        public DbSet<IzdaniRacun> IzdaniRacuns { get; set; }
        public DbSet<PrivremeniRacun> PrivremeniRacuns { get; set; }
        public DbSet<Stavke> Stavkes { get; set; }
        public DbSet<ElementPonude> ElementPonudes { get; set; }

        //imena tablica su bez s
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void MarkAsModified(Soba item)
        {
            Entry(item).State = EntityState.Modified;
        }



    }
}