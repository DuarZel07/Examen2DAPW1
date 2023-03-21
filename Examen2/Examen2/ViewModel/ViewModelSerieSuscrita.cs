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
    internal class ViewModelSerieSuscrita : INotifyPropertyChanged
    {
        public ViewModelSerieSuscrita()
        {
            ObetenerSerieSuscripcion();
        }


        private async void ObetenerSerieSuscripcion()
        {
            //Aqui se inicializa la lista de series
            ListSerieSuscripcion = new ObservableCollection<SerieSuscripcion>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<SerieSuscripcion>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListSerieSuscripcion.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo

        ObservableCollection<SerieSuscripcion> listseriesuscripcion = new ObservableCollection<SerieSuscripcion>();
        public ObservableCollection<SerieSuscripcion> ListSerieSuscripcion
        {
            get => listseriesuscripcion;
            set
            {
                listseriesuscripcion = value;
                var args = new PropertyChangedEventArgs(nameof(ListSerieSuscripcion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string url = "https://desfrlopez.me/dduarte/api/suscripcionserie/";


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
