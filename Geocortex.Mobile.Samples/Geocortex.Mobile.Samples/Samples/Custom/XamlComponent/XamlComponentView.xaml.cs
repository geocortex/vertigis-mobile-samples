using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geocortex.Mobile.Samples.Samples.Custom.XamlComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamlComponentView : ContentView
    {
        public XamlComponentView()
        {
            InitializeComponent();
        }
    }
}
