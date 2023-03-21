using Examen2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Examen2.ViewModel
{
    internal class ViewModelCrearJuegoSuscripcion
    {
        public ViewModelCrearJuegoSuscripcion()
        {
            CrearSuscripcionJuego = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    JuegoSuscripcion body1 = new JuegoSuscripcion()
                    {
                        id_juego = Convert.ToInt32(this.idjuego),
                        id_suscripcion = Convert.ToInt32(this.idsuscripcion),
                    };

                    //Esto nos srive para poder convertir los datos en objeto JSON
                    var myConten = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myConten, UnicodeEncoding.UTF8, "application/json");
                    var respuesta = await httpClient.PostAsync(url, stringContent);

                }

            });

        }

        //Aqui esta la URL
        string url = "https://desfrlopez.me/dduarte/api/suscripcionjuego/";

        string idjuego;
        public string IdJuego
        {
            get => idjuego;
            set
            {
                idjuego = value;
                var args = new PropertyChangedEventArgs(nameof(IdJuego));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string idsuscripcion;
        public string Idsuscripcion
        {
            get => idsuscripcion;
            set
            {
                idsuscripcion = value;
                var args = new PropertyChangedEventArgs(nameof(Idsuscripcion));
                PropertyChanged?.Invoke(this, args);
            }
        }


        public Command CrearSuscripcionJuego { get; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
