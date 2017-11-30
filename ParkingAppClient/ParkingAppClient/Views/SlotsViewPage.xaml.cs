using ParkingAppClient.Helpers;
using ParkingAppClient.Models;
using ParkingAppClient.Services;
using ParkingAppClient.ViewModels;
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
	public partial class SlotsViewPage : ContentPage
	{
        public List<SlotsView> SlotsViews;

        public SlotsViewPage ()
		{
            InitializeComponent ();
            //this.Appearing += RefreshingFullPage;
        }

        public void RefreshingFullPage(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private async void OnEditSlots(object sender, ItemTappedEventArgs e)
        {
            var dataItem = e.Item as SlotsView;
            await Navigation.PushAsync(new SlotPage(dataItem));
        }

        private async void AddNewPlace(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPlacePage());
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            SlotsView slot = item.CommandParameter as SlotsView;
            if (slot != null)
            {
                if (await this.DisplayAlert("Delete Place?",
                    "Are you sure you want to delete the Place '"
                        + slot.PlaceName + "'?", "Yes", "Cancel") == true)
                {
                    PlacesApiServices service = new PlacesApiServices();
                    await service.DeletePlaceAsync(Settings.AccessToken, slot.PlaceId.ToString());
                    MyPageName.IsPullToRefreshEnabled = true;
                }
            }
        }

        async void Edit_Place(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            SlotsView slotView = item.CommandParameter as SlotsView;
            PlacesApiServices service = new PlacesApiServices();
            Place place = await service.GetPlaceByIdAsync(Settings.AccessToken, Int32.Parse(slotView.PlaceId.ToString()));
            await Navigation.PushAsync(new EditPlacePage(place));
        }
    }
}