using ParkingAppClient.Helpers;
using ParkingAppClient.Services;
using ParkingAppClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkingAppClient.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        LoginApiServices loginservices = new LoginApiServices();

        public INavigation Navigation;

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        private bool isRegisterSuccess;

        public bool IsRegirerSuccess
        {
            get { return isRegisterSuccess; }
            set
            {
                isRegisterSuccess = value;
                OnPropertyChanged();
            }
        }

        public RegisterViewModel()
        {
            IsRegirerSuccess = false;            
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await loginservices.RegisterAsync(Email, Password, ConfirmPassword);


                    if (isSuccess)
                    {
                        Message = "Registered Successfully";
                        IsRegirerSuccess = isSuccess;
                        Settings.Username = Email;
                        Settings.Password = Password;
                        await Navigation.PushAsync(new LoginPage(new LoginViewModel()));
                        //Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        Message = "Problem with register. Retry Later";
                    }
                }); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
