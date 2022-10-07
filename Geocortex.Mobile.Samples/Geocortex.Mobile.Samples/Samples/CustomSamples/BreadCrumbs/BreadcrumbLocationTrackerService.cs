using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.Xamarin.Forms;
using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Composition.Services;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.Breadcrumbs;
using System;
using System.Threading.Tasks;

[assembly: Service(typeof(BreadcrumbLocationTrackerService), PropertiesAutowired = true)]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.Breadcrumbs
{
    internal class BreadcrumbLocationTrackerService : ServiceBase
    {
        public BreadcrumbLocationTrackerOperations BreadcrumbLocationTrackerOperations { get; set; }

        private MapView _mapView;
        private bool _isToggled;

        private GraphicsOverlay _locationHistoryOverlay;
        private SimpleMarkerSymbol _locationPointSymbol;
        private FakeLocationDataSource _fakeLocationDataSource;
        private MapPoint _lastPosition;

        protected override Task DoInitialize()
        {
            this.BreadcrumbLocationTrackerOperations.ToggleDisplay.RegisterExecute(
                (args) =>
                {
                    _mapView = args.MapView;
                    _isToggled = args.IsToggled;

                    if (_isToggled)
                    {
                        // Create and add graphics overlay for showing breadcrumbs
                        _locationHistoryOverlay = new GraphicsOverlay();
                        _locationPointSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, System.Drawing.Color.Blue, 12);
                        _locationHistoryOverlay.Renderer = new SimpleRenderer(_locationPointSymbol);
                        _mapView.GraphicsOverlays.Add(_locationHistoryOverlay);

                        //LocationTrackingBreadcrumbs();
                        FakeLocationTrackingBreadcrumbs();
                    }
                    else
                    {
                        // Remove the old graphics overlay
                        _locationHistoryOverlay.Graphics.Clear();
                        _mapView.GraphicsOverlays.Remove(_locationHistoryOverlay);
                    }

                    return Task.FromResult((object)null);
                }, this);

            return Task.CompletedTask;
        }

        public void LocationTrackingBreadcrumbs()
        {
            try
            {
                _mapView.LocationDisplay.DataSource.LocationChanged -= LocationDataSourceOnLocationChanged;
                _mapView.LocationDisplay.DataSource.LocationChanged += LocationDataSourceOnLocationChanged;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                // Add error handling here
            }
        }

        public async void FakeLocationTrackingBreadcrumbs()
        {
            if (_fakeLocationDataSource != null)
            {
                await _fakeLocationDataSource.StopAsync();
                _fakeLocationDataSource.LocationChanged -= LocationDataSourceOnLocationChanged;
            }

            // Create the location data source
            _fakeLocationDataSource = new FakeLocationDataSource();

            try
            {
                // Start the data source.
                await _fakeLocationDataSource.StartAsync();

                if (_fakeLocationDataSource.Status == Esri.ArcGISRuntime.Location.LocationDataSourceStatus.Started)
                {
                    // Set the location display data source and enable location display.
                    _mapView.LocationDisplay.DataSource = _fakeLocationDataSource;
                    _mapView.LocationDisplay.IsEnabled = true;
                    _mapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;
                    _mapView.LocationDisplay.InitialZoomScale = 10000;

                    _fakeLocationDataSource.LocationChanged += LocationDataSourceOnLocationChanged;
                }
                else
                {
                    // Add error handling here
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                // Add error handling here
            }
        }

        private void LocationDataSourceOnLocationChanged(object sender, Esri.ArcGISRuntime.Location.Location e)
        {
            // Add any previous position to the history
            if (_lastPosition != null)
            {
                try
                {
                    _locationHistoryOverlay.Graphics.Add(new Graphic(_lastPosition));
                }
                catch
                {
                    _fakeLocationDataSource.LocationChanged -= LocationDataSourceOnLocationChanged;
                }
            }

            // Store the current position
            _lastPosition = e.Position;
        }
    }
}
