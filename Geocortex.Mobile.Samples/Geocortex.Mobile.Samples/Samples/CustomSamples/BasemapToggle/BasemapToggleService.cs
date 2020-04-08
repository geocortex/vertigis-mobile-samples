using Esri.ArcGISRuntime.Mapping;
using Geocortex.Mobile.Composition;
using Geocortex.Mobile.Composition.Messaging;
using Geocortex.Mobile.Composition.Services;
using Geocortex.Mobile.Samples.Samples.CustomSamples.BasemapToggle;
using System.Threading.Tasks;

[assembly: Service(typeof(BasemapToggleService), PropertiesAutowired = true)]
namespace Geocortex.Mobile.Samples.Samples.CustomSamples.BasemapToggle
{
    public class BasemapToggleService : ServiceBase
    {
        public BasemapOperations BasemapOperations { get; set; }

        protected override Task DoInitialize()
        {
            this.BasemapOperations.ToggleDisplay.RegisterExecute(
                (args) =>
                {
                    foreach (Layer basemapLayer in args.Map.Map.Basemap.BaseLayers)
                    {
                        basemapLayer.IsVisible = args.ToggleOn;
                    }

                    return Task.FromResult((object)null);
                }, this);

            this.BasemapOperations.ToggleBasemap.RegisterExecute(
                (args) =>
                {
                    if (args.ToggleOn)
                    {
                        args.Map.Map.Basemap = Basemap.CreateNavigationVector();

                    }
                    else
                    {
                        args.Map.Map.Basemap = Basemap.CreateStreetsNightVector();
                    }


                    return Task.FromResult((object)null);
                }, this);

            return Task.CompletedTask;
        }
    }
}
