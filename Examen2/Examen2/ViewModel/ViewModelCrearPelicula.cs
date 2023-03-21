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
    internal class ViewModelCrearPelicula : INotifyPropertyChanged
    {
        public ViewModelCrearPelicula()
        {
            CrearPelicula = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    Peliculas body1 = new Peliculas()
                    {
                        nombre_pelicula = this.nombre,
                        director_pelicula = this.director,
                        productora_pelicula = this.productora,
                        distribuidor_pelicula = this.distribuidor,
                        genero_pelicula = this.genero,
                        duracion_pelicula = this.duracion,
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
        string url = "https://desfrlopez.me/dduarte/api/peliculas/";


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
        string director;
        public string Director
        {
            get => director;
            set
            {
                director = value;
                var args = new PropertyChangedEventArgs(nameof(Director));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en el numero de Productora de la Pelicula

        string productora;
        public string Productora
        {
            get => productora;
            set
            {
                productora = value;
                var args = new PropertyChangedEventArgs(nameof(Productora));
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


        //Aqui definimos los cambios que impactaran en el tiempo de duracion de los capitulos de la Pelicula
        string duracion;
        public string Duracion
        {
            get => duracion;
            set
            {
                duracion = value;
                var args = new PropertyChangedEventArgs(nameof(Duracion));
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

        public Command CrearPelicula { get; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
