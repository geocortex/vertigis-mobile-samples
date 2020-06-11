using System.Xml.Linq;
using VertiGIS.Mobile.Composition.Layout;
using VertiGIS.Mobile.Samples;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.BasemapToggle;
using Xamarin.Forms;

[assembly: Component(typeof(BasemapToggleComponent), "basemap-toggle", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.BasemapToggle
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
