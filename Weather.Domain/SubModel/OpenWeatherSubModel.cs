using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;

namespace Weather.Domain.SubModel
{
    public class OpenWeatherSubModel
    {
        public int Id { get; set; }
        public string Json { get; set; }

        public static OpenWeatherSubModel Convert(OpenWeather clima)
        {
            if (clima == null)
            {
                return null;
            }

            OpenWeatherSubModel climaSubModel = new OpenWeatherSubModel();
            if (climaSubModel.Id < clima.current.weather.Count)
            {
                climaSubModel.Id = clima.current.weather.Count;
            }
            else
            {
                climaSubModel.Id = climaSubModel.Id + 1;
            }
            climaSubModel.Json = JsonConvert.SerializeObject(clima);

            return climaSubModel;
        }

        public static OpenWeather Convert(OpenWeatherSubModel climaSubModel)
        {
            if (climaSubModel == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(climaSubModel.Json))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<OpenWeather>(climaSubModel.Json);
        }
    }
}
