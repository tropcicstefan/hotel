using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelTest
{
    class TestSobaDbSet: TestDbSet<Soba>
    {
        public override Soba Find(params object[] keyValues)
        {
            return this.SingleOrDefault(soba => soba.ID == (int)keyValues.Single());
        }
    }
}
