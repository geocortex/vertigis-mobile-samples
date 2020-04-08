using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Custom.GeocortexMobileElements;
using Geocortex.Mobile.Composition.Layout;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(GeocortexMobileElementsComponent), "geocortex-mobile-elements-xaml", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Custom.GeocortexMobileElements
{
    internal class GeocortexMobileElementsXamlComponent : ComponentBase
    {
        private GeocortexMobileElementsXamlView _view;

        public GeocortexMobileElementsXamlComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            _view = new GeocortexMobileElementsXamlView();
            return _view;
        }
    }
}
