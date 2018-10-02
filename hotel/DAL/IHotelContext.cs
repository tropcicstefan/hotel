using hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DAL
{
    public interface IHotelContext : IDisposable
    {
        //DbSet<Gost> Gosts { get; }
        //DbSet<Rezervacija> Rezervacijas { get;  }
        //DbSet<Hotel> Hotels { get;  }
        DbSet<Soba> Sobas { get; }
        //DbSet<SobaTip> SobaTips { get;  }
        //DbSet<IzdaniRacun> IzdaniRacuns { get; }
        //DbSet<PrivremeniRacun> PrivremeniRacuns { get; }
        //DbSet<Stavke> Stavkes { get; }
        //DbSet<ElementPonude> ElementPonudes { get; }


        void MarkAsModified(Soba item);
        int SaveChanges();
    }
}
