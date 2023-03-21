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
    internal class ViewModelCrearJuego : INotifyPropertyChanged
    {
        public ViewModelCrearJuego()
        {
            CrearJuego = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    Juegos body1 = new Juegos()
                    {
                        nombre_juego = this.nombre,
                        desarrollador_juego = this.desarrollador,
                        distribuirdor_juego = this.distribuidor,
                        genero_juego = this.genero,
                        imagen = this.imagen
                    };

                    //Esto nos srive para poder convertir los datos en objeto JSON
                    var myConten = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myConten, UnicodeEncoding.UTF8, "application/json");
                    var respuesta = await httpClient.PostAsync(url, stringContent);

                }

            });

        }

        //Aqui esta la URL
        string url = "https://desfrlopez.me/dduarte/api/juegos/";


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
        string desarrollador;
        public string Desarrollador
        {
            get => desarrollador;
            set
            {
                desarrollador = value;
                var args = new PropertyChangedEventArgs(nameof(Desarrollador));
                PropertyChanged?.Invoke(this, args);
            }
        }


        //Aqui definimos los cambios que impactaran en el nombre la distribuidora de la Pelicula
        string distribuidor;
        public string Distribuidor
        {
            get => distribuidor;
            set
            {
                distribuidor = value;
                var args = new PropertyChangedEventArgs(nameof(Distribuidor));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en el genero de la Pelicula

        string genero;
        public string Genero
        {
            get => genero;
            set
            {
                genero = value;
                var args = new PropertyChangedEventArgs(nameof(Genero));
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
        
        public Command CrearJuego { get; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
