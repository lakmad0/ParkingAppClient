using ParkingAppClient.Helpers;
using ParkingAppClient.Models;
using ParkingAppClient.Services;
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
    public partial class EditPlacePage : ContentPage
    {
        public Place place = new Place();
        public EditPlacePage(Place _place)
        {
            this.place = _place;
            this.BindingContext = place;
            InitializeComponent();
        }

        async void EditLocation(object sender, EventArgs e)
        {
        }

        async void SaveEdit(object sender, EventArgs e)
        {
            if (place != null)
            {
                if (await this.DisplayAlert("Edit Place?",
                    "Are you sure you want to Edit the Place '"
                        + place.PlaceName + "'?", "Yes", "Cancel") == true)
                {
                    PlacesApiServices service = new PlacesApiServices();
                    await service.PutPlaceAsync(Settings.AccessToken, place);
                }
            }
            await Navigation.PopAsync();
        }
    }
}