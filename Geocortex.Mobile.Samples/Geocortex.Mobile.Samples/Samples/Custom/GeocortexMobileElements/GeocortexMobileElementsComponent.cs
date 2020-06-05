using VertiGIS.Mobile.Samples;
using VertiGIS.Mobile.Samples.Samples.Custom.GeocortexMobileElements;
using VertiGIS.Mobile.Composition.Layout;
using VertiGIS.Mobile.Infrastructure.UI;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(GeocortexMobileElementsComponent), "geocortex-mobile-elements", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace VertiGIS.Mobile.Samples.Samples.Custom.GeocortexMobileElements
{
    internal class GeocortexMobileElementsComponent : ComponentBase
    {
        public GeocortexMobileElementsComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            var enhancedActivityIndicatorLabel = new Label
            {
                Text = "This is a Geocortex Mobile enhanced activity indicator.",
                Margin = new Thickness(10, 0)
            };

            var enhancedActivityIndicator = new EnhancedActivityIndicator()
            {
                IsRunning = true,
                HeightRequest = 75,
                WidthRequest = 75,
                Margin = new Thickness(10, 0, 10, 10)
            };

            var enhancedButton = new EnhancedButton()
            {
                Text = "Geocortex Mobile button",
                Margin = 10
            };

            var enhancedEntry = new EnhancedEntry()
            {
                Placeholder = "This is a Geocortex Mobile enhanced entry.",
                Margin = 10
            };

            var enhancedSwitchLabel = new Label
            {
                Text = "This is a Geocortex Mobile enhanced switch.",
                Margin = new Thickness(10, 0)
            };

            var enhancedSwitch = new EnhancedSwitch()
            {
                Margin = new Thickness(10, 0, 10, 10)
            };

            var view = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    enhancedActivityIndicatorLabel,
                    enhancedActivityIndicator,
                    enhancedButton,
                    enhancedEntry,
                    enhancedSwitchLabel,
                    enhancedSwitch,
                }
            };

            return view;
        }
    }
}
