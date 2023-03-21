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
    internal class ViewModelJuegos : INotifyPropertyChanged
    {

        public ViewModelJuegos()
        {
            ObetenerJuegos();
        }


        private async void ObetenerJuegos()
        {
            //Aqui se inicializa la lista de series
            ListJuegos = new ObservableCollection<Juegos>();

            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listadoS = System.Text.Json.JsonSerializer.Deserialize<List<Juegos>>(contenido, opciones);

                foreach (var item in listadoS)
                {
                    ListJuegos.Add(item);
                }

            }

        }

        //Esto es equivalente e a un arreglo

        ObservableCollection<Juegos> listJuegos = new ObservableCollection<Juegos>();
        public ObservableCollection<Juegos> ListJuegos
        {
            get => listJuegos;
            set
            {
                listJuegos = value;
                var args = new PropertyChangedEventArgs(nameof(ListJuegos));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string url = "https://desfrlopez.me/dduarte/api/juegos/";


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
