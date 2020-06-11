using VertiGIS.Mobile.Samples;
using VertiGIS.Mobile.Samples.Samples.Custom.Component;
using VertiGIS.Mobile.Composition.Layout;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(CustomComponent), "component", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace VertiGIS.Mobile.Samples.Samples.Custom.Component
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
