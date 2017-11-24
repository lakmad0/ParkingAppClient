using ParkingAppClient.Helpers;
using ParkingAppClient.Models;
using ParkingAppClient.Services;
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
    public class PlacesViewModel : INotifyPropertyChanged
    {
        PlacesApiServices services = new PlacesApiServices();

        private List<Place> places;

        public List<Place> Places
        {
            get { return places; }
            set
            {
                places = value;
                OnPropertyChanged();
            }
        }
    
        public ICommand GetPlacesList
        {
            get
            {
                return new Command(async() =>
                {
                    var accesstoken = Settings.AccessToken;

                    Places = await services.GetPlacesAsync(accesstoken);
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
