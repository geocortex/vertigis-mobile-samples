using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Custom.Component;
using Geocortex.Mobile.Composition.Layout;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(CustomComponent), "component", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Custom.Component
{
    internal class CustomComponent : ComponentBase
    {
        public CustomComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            return new Label()
            {
                Text = "Hello, World!",
                HorizontalTextAlignment = TextAlignment.Center
            };
        }
    }
}
