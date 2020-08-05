namespace VertiGIS.Mobile.Samples.UWP
{
    /// <summary>
    /// The main entry point for the Windows App.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new VertiGIS.Mobile.Samples.App());
        }
    }
}
