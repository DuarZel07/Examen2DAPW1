using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    internal class Registro
    {
        public int id_usuario { get; set; } 
        public string nombre_usuario { get; set; }
        public string suscripciones_usuario { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public Boolean activo { get; set; }
        public int id_rol { get; set; }

        internal string toJson()
        {
            return "{ \"nombre_usuario\": \" " + nombre_usuario + "\", \"suscripciones_usuario\": \" " + suscripciones_usuario + "\", " +
                     "\"email\": \" " + email + "\", \"pass\": \" " + pass +
                     "\", \"activo\": \" " + activo + "\", \"id_rol\": \" " + id_rol + "\" }";
        }


    }
}
