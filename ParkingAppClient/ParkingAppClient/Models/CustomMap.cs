using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ParkingAppClient
{
	public class CustomMap : Map
	{
		public List<CustomPin> CustomPins { get; set; }
        public Position MarkerPosition { get; set; }

        //private static readonly BindableProperty PinPositionProperty = BindableProperty.Create<CustomMap, Position>(p => p.PinPosition, default(Position));
        
        //public Position PinPosition
        //{
        //    get
        //    {
        //        return (Position)GetValue(PinPositionProperty);
        //    }
        //    set
        //    {
        //        SetValue(PinPositionProperty, value);
        //    }
        //}
        
    }
}
