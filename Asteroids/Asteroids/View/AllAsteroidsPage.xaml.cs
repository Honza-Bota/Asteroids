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
using System.Threading;

namespace Asteroids.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllAsteroidsPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DataControl dataControl;

        List<Asteroid> _asteroids;
        private string _lastUpdate;
        public string LastUpdate 
        { 
            get { return _lastUpdate; } 
            set 
            {
                _lastUpdate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastUpdate"));
            }
        }
        public List<Asteroid> Asteroids 
        { 
            get => _asteroids;
            set
            {
                _asteroids = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Asteroids"));
            }
        }


        public AllAsteroidsPage()
        {            
            InitializeComponent();
            dataControl = new DataControl();

            Asteroids = dataControl.GetAllAsteroids(out _lastUpdate);

            lwAsteroids.ItemsSource = Asteroids;
            BindingContext = this;

            UpdateData();
        }


        void UpdateData()
        {
            string lastUpdate = "";
            Device.StartTimer(TimeSpan.FromMinutes(2), () =>
            {
                Task.Run(() =>
                {
                    Asteroids = dataControl.Update(out lastUpdate);
                    LastUpdate = lastUpdate;
                });
                return true;
            });
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(TimeSpan.FromMinutes(2));
            //
            //        Asteroids = dataControl.Update(out lastUpdate);
            //        LastUpdate = lastUpdate;
            //    }
            //});
            
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
