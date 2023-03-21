using Examen2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Examen2.ViewModel
{
    internal class ViewModelJuegoSuscrito : INotifyPropertyChanged
    {
        public ViewModelJuegoSuscrito()
        {
            ObetenerJuegoSuscripcion();
        }


        private async void ObetenerJuegoSuscripcion()
        {
            //Aqui se inicializa la lista de series
            ListJuegoSuscripcion = new ObservableCollection<JuegoSuscripcion>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<JuegoSuscripcion>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListJuegoSuscripcion.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo

        ObservableCollection<JuegoSuscripcion> listjuegosuscripcion = new ObservableCollection<JuegoSuscripcion>();
        public ObservableCollection<JuegoSuscripcion> ListJuegoSuscripcion
        {
            get => listjuegosuscripcion;
            set
            {
                listjuegosuscripcion = value;
                var args = new PropertyChangedEventArgs(nameof(ListJuegoSuscripcion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string url = "https://desfrlopez.me/dduarte/api/suscripcionjuego/";


        public event PropertyChangedEventHandler PropertyChanged;
    }

}

