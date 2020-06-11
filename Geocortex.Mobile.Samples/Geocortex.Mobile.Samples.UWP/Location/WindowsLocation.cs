using System;
using VertiGIS.Mobile.Samples.Location;
using VertiGIS.Mobile.Samples.UWP.Location;
using Windows.Devices.Geolocation;

/* NOTE: This sample component is for demonstrative purposes only.
 * This is not the recommended pattern for accessing location in a Geocortex Mobile application.
 * This component is used to demonstrate platform specific implementations and api/method calls. */
[assembly: Xamarin.Forms.Dependency(typeof(WindowsLocation))]
namespace VertiGIS.Mobile.Samples.UWP.Location
{
    public class WindowsLocation : ILocation
    {
        private Geolocator _geolocator;

        public event EventHandler<ILocationEventArgs> LocationObtained;

        event EventHandler<ILocationEventArgs> ILocation.LocationObtained
        {
            add
            {
                LocationObtained += value;
            }

            remove
            {
                LocationObtained -= value;
            }
        }

        public void ObtainMyLocation()
        {
            _geolocator = new Geolocator { DesiredAccuracy = Windows.Devices.Geolocation.PositionAccuracy.High };

            _geolocator.PositionChanged += PositionChanged;
        }

        private void PositionChanged(object sender, PositionChangedEventArgs e)
        {
            LocationEventArgs args = new LocationEventArgs
            {
                Latitude = e.Position.Coordinate.Point.Position.Latitude,
                Longitude = e.Position.Coordinate.Point.Position.Longitude
            };

            LocationObtained(this, args);
        }

        // Unsubscribe
        ~WindowsLocation()
        {
            _geolocator.PositionChanged -= PositionChanged;
        }
    }

    public class LocationEventArgs : EventArgs, ILocationEventArgs
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
