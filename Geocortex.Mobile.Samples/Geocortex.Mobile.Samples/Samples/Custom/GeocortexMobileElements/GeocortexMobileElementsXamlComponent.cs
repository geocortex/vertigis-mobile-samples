using VertiGIS.Mobile.Samples;
using VertiGIS.Mobile.Samples.Samples.Custom.GeocortexMobileElements;
using VertiGIS.Mobile.Composition.Layout;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(GeocortexMobileElementsComponent), "geocortex-mobile-elements-xaml", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace VertiGIS.Mobile.Samples.Samples.Custom.GeocortexMobileElements
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
