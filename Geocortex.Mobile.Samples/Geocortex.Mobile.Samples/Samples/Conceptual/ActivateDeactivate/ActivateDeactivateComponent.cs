using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Conceptual.ActivateDeactivate;
using Geocortex.Mobile.Composition.Layout;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(ActivateDeactivateComponent), "activate-deactivate", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Conceptual.ActivateDeactivate
{
    internal class ActivateDeactivateComponent : ComponentBase
    {
        private Label _label;

        public ActivateDeactivateComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            _label = new Label
            {
                Text = "This component is active.",
                Margin = 5,
                HorizontalTextAlignment = TextAlignment.Center
            };

            return _label;
        }

        protected override async Task ActivatedAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Activated Alert", "This alert is shown when the component is activated.", "OK");
        }

        protected override async Task DeactivatedAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Deactivated Alert", "This alert is shown when the component is deactivated.", "OK");
        }
    }
}
