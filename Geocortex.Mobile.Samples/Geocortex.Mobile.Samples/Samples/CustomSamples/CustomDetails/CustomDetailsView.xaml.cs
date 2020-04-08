using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geocortex.Mobile.Samples.Samples.CustomSamples.CustomDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDetailsView : ContentView
    {
        public CustomDetailsView()
        {
            InitializeComponent();
        }

        public void SetSource(string source)
        {
            SourceLabel.Text = source;
        }

        public void SetTitle(string title)
        {
            TitleLabel.Text = title;
        }
    }
}
