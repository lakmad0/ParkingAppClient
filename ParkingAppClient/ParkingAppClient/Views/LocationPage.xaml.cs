using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAppClient;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using ParkingAppClient.Models;

namespace ParkingAppClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        Place place;
        public LocationPage(Place place)
        {
            this.place = place;
            InitializeComponent();
            btnGetLocation.Clicked += BtnGetLocation_Clicked;
            RetreiveLocation();
        }

        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
            await RetreiveLocation();
        }


        private async Task RetreiveLocation()
        {
            System.Diagnostics.Debug.WriteLine("Getting the geolocator for examines");
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync();

            txtLat.Text = "Latitude: " + position.Latitude.ToString();
            txtLong.Text = "Longitude: " + position.Longitude.ToString();

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude)
                             , Distance.FromMiles(1)));

        }

        private async void OkayClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("first clicking  " + customMap.MarkerPosition.Latitude);
            txtLat.Text = "Latitude: " + customMap.MarkerPosition.Latitude;
            txtLong.Text = "Longitude: " + customMap.MarkerPosition.Longitude;
            place.Latitude = (float)customMap.MarkerPosition.Latitude;
            place.Longitude = (float)customMap.MarkerPosition.Longitude;
            await Navigation.PopAsync();
        }
    }
}