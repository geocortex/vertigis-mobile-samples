using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Infrastructure.Messaging;

[assembly: Export(typeof(VertiGIS.Mobile.Samples.Samples.CustomSamples.CustomDetails.CustomDetailsOperations), SingleInstance = true)]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.CustomDetails
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
