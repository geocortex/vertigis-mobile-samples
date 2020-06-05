using Esri.ArcGISRuntime.Xamarin.Forms;
using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Layout;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.BasemapToggle;
using System;
using Xamarin.Forms;

[assembly: View(typeof(BasemapToggleView))]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.BasemapToggle
{
    public partial class BasemapToggleView : ContentView
    {
        private BasemapOperations _basemapOperations;
        private ILayoutModel<MapView> _mapView;
        private bool mapSwitch = true;

        public BasemapToggleView(BasemapOperations basemapOperations, ILayoutModel<MapView> mapView)
        {
            _basemapOperations = basemapOperations;
            _mapView = mapView;
            InitializeComponent();
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            bool toggleOn = e.Value;
            MapView mapView = await _mapView.ResolveAsync();
            await _basemapOperations.ToggleDisplay.ExecuteAsync(new BasemapToggleCommandArgs(mapView, toggleOn));
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            MapView mapView = await _mapView.ResolveAsync();
            mapSwitch = !mapSwitch;
            await _basemapOperations.ToggleBasemap.ExecuteAsync(new BasemapToggleCommandArgs(mapView, mapSwitch));
        }
    }
}
