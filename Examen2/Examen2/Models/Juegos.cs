using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class Juegos
    {
        public int id_juego { get; set; }
        public string nombre_juego { get; set; }
        public string desarrollador_juego { get; set; }
        public string distribuirdor_juego { get; set; }
        public string genero_juego { get; set; }
        public string imagen { get; set; }

        internal string toJson()
        {
            return "{ \"nombre_juego\": \" " + nombre_juego + "\", \"desarrollador_juego\": \" " + desarrollador_juego + "\", " +
                     "\"distribuirdor_juego\": \" " + distribuirdor_juego + "\", \"genero_juego\": \" " + genero_juego + "\"," +
                     " \"imagen\": \" " + imagen + "\" }";
        }

    }
}
