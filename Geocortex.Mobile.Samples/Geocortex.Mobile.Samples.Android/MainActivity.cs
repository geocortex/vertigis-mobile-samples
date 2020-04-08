using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using CarouselView.FormsPlugin.Android;
using Geocortex.Mobile;
using Geocortex.Mobile.Composition.Logging;
using Geocortex.Mobile.Infrastructure.App;
using Geocortex.Mobile.Infrastructure.Configuration;
using Geocortex.Mobile.Infrastructure.Internationalization;
using Geocortex.Mobile.Platform;
using Geocortex.Workflow.Forms.Android;
using Java.Lang;
using Plugin.CurrentActivity;
using Rg.Plugins.Popup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Views.View;
using static Java.Lang.Thread;

namespace Geocortex.Mobile.Samples.Droid
{
    [Activity(Name = "samples.mainactivity", Label = "Samples", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : GeocortexMobileActivity, IUncaughtExceptionHandler
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
