using hotel.DAL;
using hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelTest
{
    class TestHotelContext: IHotelContext
    {
        public TestHotelContext()
        {
            this.Sobas = new TestSobaDbSet();
        }

        public DbSet<Soba> Sobas { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Soba item) { }
        public void Dispose() { }
    }
}
