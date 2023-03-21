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
    internal class ViewModelPeliculas : INotifyPropertyChanged
    {
        public ViewModelPeliculas()
        {
            ObetenerPeliculas();
        }

        private async void ObetenerPeliculas()
        {
            //Aqui se inicializa la lista de series
            ListPeliculas = new ObservableCollection<Peliculas>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<Peliculas>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListPeliculas.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo

        ObservableCollection<Peliculas> listPeliculas= new ObservableCollection<Peliculas>();
        public ObservableCollection<Peliculas> ListPeliculas
        {
            get => listPeliculas;
            set
            {
                listPeliculas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPeliculas));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string url = "https://desfrlopez.me/dduarte/api/peliculas/";




        public event PropertyChangedEventHandler PropertyChanged;
    }
}
