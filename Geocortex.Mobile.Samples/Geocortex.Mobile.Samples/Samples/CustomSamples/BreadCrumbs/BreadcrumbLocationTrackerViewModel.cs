using Esri.ArcGISRuntime.Xamarin.Forms;
using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Composition.Layout;
using VertiGIS.Mobile.Composition.Utilities;
using VertiGIS.Mobile.Composition.Views;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.Breadcrumbs;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

[assembly: ViewModel(typeof(BreadcrumbLocationTrackerViewModel))]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.Breadcrumbs
{
    public sealed class BreadcrumbLocationTrackerViewModel : NotifyPropertyBase, IDisposable, IDisposableTracker
    {
        private BreadcrumbLocationTrackerOperations _breadcrumbLocationTrackerOperations;
        private ILayoutModel<MapView> _mapView;
        private bool _isToggled;

        public BreadcrumbLocationTrackerViewModel(BreadcrumbLocationTrackerOperations breadcrumbLocationTrackerOperations, ILayoutModel<MapView> mapView, bool isToggled = false)
        {
            _breadcrumbLocationTrackerOperations = breadcrumbLocationTrackerOperations;
            _mapView = mapView;
            _isToggled = isToggled;

            Disposables = new List<IDisposable>();
        }

        public string BreadcrumbImage
        {
            get
            {
                if (_isToggled)
                {
                    return (FileImageSource)ImageSource.FromFile("gcx_ui_map_pin");
                }
                else
                {
                    return (FileImageSource)ImageSource.FromFile("gcx_ui_geolocate_orientation");
                }
            }
        }

        private ICommand _breadcrumbLocationTrackerCommand;

        public ICommand BreadcrumbLocationTrackerCommand
        {
            get
            {
                if (_breadcrumbLocationTrackerCommand == null)
                {
                    _breadcrumbLocationTrackerCommand = new Command(async () =>
                    {
                        MapView mapView = await _mapView.ResolveAsync();
                        _isToggled = !_isToggled;

                        await _breadcrumbLocationTrackerOperations.ToggleDisplay.ExecuteAsync(new BreadcrumbLocationTrackerOperationsCommandArgs(mapView, _isToggled));
                    });
                }

                return _breadcrumbLocationTrackerCommand;
            }
        }

        public IList<IDisposable> Disposables { get; }

        public void Dispose()
        {
        }
    }
}
