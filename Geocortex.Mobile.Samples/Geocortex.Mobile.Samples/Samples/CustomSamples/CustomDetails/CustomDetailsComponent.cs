using VertiGIS.Mobile.Composition.Layout;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Infrastructure.Messaging;
using VertiGIS.Mobile.Samples;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.CustomDetails;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly:Component(typeof(CustomDetailsComponent), "custom-details", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.CustomDetails
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
