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
    internal class ViewModelCrearUsuario : INotifyPropertyChanged
    {
        public ViewModelCrearUsuario()
        {
            CrearUsuario = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    Registro body1 = new Registro()
                    {
                        nombre_usuario = this.nombre,
                        suscripciones_usuario = this.suscripcion,
                        email = this.email,
                        pass = this.pass,
                        activo = true,
                        id_rol = Convert.ToInt32(this.rol),
                    };

                    //Esto nos srive para poder convertir los datos en objeto JSON
                    var myConten = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myConten, UnicodeEncoding.UTF8, "application/json");
                    var respuesta = await httpClient.PostAsync(url, stringContent);

                }

            });

        }

        string url = "https://desfrlopez.me/dduarte/api/usuario/";


        //Aqui definimos los cambios que impactaran en el nombre de la usuario
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

        //Aqui definimos los cambios que impactaran en la suscripcion del usuario
        string suscripcion;
        public string Suscripcion
        {
            get => suscripcion;
            set
            {
                suscripcion = value;
                var args = new PropertyChangedEventArgs(nameof(Suscripcion));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en el email del usuario
        string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                var args = new PropertyChangedEventArgs(nameof(Email));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en la contrasena del usuario
        string pass;
        public string Pass
        {
            get => pass;
            set
            {
                pass = value;
                var args = new PropertyChangedEventArgs(nameof(Pass));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en la actividad del usuario
        string activo;
        public string Activo
        {
            get => activo;
            set
            {
                activo = value;
                var args = new PropertyChangedEventArgs(nameof(Activo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //Aqui definimos los cambios que impactaran en el rol del usuario
        string rol;
        public string Rol
        {
            get => rol;
            set
            {
                rol = value;
                var args = new PropertyChangedEventArgs(nameof(Rol));
                PropertyChanged?.Invoke(this, args);
            }
        }




        public Command CrearUsuario { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
