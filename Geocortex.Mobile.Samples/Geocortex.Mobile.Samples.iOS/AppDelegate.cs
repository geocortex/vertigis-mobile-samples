using Foundation;
using UIKit;
using VertiGIS.Mobile.Platform;
using Xamarin.Forms;

namespace VertiGIS.Mobile.Samples.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : VertiGISAppDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            IOSInitializer.Init();
            Forms.Init();
            var viewerApp = new App();
            LoadApplication(viewerApp);

            return base.FinishedLaunching(app, options);
        }
    }
}
