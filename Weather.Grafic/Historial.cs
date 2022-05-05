using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Weather.AppCore.Interfaces;
using Weather.Domain.Entities;

namespace Weather.Grafic
{
    public partial class Historial : Form
    {
        IOpenWeatherService iopws;
        OpenWeather openWeather;

        public Historial(IOpenWeatherService iopws)
        {
            this.iopws = iopws;
            InitializeComponent();
        }

        private void flpHistorial_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Historial_Load(object sender, EventArgs e)
        {
           for(int i = 0; i < iopws.Read().Count; i++)
            {
                openWeather = iopws.Read()[i];
                UserControl1 usc1 = new UserControl1();
                usc1.lblCity.Text = openWeather.City;
                usc1.AddDetails(openWeather);
                flpHistorial.Controls.Add(usc1);
            }
        }
    }
}
