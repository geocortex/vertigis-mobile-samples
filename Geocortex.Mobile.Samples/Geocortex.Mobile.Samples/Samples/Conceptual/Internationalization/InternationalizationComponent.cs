using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Conceptual.Internationalization;

using Geocortex.Mobile.Composition.Layout;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(InternationalizationComponent), "i18n", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Conceptual.Internationalization
{
    internal class InternationalizationComponent : ComponentBase
    {
        public InternationalizationComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            return new StackLayout()
            {
                Children =
                {
                    new Label()
                    {
                        FontAttributes = FontAttributes.Bold,
                        Text = AppResources.Custom_Translated_Title,
                        Margin = 5
                    },
                    new Label()
                    {
                        Text = AppResources.Custom_Translated_Message,
                        Margin = 5
                    },
                    new Label()
                    {
                        Text = AppResources.Fallback_String,
                        Margin = 5
                    }
                }

            };

        }
    }
}
