using Asteroids.Model;
using Asteroids.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asteroids.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllAsteroidsPage : ContentPage
    {
        List<Asteroid> asteroids;
        public AllAsteroidsPage()
        {
            InitializeComponent();

            NasaDataService nasaDataService = new NasaDataService();

            asteroids = nasaDataService.GetAsteroids();

            l_asteroids.ItemsSource = asteroids;

            update.Text = DateTime.Now.ToString();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Application.Current.MainPage.Navigation.PushAsync(new AsteroidDetailPage(e.Item as Asteroid));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
