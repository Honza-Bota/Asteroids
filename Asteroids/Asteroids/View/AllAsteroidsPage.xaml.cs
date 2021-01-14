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
    public partial class AllAsteroidsPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<Asteroid> asteroids;
        DataControl dtc;
        private string lastUpdate1;
        public string LastUpdate 
        { 
            get { return lastUpdate1; } 
            set 
            {
                lastUpdate1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastUpdate"));
            }
        }

        public AllAsteroidsPage()
        {
            InitializeComponent();
            dtc = new DataControl();

            asteroids = dtc.GetAllAsteroids();
            lwAsteroids.ItemsSource = asteroids;
            BindingContext = this;

            LastUpdate = DateTime.Now.ToString();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Application.Current.MainPage.Navigation.PushAsync(new AsteroidDetailPage(e.Item as Asteroid));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
