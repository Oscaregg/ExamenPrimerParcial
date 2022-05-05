using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.AppCore.Interfaces;
using Weather.Domain.Interfaces;

namespace Weather.AppCore.OpenWeatherServices
{
    public abstract class BasesServices<g> : IServices<g>
    {
        private IModel<g> model;

        protected BasesServices(IModel<g> model)
        {
            this.model = model;
        }

        public void Add(g g)
        {
            model.Add(g);
        }

        public List<g> Read()
        {
           return model.Read();
        }
    }
}
