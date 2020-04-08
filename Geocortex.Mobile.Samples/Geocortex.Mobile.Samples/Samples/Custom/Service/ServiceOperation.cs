using Geocortex.Mobile.Composition;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Infrastructure.Messaging;
using Geocortex.Mobile.Samples.Samples.Custom.Service;

[assembly: Export(typeof(ServiceOperation), SingleInstance = true)]
namespace Geocortex.Mobile.Samples.Samples.Custom.Service
{
    class ServiceOperation : OperationsBase
    {
        public IVoidOperation<object> UpdateUI => GetVoidOperation<object>("service.operation");

        public ServiceOperation(IOperationRegistry operationRegistry)
            : base(operationRegistry)
        {
        }
    }
}
