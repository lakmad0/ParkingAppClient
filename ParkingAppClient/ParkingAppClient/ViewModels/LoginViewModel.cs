using ParkingAppClient.Helpers;
using ParkingAppClient.Services;
using ParkingAppClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkingAppClient.ViewModels
{
    public class LoginViewModel
    {
        LoginApiServices loginservices = new LoginApiServices();

        public INavigation Navigation;

        public string UserName { get; set; }

        public string Password { get; set; }

        public LoginViewModel()
        {
            UserName = Settings.Username;
            Password = Settings.Password;
        }


        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = await loginservices.LoginAsync(UserName, Password);
                    Settings.AccessToken = accessToken;

                    await Navigation.PushAsync(new SlotsViewPage());
                });
            }
        }
    }
}
