using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Custom.XamlComponent;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(XamlComponent), "xaml-component", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Custom.XamlComponent
{
    class XamlComponent : ComponentBase
    {
        private XamlComponentView _view;

        public XamlComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            _view = new XamlComponentView();
            return _view;
        }
    }
}
