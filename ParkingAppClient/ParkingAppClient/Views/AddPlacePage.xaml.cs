using ParkingAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkingAppClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlacePage : ContentPage
    {
        Place place = new Place();
        public AddPlacePage()
        {
            InitializeComponent();
            this.Appearing += AfterAddLocation;
        }

        private void AddLocation(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("sots data" + max.Text );
            Navigation.PushAsync(new LocationPage(place));
            //latude.Text = place.Latitude.ToString();
            //lotude.Text = place.Longitude.ToString();

        }

        private void AfterAddLocation(object sender, EventArgs e)
        {
            latude.Text = place.Latitude.ToString();
            lotude.Text = place.Longitude.ToString();
        }

        private void PoppingBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}