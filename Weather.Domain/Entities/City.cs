using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Entities
{
    public class City
    {
        public Coord coord { get; set; }
        public int Dt { get; set; }

        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

    }
}
