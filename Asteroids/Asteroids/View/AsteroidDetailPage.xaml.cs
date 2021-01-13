using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asteroids.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsteroidDetailPage : ContentPage
    {
        public AsteroidDetailPage()
        {
            InitializeComponent();
        }

        public AsteroidDetailPage(Asteroid a)
        {
            InitializeComponent();


            Name.Text = a.Name;
            Id.Text = a.Id;
            Estimated_diameter_M.Text = a.Estimated_diameter_M;
            Hazardous.Text = a.Hazardous;
            Close_approach_date.Text = a.Close_approach_date;
            Relative_velocity_KmPs.Text = a.Relative_velocity_KmPs;
            Miss_distance_Km.Text = a.Miss_distance_Km;
            Orbiting_body.Text = a.Orbiting_body;
            First_observation_date.Text = a.First_observation_date;
            Last_observation_date.Text = a.Last_observation_date;
            Sentry_object.Text = a.Sentry_object;

        }
    }
}