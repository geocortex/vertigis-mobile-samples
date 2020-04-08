using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geocortex.Mobile.Samples.SampleSelector
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Selector : ContentPage
    {
        private readonly App _app;

        public List<SampleGroup> Samples { get; private set; } = new List<SampleGroup>();

        public Selector(App app)
        {
            _app = app;

            InitializeComponent();
            InitializeSamples();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            if (App.SamplesInstance.LoadResult != null)
            {
                App.SamplesInstance.LoadResult.Dispose();
            }

            collectionList.SelectedItem = null;

            base.OnAppearing();
        }

        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() == null)
            {
                return;
            }

            await _app.LoadApp(e.CurrentSelection.FirstOrDefault() as Sample);
        }

        private void InitializeSamples()
        {
            Samples.Add(new SampleGroup("App Samples", new List<Sample>
            {
                new Sample
                {
                    Name = "Geocortex Mobile App",
                    App = "app.json",
                    Layout = null,
                    Description = "A Geocortex Mobile app with common components and configurations.",
                    PathFragment = "App.GeocortexMobileViewer"
                },
            }));

            Samples.Add(new SampleGroup("Layout", new List<Sample>
            {
                new Sample
                {
                    Name = "Stack",
                    App = "stack.json",
                    Layout = "stack.xml",
                    Description = "Using a stack component.",
                    PathFragment = "Layout.Stack"
                },
                new Sample
                {
                    Name = "Split",
                    App = "split.json",
                    Layout = "split.xml",
                    Description = "Using a split component.",
                    PathFragment = "Layout.Split"
                },
                new Sample
                {
                    Name = "Map Panel",
                    App = "map-panel.json",
                    Layout = "map-panel.xml",
                    Description = "A panel hosted in the map.",
                    PathFragment = "Layout.MapPanel"
                },
                //new Sample
                //{
                //    Name = "Map Search",
                //    App = "map-search.json",
                //    Layout = "map-search.xml",
                //    Description = "A persistent search and results layout.",
                //    PathFragment = "Layout.MapSearch"
                //},
                new Sample
                {
                    Name = "Button Styles",
                    App = "button-styles.json",
                    Layout = "button-styles.xml",
                    Description = "Demonstrates button styling.",
                    PathFragment = "Layout.ButtonStyles"
                },
                new Sample
                {
                    Name = "Hierarchical Panel Navigation",
                    App = "hierarchical-panel-navigation.json",
                    Layout = "hierarchical-panel-navigation.xml",
                    Description = "Navigates between panels in a hierarchy.",
                    PathFragment = "Layout.HierarchicalPanelNavigation"
                },
                new Sample
                {
                    Name = "Taskbar",
                    App = "taskbar.json",
                    Layout = "taskbar.xml",
                    Description = "Demonstrates the configuration of taskbar items.",
                    PathFragment = "Layout.Taskbar"
                },
                new Sample
                {
                    Name = "Layout Properties",
                    App = "layout-properties.json",
                    Layout = "layout-properties.xml",
                    Description = "Demonstrates layout position properties.",
                    PathFragment = "Layout.LayoutProperties",
                    Platform = "*Best viewed on Windows devices."
                },
                new Sample
                {
                    Name = "Dialog Component",
                    App = "dialog.json",
                    Layout = "dialog.xml",
                    Description = "Demonstrates activation of the dialog component.",
                    PathFragment = "Layout.Dialog"
                }
            }));

            Samples.Add(new SampleGroup("App Configuration", new List<Sample>
            {
                new Sample
                {
                    Name = "Map Configuration",
                    App = "map-configuration.json",
                    Layout = "map-configuration.xml",
                    Description = "Demonstrates the configuration of a map component.",
                    PathFragment = "AppConfiguration.MapConfiguration"
                },
                new Sample
                {
                    Name = "Commands",
                    App = "commands.json",
                    Layout = "commands.xml",
                    Description = "Demonstrates various app commands.",
                    PathFragment = "AppConfiguration.Commands",
                    Platform = "*Best viewed on Windows devices."
                },
                new Sample
                {
                    Name = "Map and Feature Commands",
                    App = "map-and-feature-commands.json",
                    Layout = "map-and-feature-commands.xml",
                    Description = "Demonstrates various map and feature commands.",
                    PathFragment = "AppConfiguration.MapAndFeatureCommands",
                    Platform = "*Best viewed on Windows devices."
                },
                new Sample
                {
                    Name = "Theme",
                    App = "theme.json",
                    Layout = "theme.xml",
                    Description = "Demonstrates using Geocortex branding.",
                    PathFragment = "AppConfiguration.Theme"
                }
            }));

            Samples.Add(new SampleGroup("Custom", new List<Sample>
            {
                new Sample
                {
                    Name = "Component",
                    App = "component.json",
                    Layout = "component.xml",
                    Description = "Getting started with custom components.",
                    PathFragment = "Custom.Component"
                },
                new Sample
                {
                    Name = "Component Configuration",
                    App = "component-configuration.json",
                    Layout = "component-configuration.xml",
                    Description = "Getting started with custom components that take app item configuration.",
                    PathFragment = "Custom.ComponentConfiguration"
                },
                new Sample
                {
                    Name = "Operation",
                    App = "operation.json",
                    Layout = "operation.xml",
                    Description = "Getting started with custom operations.",
                    PathFragment = "Custom.Operation"
                },
                new Sample
                {
                    Name = "Service",
                    App = "service.json",
                    Layout = "service.xml",
                    Description = "Getting started with custom services.",
                    PathFragment = "Custom.Service"
                },
                new Sample
                {
                    Name = "XAML Component",
                    App = "xaml-component.json",
                    Layout = "xaml-component.xml",
                    Description = "Getting started with a custom component using a XAML view.",
                    PathFragment = "Custom.XamlComponent"
                },
                new Sample
                {
                    Name = "Geocortex Mobile Elements",
                    App = "geocortex-mobile-elements.json",
                    Layout = "geocortex-mobile-elements.xml",
                    Description = "Getting started with Geocortex Mobile enhanced elements.",
                    PathFragment = "Custom.GeocortexMobileElements"
                },
                //new Sample
                //{
                //    Name = "Geocortex Mobile Styles",
                //    App = "gxm-styles.json",
                //    Layout = "gxm-styles.xml",
                //    Description = "An introduction to using Geocortex Mobile styles.",
                //    PathFragment = "Custom.GeocortexMobileStyles"
                //},
            }));

            Samples.Add(new SampleGroup("Custom Samples", new List<Sample>
            {
                new Sample
                {
                    Name = "Basemap Toggle",
                    App = "basemap-toggle.json",
                    Layout = "basemap-toggle.xml",
                    Description = "Toggles the basemap and its visibility.",
                    PathFragment = "CustomSamples.BasemapToggle"
                },
                new Sample
                {
                    Name = "Bread Crumbs",
                    App = "bread-crumbs.json",
                    Layout = "bread-crumbs.xml",
                    Description = "A location service that draws `bread crumbs` on the map.",
                    PathFragment = "CustomSamples.BreadCrumbs"
                },
                new Sample
                {
                    Name = "Custom Details",
                    App = "custom-details.json",
                    Layout = "custom-details.xml",
                    Description = "An operation to display content after an `identify` action.",
                    PathFragment = "CustomSamples.CustomDetails"
                },
                new Sample
                {
                    Name = "Location - Platform API",
                    App = "location.json",
                    Layout = "location.xml",
                    Description = "Gets the user's location using platform specific APIs.",
                    PathFragment = "CustomSamples.Location"
                }
            }));

            Samples.Add(new SampleGroup("Conceptual", new List<Sample>
            {
                new Sample
                {
                    Name = "Activate and Deactivate",
                    App = "activate-deactivate.json",
                    Layout = "activate-deactivate.xml",
                    Description = "How to take some action when a component is activated or deactivated.",
                    PathFragment = "Conceptual.ActivateDeactivate"
                },
                new Sample
                {
                    Name = "Activate and Deactivate Children",
                    App = "activate-deactivate-children.json",
                    Layout = "activate-deactivate-children.xml",
                    Description = "How to manage the activation and deactivation of child components.",
                    PathFragment = "Conceptual.ActivateDeactivateChildren"
                },
                new Sample
                {
                    Name = "Dependency Injection",
                    App = "dependency-injection.json",
                    Layout = "dependency-injection.xml",
                    Description = "An introduction to using dependency injection in Geocortex Mobile.",
                    PathFragment = "Conceptual.DependencyInjection"
                },
                new Sample
                {
                    Name = "Disposal",
                    App = "disposal.json",
                    Layout = "disposal.xml",
                    Description = "Cleans up after the component by using disposal.",
                    PathFragment = "Conceptual.Disposal"
                },
                new Sample
                {
                    Name = "Internationalization",
                    App = "i18n.json",
                    Layout = "i18n.xml",
                    Description = "Using internationalization to support language strings.",
                    PathFragment = "Conceptual.Internationalization"
                },
                new Sample
                {
                    Name = "Logging",
                    App = "logging.json",
                    Layout = "logging.xml",
                    Description = "Using logging in a Geocortex Mobile app.",
                    PathFragment = "Conceptual.Logging"
                },
                 new Sample
                {
                    Name = "Orientation Lock",
                    App = "orientation-lock.json",
                    Layout = "orientation-lock.xml",
                    Description = "Locking an app to an orientation (portrait or landscape).",
                    PathFragment = "Conceptual.OrientationLock",
                    Platform = "*Best viewed on Android/iOS devices."
                },
                new Sample
                {
                    Name = "Phone vs. Desktop",
                    App = "phone-vs-desktop.json",
                    Layout = null,
                    Description = "Loading an app based on form factor.",
                    PathFragment = "Conceptual.PhoneVsDesktop",
                    Platform = "*Best viewed on Android/iOS phone devices."
                }
            }));

            Samples.Add(new SampleGroup("Geocortex Workflow", new List<Sample>
            {
                new Sample
                {
                    Name = "Run Workflow",
                    App = "run-workflow.json",
                    Layout = "run-workflow.xml",
                    Description = "Running a Geocortex Workflow.",
                    PathFragment = "Workflow.RunWorkflow"
                },
                new Sample
                {
                    Name = "Custom Workflow Activity",
                    App = "custom-activity.json",
                    Layout = "custom-activity.xml",
                    Description = "Getting started with custom Geocortex Workflow activities.",
                    PathFragment = "Workflow.CustomActivity"
                },
                new Sample
                {
                    Name = "Custom Workflow Component",
                    App = "custom-form-component.json",
                    Layout = "custom-form-component.xml",
                    Description = "Getting started with custom Geocortex Workflow components.",
                    PathFragment = "Workflow.CustomFormComponent"
                }
            }));
        }
    }
}
