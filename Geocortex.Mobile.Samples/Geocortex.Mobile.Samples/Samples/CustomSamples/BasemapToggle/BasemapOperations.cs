using Esri.ArcGISRuntime.Xamarin.Forms;
using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.BasemapToggle;

[assembly: Export(typeof(BasemapOperations), SingleInstance = true)]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.BasemapToggle
{
    public class BasemapOperations
    {
        private readonly IOperationRegistry _operationRegistry;

        public IOperation<BasemapToggleCommandArgs, object> ToggleDisplay
        {
            get
            {
                return _operationRegistry.Operation<BasemapToggleCommandArgs, object>("basemap.toggle-display");
            }
        }

        public IOperation<BasemapToggleCommandArgs, object> ToggleBasemap
        {
            get
            {
                return _operationRegistry.Operation<BasemapToggleCommandArgs, object>("basemap.switch");
            }
        }

        public BasemapOperations(IOperationRegistry operationRegistry)
        {
            _operationRegistry = operationRegistry;
        }
    }

    public class BasemapToggleCommandArgs
    {
        public MapView Map { get; private set; }

        public bool ToggleOn { get; private set; }

        public BasemapToggleCommandArgs(MapView mapView, bool toggleOn)
        {
            Map = mapView;
            ToggleOn = toggleOn;
        }
    }
}
