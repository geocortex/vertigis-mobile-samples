﻿using VertiGIS.Mobile.Samples.SampleSelector;
using VertiGIS.Mobile.Infrastructure.App;
using VertiGIS.Mobile.Infrastructure.Configuration;
using VertiGIS.Mobile.Toolkit.Views;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using VertiGIS.Mobile.Toolkit.Views.Markdown;
using Xamarin.Forms;

namespace VertiGIS.Mobile.Samples
{
    public class App : VertiGIS.Mobile.App
    {
        public static App SamplesInstance;
        public LoadAppResult LoadResult;

        public App()
            : base()
        {
            // Add the styles from this page to the application - overrides styles from VertiGIS.Mobile
            var res = new Styles().Resources;
            this.Resources.MergedDictionaries.Add(res);

            Current.MainPage = new ContentPage()
            {
                Content = GetContent()
            };

            // Register additional assemblies to search for configured assembly attributes.
            AssemblyManager.RegisterAssemblies(this.GetType().Assembly);

            SamplesInstance = this;
        }

        protected override async void OnStart()
        {
            // Initialize Geocortex Mobile
            await InitializeAsync();

            // Get our sample selection page and set it as the root.
            var selectorPage = new SampleSelector.Selector(this);

            Instance.MainPage = new NavigationPage(selectorPage)
            {
                Title = "Geocortex Mobile SDK Samples",
            };
        }

        public async Task LoadApp(Sample sample)
        {
            // Push a loading spinner.
            if (Device.RuntimePlatform != Device.iOS)
            {
                await VertiGIS.Mobile.App.Instance.MainPage.Navigation.PushModalAsync(new ContentPage()
                {
                    Content = GetContent()
                });
            }

            // Configure some paths.
            var app = new Uri("resource://" + sample?.App);
            var layout = string.IsNullOrEmpty(sample?.Layout) ? null : new Uri("resource://" + sample?.Layout);
            var readme = $"VertiGIS.Mobile.Samples.Samples.{sample.PathFragment}.README.md";

            if (layout == null)
            {
                // If we don't have a layout, assume it's available in the app.
                LoadResult = await Bootstrapper.LoadAppAysnc(app);

                // Workaround - iOS apps w/ horizontal taskbar are being problematic with navigation stack.
                // Just load them directly.
                if (Device.RuntimePlatform == Device.iOS)
                {
                    await Instance.MainPage.Navigation.PushModalAsync(LoadResult.Page, false);
                    return;
                }
            }
            else
            {
                // Load the main Geocortex Mobile app page.
                LoadResult = await Bootstrapper.LoadAppAysnc(app, layout);
            }

            LoadResult.Page.Title = "Demo";
            LoadResult.Page.IconImageSource = "demo.png";

            var tabbedPage = new TabbedPage()
            {
                Title = sample.Name,
                BarBackgroundColor = Color.LightGray,
                BarTextColor = Color.Black
            };

            var description = GetDescription(readme);
            tabbedPage.Children.Add(LoadResult.Page);
            tabbedPage.Children.Add(new ContentPage { Content = description, Title = "Description", IconImageSource = "description.png" });

            await Instance.MainPage.Navigation.PushAsync(tabbedPage, false);

            // Pop the loading spinner.
            if (Device.RuntimePlatform != Device.iOS)
            {
                await Instance.MainPage.Navigation.PopModalAsync();
            }
        }

        public View GetDescription(string resource)
        {
            // Get our markdown content.
            string readmeContent;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    readmeContent = reader.ReadToEnd();
                }
            }

            // Create our markdown description.
            var view = new MarkdownView()
            {
                Markdown = readmeContent,
                LabelStyleOverrides = new Style(typeof(Label)) { Setters = { new Setter { Property = Label.TextColorProperty, Value = Color.Black } } }
            };

            var scrollContainer = new ScrollView() { Content = view.Content, HeightRequest = 1000, Margin = 5 };

            var stack = new StackLayout()
            {
                BackgroundColor = Color.White,
                Children =
                {
                    scrollContainer
                }
            };

            return stack;
        }

        public View GetContent()
        {
            // Stack
            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 15
            };

            // Spinner
            var spinner = new EnhancedActivityIndicator()
            {
                IsRunning = true
            };
            spinner.WidthRequest = 75;
            spinner.HeightRequest = 75;
            stack.Children.Add(spinner);

            // Label
            var label = new Label()
            {
                TextColor = Color.Black
            };
            stack.Children.Add(label);

            void ShowStatus(object sender, LoadingEventArgs e)
            {
                if (GlobalConfiguration.Instance.StartupLoadStatus)
                {
                    label.Text = e.LoadAction;
                }
                else
                {
                    LoadingAction -= ShowStatus;
                }
            }

            LoadingAction += ShowStatus;

            return stack;
        }
    }
}
