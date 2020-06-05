using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VertiGIS.Mobile.Samples.Samples.Workflow.CustomFormComponent;
using VertiGIS.Mobile.Composition;
using Geocortex.Workflow.Runtime;
using Geocortex.Workflow.Runtime.Definition;
using Geocortex.Workflow.Runtime.Execution;

[assembly: Export(typeof(FormLoader), SingleInstance = true, AsImplementedInterfaces = true)]
namespace VertiGIS.Mobile.Samples.Samples.Workflow.CustomFormComponent
{
    class FormLoader : IActivityHandlerFactory
    {
        /// <summary>
        /// Gets a mapping of action names to implementations of <see cref="IActivityHandler"/>s.
        /// </summary>
        private Dictionary<string, Func<IActivityHandler>> RegisteredActivities { get; } = new Dictionary<string, Func<IActivityHandler>>();

        public FormLoader()
        {
            RegisteredActivities[RegisterComponent.Action] = () => new RegisterComponent();
        }

        /// <summary>
        /// Creates an <see cref="IActivityHandler"/>.
        /// </summary>
        /// <param name="action">The name of the action to create.</param>
        /// <param name="token">The cancellation token.</param>
        /// <param name="inspector">The <see cref="ProgramInspector"/> for the program.</param>
        /// <returns>The activity handler for the given action.</returns>
        public Task<IActivityHandler> Create(string action, CancellationToken token, ProgramInspector inspector = null)
        {
            if (action == null || token.IsCancellationRequested)
            {
                return Task.FromResult<IActivityHandler>(null);
            }

            if (RegisteredActivities.TryGetValue(action, out Func<IActivityHandler> handlerType))
            {
                return Task.FromResult(handlerType());
            }
            else
            {
                return Task.FromResult<IActivityHandler>(null);
            }
        }
    }
}
