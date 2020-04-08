using Geocortex.Mobile.Composition;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Infrastructure.Messaging;

[assembly: Export(typeof(Geocortex.Mobile.Samples.Samples.Custom.Operation.Operation), SingleInstance = true)]
namespace Geocortex.Mobile.Samples.Samples.Custom.Operation
{
    class Operation : OperationsBase
    {
        public IVoidOperation<OperationArgs> DisplayAlert => GetVoidOperation<OperationArgs>("custom.operation");

        public Operation(IOperationRegistry operationRegistry)
            : base(operationRegistry)
        {
        }
    }
}
