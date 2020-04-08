using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Conceptual.DependencyInjection;
using Esri.ArcGISRuntime.Geometry;
using Geocortex.Mobile.Composition.Layout;
using Geocortex.Mobile.Infrastructure.Maps;
using Geocortex.Mobile.Infrastructure.UI;
using System;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;
using System.Reactive.Linq;

[assembly: Component(typeof(DependencyInjectionComponent), "dependency-injection", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Conceptual.DependencyInjection
{
    class DependencyInjectionComponent : ComponentBase
    {
        private MapRepository _mapRepo;
        private IDialogController _dialogController;

        private Button _infoButton;

        // Classes are accessible through dependency injection by including them in a component's constructor.
        public DependencyInjectionComponent(MapRepository mapRepo, IDialogController dialogController)
        {
            _mapRepo = mapRepo;
            _dialogController = dialogController;
        }

        protected override VisualElement Create(XNode node)
        {
            _infoButton = new Button
            {
                Text = "Get Map Info",
                Margin = 10
            };
            _infoButton.Clicked += OnButtonClick;

            return new StackLayout()
            {
                Children =
                {
                    _infoButton
                }
            };
        }

        private async void OnButtonClick(object sender, EventArgs e)
        {
            var mapContainer = _mapRepo.AllMaps;
            var map = await mapContainer.FirstOrDefaultAsync();
            var mapView = map.MapView;
            var mapExtension = map.MapExtension;

            var sb = new StringBuilder();
            sb.AppendLine($"Map Name: {mapExtension.Map.Item.Title}");
            sb.AppendLine($"Map URL: {mapExtension.Map.Uri}");
            sb.AppendLine($"Basemap Name: {mapExtension.Map.Basemap.Name}");
            sb.AppendLine($"Map Extent: {mapView.VisibleArea.Extent.ToString()}");
            var location = GeometryEngine.Project(mapView.VisibleArea.Extent.GetCenter(), SpatialReferences.Wgs84) as MapPoint;
            sb.AppendLine($"Map Center: Latitude: {location.Y}, Longitude: {location.X}");
            await _dialogController.ShowAlertAsync(sb.ToString(), "Dependency Injection Alert");
        }
    }
}
