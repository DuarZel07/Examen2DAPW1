using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class PeliculaSuscripcion
    {
        public int id_peliula_suscripcion { get; set; }
        public int id_peliculas { get; set; }
        public int id_suscripcion { get; set; }

        internal string toJson()
        {
            return "{ \"id_peliula_suscripcion\": \" " + id_peliula_suscripcion + "\", \"id_peliculas\": \" " + id_peliculas + "\", " +
                     "\"id_suscripcion\": \" " + id_suscripcion + "\"}";
        }
    }
}
