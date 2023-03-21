using Examen2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Examen2.ViewModel
{
    internal class ViewModelMainAdmin : INotifyPropertyChanged
    {
        public ViewModelMainAdmin()
        {
            Lista_Series = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewSeries());

            });
            Lista_Peliculas = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewPeliculas());

            });

            Lista_Juegos = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewJuegos());

            });

            Lista_Suscripciones = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewSuscripciones());

            });

            CrearSeriesAdmin = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearSerie());

            });

            CrearPeliculasAdmin = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearPelicula());

            });

            CrearJuegosAdmin = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearJuego());

            });

            CrearSuscripcionAdmin = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearSuscripciones());
                  
            });

            CrearSerieSuscripcion = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearSerieSuscripcion());

            });

            CrearPeliculaSuscripcion = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearPeliculaSuscripcion());

            });

            CrearJuegoSuscripcion = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewCrearJuegoSuscripcion());

            });

        }
        public Command Lista_Series { get; set; }
        public Command Lista_Peliculas { get; set; }
        public Command Lista_Juegos { get; set; }
        public Command Lista_Suscripciones { get; set; }
        public Command CrearSeriesAdmin { get; set; }
        public Command CrearPeliculasAdmin { get; set; }
        public Command CrearJuegosAdmin { get; set; }
        public Command CrearSuscripcionAdmin { get; set; }
        public Command CrearSerieSuscripcion { get; set; }
        public Command CrearJuegoSuscripcion { get; set; }
        public Command CrearPeliculaSuscripcion { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;

    }
}

