using ParkingAppClient.Helpers;
using ParkingAppClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ParkingAppClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetMainPage();
            //MainPage = new NavigationPage(new LoginPage()); 
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new NavigationPage(new PlacesPage());
            }
            else if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
