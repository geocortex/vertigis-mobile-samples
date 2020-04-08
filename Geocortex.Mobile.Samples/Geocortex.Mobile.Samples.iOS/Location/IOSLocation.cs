using System;
using CoreLocation;
using Geocortex.Mobile.Samples.Location;
using Geocortex.Mobile.Samples.iOS.Location;

/* NOTE: This sample component is for demonstrative purposes only.
 * This is not the recommended pattern for accessing location in a Geocortex Mobile application.
 * This component is used to demonstrate platform specific implementations and api/method calls. */
[assembly: Xamarin.Forms.Dependency(typeof(IOSLocation))]
namespace Geocortex.Mobile.Samples.iOS.Location
{
    public class IOSLocation : ILocation
    {
        private CLLocationManager _locationManager;

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
            _locationManager = new CLLocationManager
            {
                DesiredAccuracy = CLLocation.AccuracyBest,
                DistanceFilter = CLLocationDistance.FilterNone
            };

            _locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
            {
                var locations = e.Locations;
                var strLocation = locations[locations.Length - 1].Coordinate.Latitude.ToString();
                strLocation = strLocation + "," + locations[locations.Length - 1].Coordinate.Longitude.ToString();

                LocationEventArgs args = new LocationEventArgs
                {
                    Latitude = locations[locations.Length - 1].Coordinate.Latitude,
                    Longitude = locations[locations.Length - 1].Coordinate.Longitude
                };

                LocationObtained(this, args);
            };

            _locationManager.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) =>
            {
                if (e.Status == CLAuthorizationStatus.AuthorizedWhenInUse)
                {
                    _locationManager.StartUpdatingLocation();
                }
            };

            _locationManager.RequestWhenInUseAuthorization();
        }

        // Unsubscribe
        ~IOSLocation()
        {
            _locationManager.StopUpdatingLocation();
        }

        public class LocationEventArgs : EventArgs, ILocationEventArgs
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
