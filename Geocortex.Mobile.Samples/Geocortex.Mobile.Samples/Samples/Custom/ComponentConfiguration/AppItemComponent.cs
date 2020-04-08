using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Custom.ComponentConfiguration;
using Geocortex.Mobile.Infrastructure.App;
using Geocortex.Mobile.Infrastructure.Layout;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: AppItemComponent(typeof(AppItemComponent), "component-config", AppItemConfiguration.ConfigItemtype, XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Custom.ComponentConfiguration
{
    internal class AppItemComponent : AppItemComponentBase<AppItemConfiguration>
    {
        private readonly IAppItem<AppItemConfiguration> _appItemResolver;
        private StackLayout _stack;
        private Label _title;
        private Label _text;

        public AppItemComponent(IAppItem<AppItemConfiguration> itemResolver)
            : base(itemResolver)
        {
            _appItemResolver = itemResolver;
        }

        protected override VisualElement Create(XNode node)
        {
            _title = new Label()
            {
                Margin = 5,
                FontAttributes = FontAttributes.Bold
            };

            _text = new Label()
            {
                Margin = 5,
            };

            _stack = new StackLayout() { Margin = 20 };
            _stack.Children.Add(_title);
            _stack.Children.Add(_text);

            return _stack;
        }

        protected override async Task DoInitializeAsync()
        {
            var item = await _appItemResolver.ResolveAsync();

            _title.Text = item.ConfigTitle;
            _text.Text = item.ConfigText;

            if (item.ConfigBoolean)
            {
                _stack.Children.Add(new Label()
                {
                    Margin = 5,
                    Text = "More text is added if the `boolean` property is `true`."
                });
            }
        }
    }
}
