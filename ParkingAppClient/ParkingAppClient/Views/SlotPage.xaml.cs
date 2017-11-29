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
	public partial class SlotPage : ContentPage
	{
        public SlotsView slotsView;
        readonly Label label, topLabel;

        public SlotPage (SlotsView slotsView)
		{
			//InitializeComponent ();
            System.Diagnostics.Debug.WriteLine("sots data" + slotsView.PlaceName);
        //}
        
            this.slotsView = slotsView;

            Button button = new Button()
            {
                BackgroundColor =  Color.Gray,
                TextColor = Color.White,
                Text = "Update",
                BorderRadius = 0,
            };

            topLabel = new Label
            {
                Text = slotsView.PlaceName,
                TextColor = Color.Black,
                FontSize = 50,
                HeightRequest = 70,
                BackgroundColor = Color.Gray
            };
            Button myButton1 = new Button { Text = "-", FontSize = 50 };
            label = new Label
            {
                Text = slotsView.FreeSlots.ToString(),
                FontSize = 50,
                WidthRequest = 150,
                HeightRequest = 50,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Gray
            };
            Button myButton2 = new Button { Text = "+", FontSize = 50 };

            StackLayout myStackLayout = new StackLayout
            {
                Children = {
                    myButton1,
                    label,
                    myButton2
            },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 100,
            };

            //button.Clicked += OnDismiss;
            button.Clicked += OnUpdateButtonClicked;
            myButton1.Clicked += MyButton1Clicked;
            myButton2.Clicked += MyButton2Clicked;

            void MyButton2Clicked(object sender, EventArgs e)
            {
                label.Text = (Int32.Parse(label.Text) + 1).ToString();
            }

            void MyButton1Clicked(object sender, EventArgs e)
            {
                label.Text = (Int32.Parse(label.Text) - 1).ToString();
            }

            Content = new StackLayout
            {

                Spacing = 10,
                //Children = { tableView, button },
                Children = { topLabel, myStackLayout, button },
            };

        }

        async void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            this.IsBusy = true;

            try
            {
                Slot slot = new Slot();
                slot.PlaceId = slotsView.PlaceId;
                slot.FreeSlots = Int32.Parse(label.Text);

                slotsView.FreeSlots = Int32.Parse(label.Text);
                SlotApiServices service = new SlotApiServices();
                await service.PutSlotAsync(Settings.AccessToken, slot, slotsView.Id.ToString());
                await Navigation.PopAsync();
            }
            catch (Exception ee)
            {
                System.Diagnostics.Debug.WriteLine("exce = " + ee.Message);
            }
            finally
            {
                this.IsBusy = false;
            }

        }
    }
}