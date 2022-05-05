using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Weather.AppCore.Interfaces;
using Weather.AppCore.OpenWeatherServices;
using Weather.Domain.Interfaces;
using Weather.Infraestructure.Repository;

namespace Weather.Grafic
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ContainerBuilder();
            builder.RegisterType<BaseRepository>().As<IOpenWeatherModel1>();
            builder.RegisterType<ServiceOpenWeather>().As<IOpenWeatherService>();
            var container = builder.Build();
            Application.Run(new Clima(container.Resolve<IOpenWeatherService>()));
        }
    }
}
