using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;

namespace Weather.Domain.Interfaces
{
    public interface IModel<g>
    {
        public OpenWeather ExtractLink(String t);
         void Add(g g);
         List<g> Read();

    }
}
