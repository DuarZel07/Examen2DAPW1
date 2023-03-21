using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class Peliculas
    {
        public int id_peliculas { get; set; }
        public string nombre_pelicula { get; set; }
        public string director_pelicula { get; set; }
        public string productora_pelicula { get; set; }
        public string distribuidor_pelicula { get; set; }
        public string genero_pelicula { get; set; }
        public string duracion_pelicula { get; set; }
        public string imagen { get; set; }


        internal string toJson()
        {
            return "{ \"nombre_pelicula\": \" " + nombre_pelicula + "\", \"director_pelicula\": \" " + director_pelicula + "\", " +
                     "\"productora_pelicula\": \" " + productora_pelicula + "\", \"distribuidor_pelicula\": \" " + distribuidor_pelicula +
                     "\", \"genero_pelicula\": \" " + genero_pelicula + "\", \"duracion_pelicula\": \" " + duracion_pelicula + "\" " +
                     "\"imagen\": \" " + imagen + "\"}";
        }

    }
}
