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
    internal class ViewModelCrearSerie : INotifyPropertyChanged
    {
        public ViewModelCrearSerie()
        {
            CrearSerie = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    Series body1 = new Series()
                    {
                        nombre_serie = this.nombre,
                        director_serie = this.director,
                        distribuidor_serie = this.distribuidor,
                        Genero_serie = this.genero,
                        temporadas_serie = this.temporadas,
                        capitulos_serie = this.capitulos,
                        duracion = this.duracion,
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
        string url = "https://desfrlopez.me/dduarte/api/series/";


        //Aqui definimos los cambios que impactaran en el nombre de la serie
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

        //Aqui definimos los cambios que impactaran en el nombre del director de la serie
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

        //Aqui definimos los cambios que impactaran en el nombre la distribuidora de la serie
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

        //Aqui definimos los cambios que impactaran en el genero de la serie

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

        //Aqui definimos los cambios que impactaran en el numero de temporadas de la serie

        string temporadas;
        public string Temporadas
        {
            get => temporadas;
            set
            {
                temporadas = value;
                var args = new PropertyChangedEventArgs(nameof(Temporadas));
                PropertyChanged?.Invoke(this, args);
            }
        }


        //Aqui definimos los cambios que impactaran en el numero de capitulos de la serie

        string capitulos;
        public string Capitulos
        {
            get => capitulos;
            set
            {
                capitulos = value;
                var args = new PropertyChangedEventArgs(nameof(Capitulos));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en el tiempo de duracion de los capitulos de la serie
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

        //Esta es para la seleccion de las series al momentos de pulsarla

        Series serieSeleccionada = new Series();
        public Series SerieSeleccionada
        {
            get => serieSeleccionada;
            set
            {
                serieSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(SerieSeleccionada));
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
        public Command CrearSerie { get; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
