using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class Series
    {
        public int id_serie { get; set; }
        public string nombre_serie { get; set; }
        public string director_serie { get; set; }
        public string distribuidor_serie { get; set; }
        public string Genero_serie { get; set; }
        public string temporadas_serie { get; set; }
        public string capitulos_serie { get; set; }
        public string duracion { get; set; }
        public string imagen { get; set; }


        internal string toJson()
        {
            return "{ \"nombre_serie\": \" " + nombre_serie + "\", \"director_serie\": \" " + director_serie + "\", " +
                     "\"distribuidor_serie\": \" " + distribuidor_serie + "\", \"Genero_serie\": \" " + Genero_serie +
                     "\", \"temporadas_serie\": \" " + temporadas_serie + "\", \"capitulos_serie\": \" " + capitulos_serie +
                     "\", \"duracion\": \" " + duracion + "\", \"imagen\": \" " + imagen + "\"  }";
        }
    }
}
