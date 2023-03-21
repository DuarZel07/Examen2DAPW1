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
    internal class ViewModelSuscripcion : INotifyPropertyChanged
    {
        public ViewModelSuscripcion()
        {
            ObetenerSuscripcion();
        }


        private async void ObetenerSuscripcion()
        {
            //Aqui se inicializa la lista de series
            ListSuscripcion = new ObservableCollection<Suscripciones>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<Suscripciones>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListSuscripcion.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo

        ObservableCollection<Suscripciones> listSuscripcion = new ObservableCollection<Suscripciones>();
        public ObservableCollection<Suscripciones> ListSuscripcion
        {
            get => listSuscripcion;
            set
            {
                listSuscripcion = value;
                var args = new PropertyChangedEventArgs(nameof(ListSuscripcion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string url = "https://desfrlopez.me/dduarte/api/suscripcion/";


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
