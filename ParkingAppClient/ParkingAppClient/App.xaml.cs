using ParkingAppClient.Helpers;
using ParkingAppClient.ViewModels;
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
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                var viewModel = new LoginViewModel();
                MainPage = new NavigationPage(new LoginPage(viewModel));
            }
            else if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
            {
                var viewModel = new LoginViewModel();
                MainPage = new NavigationPage(new LoginPage(viewModel));
            }
            else
            {
                var viewModel = new RegisterViewModel();
                MainPage = new NavigationPage(new RegisterPage(viewModel));
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
            //Settings.AccessToken = null;
        }

        protected override void OnResume()
        {
            Debug.WriteLine("your app is resuming");
            // Handle when your app resumes
        }
    }
}
