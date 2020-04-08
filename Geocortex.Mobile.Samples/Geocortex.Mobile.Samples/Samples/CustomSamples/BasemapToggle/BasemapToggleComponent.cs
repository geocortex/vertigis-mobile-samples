using System.Xml.Linq;
using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.CustomSamples.BasemapToggle;
using Xamarin.Forms;

[assembly: Component(typeof(BasemapToggleComponent), "basemap-toggle", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.CustomSamples.BasemapToggle
{
    public class BasemapToggleComponent : ComponentBase
    {
        private readonly BasemapToggleView _basemapToggleView;

        public BasemapToggleComponent(BasemapToggleView basemapToggleView)
        {
            this._basemapToggleView = basemapToggleView;
        }

        protected override VisualElement Create(XNode node)
        {
            return this._basemapToggleView;
        }
    }
}
