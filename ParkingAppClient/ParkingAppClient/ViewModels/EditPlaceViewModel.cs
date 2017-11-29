using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppClient.ViewModels
{
    class EditPlaceViewModel
    {
        public string PlaceName { get; set; }

        public string Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string MaxSlots { get; set; }

        public string Message { get; set; }

        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            var place = new Place
        //            {
        //                PlaceName = this.PlaceName,
        //                Address = this.Address,
        //                Longitude = this.Longitude,
        //                Latitude = this.Latitude,
        //                MaxSlots = Int32.Parse(this.MaxSlots),
        //            };

        //            var isSuccess = await services.PostPlaceAsync(Settings.AccessToken, place);

        //            if (isSuccess)
        //            {
        //                Message = "Added Successfully";
        //            }
        //            else
        //            {
        //                Message = "Ploblem occured when adding place";
        //            }
        //        });
        //    }
        //}
    }
}
