using VertiGIS.Mobile.Samples.Samples.Custom.Service;
using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Messaging;
using VertiGIS.Mobile.Composition.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Service(typeof(CustomService), PropertiesAutowired = true)]
namespace VertiGIS.Mobile.Samples.Samples.Custom.Service
{
    class CustomService : ServiceBase
    {
        public ServiceOperation ServiceOperation { get; set; }

        protected override Task DoInitialize()
        {
            // Register our operation with the service.
            this.ServiceOperation.UpdateUI.RegisterExecute(
                (args) =>
                {
                    Application.Current.MainPage.DisplayAlert("Service Alert", "This is an service alert message.", "OK");
                    return Task.FromResult((object)null);
                }, this);

            return Task.CompletedTask;
        }
    }
}
