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
    internal class ViewModelSeries : INotifyPropertyChanged
    {
        public ViewModelSeries()
        {
            ObtenerSeries();
        }
        private async void ObtenerSeries()
        {
            //Aqui se inicializa la lista de series
            ListSeries = new ObservableCollection<Series>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<Series>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListSeries.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo
        ObservableCollection<Series> listSeries = new ObservableCollection<Series>();
        public ObservableCollection<Series> ListSeries
        {
            get => listSeries;
            set
            {
                listSeries = value;
                var args = new PropertyChangedEventArgs(nameof(ListSeries));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string url = "https://desfrlopez.me/dduarte/api/series/";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
