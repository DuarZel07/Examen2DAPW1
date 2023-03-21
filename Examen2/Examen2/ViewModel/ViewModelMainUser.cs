using Examen2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Examen2.ViewModel
{
    public class ViewModelMainUser : INotifyPropertyChanged
    {
        public ViewModelMainUser()
        {
            
            SuscripcionSerie = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewSerieSuscripcion());

            });

            SuscripcionPelicula = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewPeliculaSuscripcion());

            });

            SuscripcionJuego = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewJuegoSuscripcion());

            });


        }
        public Command SuscripcionSerie { get; set;}
        public Command SuscripcionPelicula { get; set;}
        public Command SuscripcionJuego { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
