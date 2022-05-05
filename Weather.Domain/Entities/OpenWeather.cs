﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Entities
{

    public class OpenWeather
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
        public Current current { get; set; }
        public List<Hourly> hourly { get; set; }
        public string City { get; set; }
    }

    public class Current
    {

        public double Temp { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Clouds { get; set; }
        public double Wind_speed { get; set; }
        public int Wind_deg { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public List<Weather> weather { get; set; }
    }


    public class Hourly
    {
        public int dt { get; set; }
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double wind_speed { get; set; }
        public int wind_deg { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}

