using System;

namespace VertiGIS.Mobile.Samples.Location
{
    public interface ILocation
    {
        void ObtainMyLocation();

        event EventHandler<ILocationEventArgs> LocationObtained;
    }

    public interface ILocationEventArgs
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
