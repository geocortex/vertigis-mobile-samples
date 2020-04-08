using Esri.ArcGISRuntime.Xamarin.Forms;
using Geocortex.Mobile.Composition;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Samples.Samples.CustomSamples.Breadcrumbs;

[assembly: Export(typeof(BreadcrumbLocationTrackerOperations), SingleInstance = true)]
namespace Geocortex.Mobile.Samples.Samples.CustomSamples.Breadcrumbs
{
    public class BreadcrumbLocationTrackerOperations
    {
        private IOperationRegistry _operationRegistry;

        public IOperation<BreadcrumbLocationTrackerOperationsCommandArgs, object> ToggleDisplay
        {
            get
            {
                return _operationRegistry.Operation<BreadcrumbLocationTrackerOperationsCommandArgs, object>("breadcrumbs.toggle-display");
            }
        }

        public BreadcrumbLocationTrackerOperations(IOperationRegistry operationRegistry)
        {
            _operationRegistry = operationRegistry;
        }
    }

    public class BreadcrumbLocationTrackerOperationsCommandArgs
    {
        public MapView MapView { get; private set; }

        public bool IsToggled { get; private set; }

        public BreadcrumbLocationTrackerOperationsCommandArgs(MapView map, bool isToggled)
        {
            MapView = map;
            IsToggled = isToggled;
        }
    }
}
