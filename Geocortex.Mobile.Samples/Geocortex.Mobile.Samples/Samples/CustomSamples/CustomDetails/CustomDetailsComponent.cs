using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Infrastructure.Messaging;
using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.CustomSamples.CustomDetails;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly:Component(typeof(CustomDetailsComponent), "custom-details", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.CustomSamples.CustomDetails
{
    class CustomDetailsComponent : ComponentBase
    {
        private CustomDetailsView _view;

        public CustomDetailsComponent(CustomDetailsOperations customDetailsOps)
        {
            customDetailsOps.DisplayCustomDetails.RegisterExecute(ExecuteDisplayCustomDetails, this);
        }

        protected override VisualElement Create(XNode node)
        {
            _view = new CustomDetailsView();
            return _view;
        }

        private async Task ExecuteDisplayCustomDetails(MapExtensionFeatureResultArgs args)
        {
            var firstFeature = args.Features.FirstOrDefault();
            var source = "Source Title: " + (string.IsNullOrEmpty(firstFeature?.Source.Title) ? "No source title" : firstFeature.Source.Title);
            var title = "Feature Title: " + (string.IsNullOrEmpty(firstFeature?.Title) ? "No feature title" : firstFeature.Title);
            await this.ActivateAsync();

            _view.SetSource(source);
            _view.SetTitle(title);
        }
    }
}
