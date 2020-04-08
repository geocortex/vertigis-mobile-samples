using Geocortex.Mobile.Samples;
using Geocortex.Mobile.Samples.Samples.Conceptual.ActivateDeactivateChildren;
using Geocortex.Mobile.Composition.Layout;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

[assembly: Component(typeof(ActivateDeactivateChildrenComponent), "activate-deactivate-children", XmlNamespace = XmlNamespaces.SamplesNamespace)]
namespace Geocortex.Mobile.Samples.Samples.Conceptual.ActivateDeactivateChildren
{
    internal class ActivateDeactivateChildrenComponent : ComponentBase
    {
        private Grid _grid;

        public ActivateDeactivateChildrenComponent(): base()
        {
        }

        protected override VisualElement Create(XNode node)
        {
            _grid = new Grid();

            int i = 0;

            _grid.RowDefinitions = new RowDefinitionCollection { new RowDefinition { Height = new GridLength(1, GridUnitType.Star) } };
            _grid.ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) } };

            foreach (var child in Children)
            {
                _grid.Children.Add((View)child.GetView(), 0, i);
                i++;
            }

            return _grid;
        }

        protected override Task DeactivateChildAsync(ComponentBase removed)
        {
            // Remove the child.
            var row = Grid.GetRow(removed.GetView());
            _grid.Children.Remove((View)removed.GetView());
            
            if (_grid.Children.Count == 0)
            {
                return Task.CompletedTask;
            }

            // Move all subsequent children up a row.
            foreach (var child in Children.Where(child => Grid.GetRow(child.GetView()) > row)) {
                Grid.SetRow(child.GetView(), Grid.GetRow(child.GetView()) - 1);
            }

            return Task.CompletedTask;
        }

        protected override Task ActivateChildAsync(ComponentBase child)
        {
            // Add children to the bottom of the list.
            _grid.Children.AddVertical((View)child.GetView());
            return Task.CompletedTask;
        }
    }
}
