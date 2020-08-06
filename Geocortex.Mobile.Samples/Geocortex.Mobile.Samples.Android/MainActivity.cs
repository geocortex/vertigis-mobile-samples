using Android.App;
using Android.Content.PM;
using Android.OS;
using Java.Lang;
using VertiGIS.Mobile.Platform;
using Xamarin.Forms;
using static Java.Lang.Thread;

namespace VertiGIS.Mobile.Samples.Droid
{
    [Activity(Name = "samples.mainactivity", Label = "Samples", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : VertiGISMobileActivity, IUncaughtExceptionHandler
    {
        protected override void OnCreate(Bundle bundle)
        {
            DefaultUncaughtExceptionHandler = this;
            HandleExceptions();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            AndroidInitializer.Init(this, bundle);
            Forms.Init(this, bundle);

            // The app was launched with the splash screen theme, so change it to the main theme now
            base.SetTheme(Resource.Style.MainTheme);

            base.OnCreate(bundle);

            var app = new App();

            // Handle startup urls
            HandleOnCreateIntent(app); // Startup urls
            HandleFullyDrawn(app); // Android diagnostics
            HandleAppPermissions(app); // Location, bluetooth, etc.

            LoadApplication(app);
        }

        public void UncaughtException(Thread t, Throwable e)
        {
        }
    }
}
