using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Infrastructure.Messaging;

[assembly: Export(typeof(VertiGIS.Mobile.Samples.Samples.Custom.Operation.Operation), SingleInstance = true)]
namespace VertiGIS.Mobile.Samples.Samples.Custom.Operation
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
