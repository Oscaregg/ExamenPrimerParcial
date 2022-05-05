using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.AppCore.Interfaces
{
    public interface IServices<g>
    {
         void Add(g g);
         List<g> Read();

    }
}
