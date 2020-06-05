using VertiGIS.Mobile.Samples.Samples.Custom.ComponentConfiguration;
using VertiGIS.ArcGISExtensions;
using VertiGIS.Mobile.Infrastructure.App;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: AppItem(AppItemConfiguration.ConfigItemtype, typeof(AppItemConfiguration))]
namespace VertiGIS.Mobile.Samples.Samples.Custom.ComponentConfiguration
{
    public class AppItemConfiguration : VisualAppItem
    {
        public const string ConfigItemtype = "component-config";

        public string ConfigTitle { get; private set; }
        public string ConfigText { get; private set; }
        public bool ConfigBoolean { get; private set; }

        public AppItemConfiguration()
            : this(Guid.NewGuid().ToString())
        {
        }

        public AppItemConfiguration(string id)
            : this(new Properties { ["id"] = id })
        {
        }

        public AppItemConfiguration(Properties properties) :
            base(properties, ConfigItemtype)
        {
            if (properties.TryGetValue("title", out var title))
            {
                ConfigTitle = title as string ?? "Default Title";
            }

            if (properties.TryGetValue("text", out var text))
            {
                ConfigText = text as string ?? "Default text.";
            }

            if (properties.TryGetValue("boolean", out var boolean))
            {
                ConfigBoolean = boolean as bool? ?? false;
            }
        }

        public override object CreateDefault()
        {
            return new AppItemConfiguration();
        }
    }
}
