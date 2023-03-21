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
    internal class ViewModelPeliculaSuscrita : INotifyPropertyChanged
    {
        public ViewModelPeliculaSuscrita()
        {
            ObetenerPeliculaSuscripcion();
        }


        private async void ObetenerPeliculaSuscripcion()
        {
            //Aqui se inicializa la lista de series
            ListPeliculaSuscripcion = new ObservableCollection<PeliculaSuscripcion>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<PeliculaSuscripcion>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListPeliculaSuscripcion.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo

        ObservableCollection<PeliculaSuscripcion> listpeliculasuscripcion = new ObservableCollection<PeliculaSuscripcion>();
        public ObservableCollection<PeliculaSuscripcion> ListPeliculaSuscripcion
        {
            get => listpeliculasuscripcion;
            set
            {
                listpeliculasuscripcion = value;
                var args = new PropertyChangedEventArgs(nameof(ListPeliculaSuscripcion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string url = "https://desfrlopez.me/dduarte/api/suscripcionpelicula/";


        public event PropertyChangedEventHandler PropertyChanged;
    }
}

