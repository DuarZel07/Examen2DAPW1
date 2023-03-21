using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class JuegoSuscripcion
    {
        public int id_juego_suscripcion { get; set; }
        public int id_juego { get; set; }
        public int id_suscripcion { get; set; }

        internal string toJson()
        {
            return "{ \"id_juego_suscripcion\": \" " + id_juego_suscripcion + "\", \"id_juego\": \" " + id_juego + "\", " +
                     "\"id_suscripcion\": \" " + id_suscripcion + "\"}";
        }
    }
}
