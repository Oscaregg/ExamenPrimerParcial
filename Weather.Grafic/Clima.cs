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
using Weather.Infraestructure.Repository;

namespace Weather.Grafic
{
    public partial class Clima : Form
    {

        BaseRepository baseRepository = new BaseRepository();
        OpenWeather clim = new OpenWeather();
        IOpenWeatherService iopws;
        public Clima(IOpenWeatherService iopws)
        {
            this.iopws = iopws;
            InitializeComponent();
        }

        private void txbCities_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clima_Load(object sender, EventArgs e)
        {

        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            try
            {
                
                clim = baseRepository.ExtractLink(txbCities.Text);
                UserControl1 usc1 = new UserControl1();
                usc1.AddDetails(clim);
                iopws.Add(clim);
                usc1.lblCity.Text = clim.City;
                flowLayoutPanel1.Controls.Add(usc1);
            }
            catch (Exception)
            {
               MessageBox.Show("No se encontró la ciudad");
                return;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            this.Hide();
            Historial hist = new Historial(iopws);
            hist.ShowDialog();
            this.Show();
        }
    }
}
