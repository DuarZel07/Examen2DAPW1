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
    internal class ViewModelCrearSerieSuscripcion : INotifyPropertyChanged
    {
        public ViewModelCrearSerieSuscripcion()
        {
            CrearSuscripcionSerie = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    SerieSuscripcion body1 = new SerieSuscripcion()
                    {
                        id_serie = Convert.ToInt32(this.idserie),
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
        string url = "https://desfrlopez.me/dduarte/api/suscripcionserie/";

        string idserie;
        public string Idserie
        {
            get => idserie;
            set
            {
                idserie = value;
                var args = new PropertyChangedEventArgs(nameof(Idserie));
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


        public Command CrearSuscripcionSerie { get; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}

