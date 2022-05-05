using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Weather.Domain.Entities;
using Weather.Infraestructure.Repository;

namespace Weather.Grafic
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void AddDetails(OpenWeather opw)
        {

                BaseRepository baseRepository = new BaseRepository();
                lblTemperature.Text = "C° " + opw.current.Temp.ToString();
                lblWeather.Text = opw.current.weather[0].Main;
                pcbEstatus.ImageLocation = "https://api.openweathermap.org/img/w/" + opw.current.weather[0].Icon + ".png";

                #region detail

                UserControl2 UserControl2s0 = new UserControl2();
                UserControl2s0.lblDetail.Text = "Fecha";
                UserControl2s0.lblDetailValue.Text = baseRepository.Tiempo(opw.hourly[0].dt).ToShortDateString();
                flpContent.Controls.Add(UserControl2s0);

                UserControl2 UserControl2s15 = new UserControl2();
                UserControl2s15.lblDetail.Text = "Hora";
                UserControl2s15.lblDetailValue.Text = baseRepository.Tiempo(opw.hourly[0].dt).ToShortTimeString();
                flpContent.Controls.Add(UserControl2s15);

                UserControl2 UserControl2s1 = new UserControl2();
                UserControl2s1.lblDetail.Text = "Descripcion";
                UserControl2s1.lblDetailValue.Text = opw.hourly[0].weather[0].Description;
                flpContent.Controls.Add(UserControl2s1);

                UserControl2 UserControl2s3 = new UserControl2();
                UserControl2s3.lblDetail.Text = "Viento";
                UserControl2s3.lblDetailValue.Text = opw.hourly[0].wind_speed.ToString() + " mt/s";
                flpContent.Controls.Add(UserControl2s3);

                UserControl2 UserControl2s4 = new UserControl2();
                UserControl2s4.lblDetail.Text = "Direccion del viento";
                UserControl2s4.lblDetailValue.Text = opw.hourly[0].wind_deg.ToString() + "°";
                flpContent.Controls.Add(UserControl2s4);

                UserControl2 UserControl2s6 = new UserControl2();
                UserControl2s6.lblDetail.Text = "Amanecer";
                UserControl2s6.lblDetailValue.Text = baseRepository.Tiempo((long)opw.current.Sunrise).ToShortTimeString();
                flpContent.Controls.Add(UserControl2s6);


                UserControl2 UserControl2s7 = new UserControl2();
                UserControl2s7.lblDetail.Text = "Atardecer";
                UserControl2s7.lblDetailValue.Text = baseRepository.Tiempo((long)opw.current.Sunset).ToShortTimeString();
                flpContent.Controls.Add(UserControl2s7);

                UserControl2 UserControl2s8 = new UserControl2();
                UserControl2s8.lblDetail.Text = "Presión";
                UserControl2s8.lblDetailValue.Text = opw.hourly[0].Pressure.ToString() + "/hPa";
                flpContent.Controls.Add(UserControl2s8);

                UserControl2 UserControl2s9 = new UserControl2();
                UserControl2s9.lblDetail.Text = "Humedad";
                UserControl2s9.lblDetailValue.Text = opw.hourly[0].Humidity.ToString() + "%";
                flpContent.Controls.Add(UserControl2s9);


                UserControl2 UserControl2s10 = new UserControl2();
                UserControl2s10.lblDetail.Text = "Latitud";
                UserControl2s10.lblDetailValue.Text = opw.Lat + "°";
                flpContent.Controls.Add(UserControl2s10);

                UserControl2 UserControl2s11 = new UserControl2();
                UserControl2s11.lblDetail.Text = "Longitud";
                UserControl2s11.lblDetailValue.Text = opw.Lon + "°";
                flpContent.Controls.Add(UserControl2s11);


                #endregion
        }
        private void flpContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
