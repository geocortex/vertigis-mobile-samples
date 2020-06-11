using VertiGIS.Mobile.Samples;
using VertiGIS.Mobile.Samples.Samples.Conceptual.DisposeComponent;
using VertiGIS.Mobile.Composition.Layout;
using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(DisposeComponent), "dispose", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace VertiGIS.Mobile.Samples.Samples.Conceptual.DisposeComponent
{
    internal class DisposeComponent : ComponentBase
    {
        // Pointer to a fictitious external unmanaged resource.
        private SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // A managed resource this class uses.
        private Component component = new Component();

        private bool disposed = false;

        public DisposeComponent()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            return new Label()
            {
                Text = "Click the back button. This component cleans up its managed and unmanaged resources when the main app is disposed.",
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = 5
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Clean up managed resources.
                component.Dispose();
            }

            // Clean up unmanaged resources.
            handle.Dispose();

            base.Dispose(disposing);

            disposed = true;
        }
    }
}
