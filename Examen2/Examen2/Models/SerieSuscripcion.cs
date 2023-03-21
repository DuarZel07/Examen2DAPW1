using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class SerieSuscripcion
    {
        public int id_serie_suscripcion { get; set; }
        public int id_serie { get; set; }
        public int id_suscripcion { get; set; }

        internal string toJson()
        {
            return "{ \"id_serie_suscripcion\": \" " + id_serie_suscripcion + "\", \"id_serie\": \" " + id_serie + "\", " +
                     "\"id_suscripcion\": \" " + id_suscripcion + "\"}";
        }
    }
}
