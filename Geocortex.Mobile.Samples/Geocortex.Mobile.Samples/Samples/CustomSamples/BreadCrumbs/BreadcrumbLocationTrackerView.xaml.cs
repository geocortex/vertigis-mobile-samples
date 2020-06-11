using VertiGIS.Mobile.Composition;
using VertiGIS.Mobile.Samples.Samples.CustomSamples.Breadcrumbs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: View(typeof(BreadcrumbLocationTrackerView))]
namespace VertiGIS.Mobile.Samples.Samples.CustomSamples.Breadcrumbs
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BreadcrumbLocationTrackerView : ContentView
    {
        public BreadcrumbLocationTrackerViewModel ViewModel => (BreadcrumbLocationTrackerViewModel)BindingContext;

        public BreadcrumbLocationTrackerView(BreadcrumbLocationTrackerViewModel viewModel)
		{
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
