using Geocortex.Mobile.Composition;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Infrastructure.Messaging;

[assembly: Export(typeof(Geocortex.Mobile.Samples.Samples.CustomSamples.CustomDetails.CustomDetailsOperations), SingleInstance = true)]
namespace Geocortex.Mobile.Samples.Samples.CustomSamples.CustomDetails
{
    class CustomDetailsOperations : OperationsBase
    {
        public IVoidOperation<MapExtensionFeatureResultArgs> DisplayCustomDetails => GetVoidOperation<MapExtensionFeatureResultArgs>("custom.display-details");

        public CustomDetailsOperations(IOperationRegistry operationRegistry)
            : base(operationRegistry)
        {
        }
    }
}
