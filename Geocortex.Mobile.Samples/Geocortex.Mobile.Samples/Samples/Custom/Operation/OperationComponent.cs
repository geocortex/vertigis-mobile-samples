using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Custom.Operation;
using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Infrastructure.Messaging;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;

[assembly: Component(typeof(OperationComponent), "operation", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Custom.Operation
{
    class OperationComponent : ComponentBase
    {

        public OperationComponent(Operation operation)
        {
            operation.DisplayAlert.RegisterExecute(ExecuteAlert, this);
        }

        protected override VisualElement Create(XNode node)
        {
            return new StackLayout
            {
                Margin = 5,
                BackgroundColor = Color.Black,
                Children =
                {
                    new Label
                    {
                        Margin = 5,
                        Text = "Click the map to execute the operation.",
                    }
                }
            };
        }

        private Task ExecuteAlert(OperationArgs args)
        {
            if (args != null && !string.IsNullOrEmpty(args.Arguments))
            {
                Application.Current.MainPage.DisplayAlert("Operation Alert", args.Arguments, "OK");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Operation Alert", "This is an operation alert message.", "OK"); ;
            }

            return Task.CompletedTask;
        }
    }

    public class OperationArgs : EventArgsBase
    {
        [JsonProperty("arguments")]
        public string Arguments { get; set; }

        public OperationArgs(string args)
        {
            Arguments = args;
        }
    }
}
