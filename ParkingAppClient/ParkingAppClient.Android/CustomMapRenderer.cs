using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ParkingAppClient;
using ParkingAppClient.Droid;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace ParkingAppClient.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;
        public Position markerPosition;
        public CustomMap formsMap;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                this.formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                markerPosition = formsMap.MarkerPosition;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            
            NativeMap.MapLongClick += ClickingLongMap;
            NativeMap.MarkerDragEnd += AfterDraggingMarker;
            NativeMap.SetInfoWindowAdapter(this);
        }

        private void AfterDraggingMarker(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("end draggin" + e.Marker.Position.ToString());
            System.Diagnostics.Debug.WriteLine("marker Position for okay button" + markerPosition.Latitude);

            formsMap.MarkerPosition = new Position(e.Marker.Position.Latitude, e.Marker.Position.Longitude);

        }

        void ClickingLongMap(object sender, GoogleMap.MapLongClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Clicked looogly on the map");
            var marker = new MarkerOptions();
            marker.Draggable(true);
            marker.SetPosition(new LatLng(e.Point.Latitude, e.Point.Longitude));
            formsMap.MarkerPosition = new Position(marker.Position.Latitude, marker.Position.Longitude);
            System.Diagnostics.Debug.WriteLine("pin starting latitude" + e.Point.Latitude);


            NativeMap.AddMarker(marker);
        }

        void ClickingMap(object sender, GoogleMap.MapClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Clicked on the map");
            var marker = new MarkerOptions();
            marker.Draggable(true);
            marker.SetPosition(new LatLng(e.Point.Latitude, e.Point.Longitude));

            NativeMap.AddMarker(marker);

        }

        //protected override MarkerOptions CreateMarker(Pin pin)
        //{
        //    var marker = new MarkerOptions();
        //    marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
        //    marker.SetTitle(pin.Label);
        //    marker.SetSnippet(pin.Address);
        //    marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));
        //    return marker;
        //}

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                System.Diagnostics.Debug.WriteLine("Not a custom pin");
            }

            if (!string.IsNullOrWhiteSpace(customPin.Url))
            {
                System.Diagnostics.Debug.WriteLine("Showing a window detail");
                var url = Android.Net.Uri.Parse(customPin.Url);
                var intent = new Intent(Intent.ActionView, url);
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }


        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    System.Diagnostics.Debug.WriteLine("Not a pin tapped");
                    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
                    System.Diagnostics.Debug.WriteLine("Latitude is" + marker.Position.Latitude);


                    //throw new Exception("Custom pin not found");

                }

                else if (customPin.Id == "Xamarin")
                {
                    System.Diagnostics.Debug.WriteLine("Yes it is a pin for tapping");
                    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                }

                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            System.Diagnostics.Debug.WriteLine("in the getinfowindow method");
            return null;
        }

        CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }
    }
}