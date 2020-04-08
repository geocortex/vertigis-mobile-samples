using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Conceptual.Logging;
using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Composition.Logging;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(LoggingComponent), "logging", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Conceptual.Logging
{
    internal class LoggingComponent : ComponentBase
    {
        public LoggingComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            var loggingMessage = new Label()
            {
                Text = "Click a button to log a message to Geocortex Mobile's logging.",
            };

            var settingMessage = new Label()
            {
                Text = "Setting the log level determines which messages are logged. The default log level is `info`.",
            };

            var debug = new Button()
            {
                Text = "Log a debug message",
            };

            debug.Clicked += (sender, e) =>
            {
                OnButtonClicked("debug");
            };

            var info = new Button()
            {
                Text = "Log an info message",
            };

            info.Clicked += (sender, e) =>
            {
                OnButtonClicked("info");
            };

            var warn = new Button()
            {
                Text = "Log a warning message",
            };

            warn.Clicked += (sender, e) =>
            {
                OnButtonClicked("warn");
            };

            var error = new Button()
            {
                Text = "Log an error message",
            };

            error.Clicked += (sender, e) =>
            {
                OnButtonClicked("error");
            };

            var setDebug = new Button()
            {
                Text = "Set debug log level",
            };

            setDebug.Clicked += (sender, e) =>
            {
                OnSetButtonClicked("debug");
            };

            var setInfo = new Button()
            {
                Text = "Set info log level",
            };

            setInfo.Clicked += (sender, e) =>
            {
                OnButtonClicked("info");
            };

            var setWarn = new Button()
            {
                Text = "Set warning log level",
            };

            setWarn.Clicked += (sender, e) =>
            {
                OnSetButtonClicked("warn");
            };

            var setError = new Button()
            {
                Text = "Set error log level",
            };

            setError.Clicked += (sender, e) =>
            {
                OnSetButtonClicked("error");
            };

            var loggingStack = new StackLayout()
            {
                Margin = new Thickness(0, 10),
                Children = {
                    debug,
                    info,
                    warn,
                    error,
                },
            };

            var settingStack = new StackLayout()
            {
                Margin = new Thickness(0, 10),
                Children = {
                    setDebug,
                    setInfo,
                    setWarn,
                    setError
                },
            };

            return new StackLayout()
            {
                Children =
                {
                    loggingMessage,
                    loggingStack,
                    settingMessage,
                    settingStack
                },
            };
        }

        protected override Task DoInitializeAsync()
        {
            Logger.Info($"Starting the logging sample!");
            return base.DoInitializeAsync();
        }

        private void OnButtonClicked(string loggingLevel)
        {
            switch (loggingLevel)
            {
                case "debug":
                    Logger.Debug($"Logging a debug message!");
                    break;
                case "info":
                    Logger.Info($"Logging an info message!");
                    break;
                case "warn":
                    Logger.Warn($"Logging a warning message!");
                    break;
                case "error":
                    Logger.Error($"Logging an error message!");
                    break;
            }
        }

        private void OnSetButtonClicked(string loggingLevel)
        {
            switch (loggingLevel)
            {
                case "debug":
                    Logger.LogLevel = LogLevel.Debug;
                    break;
                case "info":
                    Logger.LogLevel = LogLevel.Info;
                    break;
                case "warn":
                    Logger.LogLevel = LogLevel.Warn;
                    break;
                case "error":
                    Logger.LogLevel = LogLevel.Error;
                    break;
            }
        }
    }
}
