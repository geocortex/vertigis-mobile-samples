using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Infrastructure.Messaging;
using VertiGIS.Mobile.Samples.Samples.Custom.Service;

[assembly: Export(typeof(ServiceOperation), SingleInstance = true)]
namespace VertiGIS.Mobile.Samples.Samples.Custom.Service
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
