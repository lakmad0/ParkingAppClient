using ParkingAppClient.Helpers;
using ParkingAppClient.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
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
            Debug.WriteLine("your app is sleeping");
            Settings.AccessToken = null;
        }

        protected override void OnResume()
        {
            Debug.WriteLine("your app is resuming");
            // Handle when your app resumes
        }
    }
}
