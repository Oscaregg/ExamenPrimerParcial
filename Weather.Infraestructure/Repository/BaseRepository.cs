using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.AppCore.Property;
using Weather.Domain.Entities;
using Weather.Domain.Interfaces;
using Weather.Domain.SubModel;

namespace Weather.Infraestructure.Repository
{
    public class BaseRepository : IOpenWeatherModel1
    {
      
        public DateTime Tiempo(long g)
        {
            {
                DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
                day = day.AddSeconds(g).ToLocalTime();

                return day;
            }
        }


        public OpenWeather ExtractLink(String t)
        {

            try
            {
                using (WebClient wc = new WebClient())
                {
                    AppSettings appsetting = new AppSettings();
                    City city = new City();

                    string url1 = $"https://api.openweathermap.org/data/2.5/weather?q={t}&Appid={AppSettings.Token}";
                    var json1 = wc.DownloadString(url1);

                    city = JsonConvert.DeserializeObject<City>(json1);

                    city.Dt = city.Dt - 400000;
                    String url = $"https://api.openweathermap.org/data/2.5/onecall/timemachine?lat={city.coord.Lat}&lon={city.coord.Lon}&dt={city.Dt}&units={AppSettings.units}&lang=sp&appid={AppSettings.Token}";
                    String Json = String.Empty;
                    Json = wc.DownloadString(url);

                    OpenWeather openweather = JsonConvert.DeserializeObject<OpenWeather>(Json);

                    openweather.City = t;
                    return openweather;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private RAFcontext context;
        private int SIZE = 9000;

        public BaseRepository()
        {
            context = new RAFcontext("climaSubModel", SIZE);
        }

        public void Add(OpenWeather g)
        {
            try
            {

                OpenWeatherSubModel climaSubModel = OpenWeatherSubModel.Convert(g);
                context.Create<OpenWeatherSubModel>(climaSubModel);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<OpenWeather> Read()
        {
            List<OpenWeatherSubModel> activoSubModels = context.GetAll<OpenWeatherSubModel>();
            return activoSubModels.Count == 0 ? new List<OpenWeather>() :
                   activoSubModels.Select(x => OpenWeatherSubModel.Convert(x)).ToList();
        }
    }
}