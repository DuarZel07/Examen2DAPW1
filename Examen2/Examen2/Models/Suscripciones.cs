using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class Suscripciones
    {
        public int id_suscripcion { get; set; }
        public string nombre_suscripcion { get; set; }
        public string precio_suscripcion { get; set; }
        public string imagen { get; set; }


        internal string toJson()
        {
            return "{ \"nombre_suscripcion\": \" " + nombre_suscripcion + "\", \"precio_suscripcion\": \" " + precio_suscripcion + "\"" +
                      "\"imagen\": \" " + imagen + "\" }";
        }
    }
}
