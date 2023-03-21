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
    internal class ViewModelCrearSuscripcion : INotifyPropertyChanged
    {
        public ViewModelCrearSuscripcion()
        {
            CrearSuscripcion = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    Suscripciones body1 = new Suscripciones()
                    {
                        nombre_suscripcion = this.nombre,
                        precio_suscripcion = this.precio,
                        imagen= this.imagen
                    };

                    //Esto nos srive para poder convertir los datos en objeto JSON
                    var myConten = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myConten, UnicodeEncoding.UTF8, "application/json");
                    var respuesta = await httpClient.PostAsync(url, stringContent);

                }

            });
        }

        //Aqui esta la URL
        string url = "https://desfrlopez.me/dduarte/api/suscripcion/";


        //Aqui definimos los cambios que impactaran en el nombre de la Pelicula
        string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en el nombre del director de la Pelicula
        string precio;
        public string Precio
        {
            get => precio;
            set
            {
                precio = value;
                var args = new PropertyChangedEventArgs(nameof(Precio));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string imagen;
        public string Imagen
        {
            get => imagen;
            set
            {
                imagen = value;
                var args = new PropertyChangedEventArgs(nameof(Imagen));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public Command CrearSuscripcion { get; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
