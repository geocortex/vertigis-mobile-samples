using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.CustomSamples.Breadcrumbs;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(BreadcrumbLocationTrackerComponent), "breadcrumb-location-tracker", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.CustomSamples.Breadcrumbs
{
    public class BreadcrumbLocationTrackerComponent : ComponentBase
    {
        private BreadcrumbLocationTrackerView _breadcrumbLocationTrackerView;

        public BreadcrumbLocationTrackerComponent(BreadcrumbLocationTrackerView breadcrumbLocationTrackerView)
        {
            this._breadcrumbLocationTrackerView = breadcrumbLocationTrackerView;
        }

        protected override VisualElement Create(XNode node)
        {
            return this._breadcrumbLocationTrackerView;
        }
    }
}
