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
    class SlotsViewViewModel : INotifyPropertyChanged
    {
        SlotsViewApiServices services = new SlotsViewApiServices();

        private List<SlotsView> slotsViews;

        public SlotsViewViewModel()
        {
            GetSlotsViewsList.Execute(null);
        }

        public List<SlotsView> SlotsViews
        {
            get { return slotsViews; }
            set
            {
                slotsViews = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetSlotsViewsList
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;

                    SlotsViews = await services.GetSlotsViewsAsync(accesstoken);
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
