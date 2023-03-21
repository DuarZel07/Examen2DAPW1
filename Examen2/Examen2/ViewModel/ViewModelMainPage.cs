using Examen2.Models;
using Examen2.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;

namespace Examen2.ViewModel
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        
        public ViewModelMainPage()
        {
            inicioSesion = new Command(async () =>
            {
                HttpClient cliente = new HttpClient();
                var respuesta = await cliente.GetAsync(url + this.usuario + "/" + this.pass);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    JsonSerializerOptions opciones = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    var inicioSesion = System.Text.Json.JsonSerializer.Deserialize<List<logIn>>(contenido);

                    if (inicioSesion[0].is_valid == 1 && inicioSesion[0].id_rol ==1)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewMainAdmin());
                    }
                    else if (inicioSesion[0].is_valid == 1 && inicioSesion[0].id_rol == 2)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewMainUser());
                    }
                    else
                    {
                        Resultado = "Inicio de sesion Erroneo";
                    }


                }
            });

            registroUsuario = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewRegistro());

            });

        }

        string url = "https://desfrlopez.me/dduarte/api/usuario/";

        //Esto es para el logIn de la aplicacion

        string usuario;
        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, args);
            }
        }

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

        string resultado;
        public string Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);
            }
        }

      


        public Command inicioSesion { get; }
        public Command registroUsuario { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
