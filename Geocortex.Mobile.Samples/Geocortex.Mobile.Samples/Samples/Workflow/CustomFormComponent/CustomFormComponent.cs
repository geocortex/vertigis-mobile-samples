using VertiGIS.Mobile.Infrastructure.UI;
using VertiGIS.Mobile.Workflow.Components;

namespace VertiGIS.Mobile.Samples.Samples.Workflow.CustomFormComponent
{
    class CustomFormComponent : FormComponent
    {
        private readonly EnhancedActivityIndicator _view;

        public CustomFormComponent(Geocortex.Workflow.Runtime.Definition.Forms.Element element, string name) 
            : base (element, name)
        {
            _view = new EnhancedActivityIndicator()
            {
                IsRunning = true,
                HeightRequest = 75,
                WidthRequest = 75,
                Margin = 10
            };

            Add(new GenericComponent(_view));
        }

        public override void Render()
        {
            base.Render();
            _view.IsEnabled = IsEnabled;
        }
    }
}
