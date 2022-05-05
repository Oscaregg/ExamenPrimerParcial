using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.AppCore.Interfaces;
using Weather.Domain.Entities;
using Weather.Domain.Interfaces;

namespace Weather.AppCore.OpenWeatherServices
{
    public class ServiceOpenWeather : BasesServices<OpenWeather>, IOpenWeatherService

    {

        IOpenWeatherModel1 iopwm;
        public ServiceOpenWeather(IOpenWeatherModel1 model) : base(model)
        {
            this.iopwm = model;
        }

    }
}
