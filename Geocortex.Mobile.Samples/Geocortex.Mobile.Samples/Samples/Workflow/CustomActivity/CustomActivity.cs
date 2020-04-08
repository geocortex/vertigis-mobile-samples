using Geocortex.Workflow.Runtime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geocortex.Mobile.Samples.Samples.Workflow.CustomActivity
{
    public class CustomActivity : IActivityHandler
    {
        public const string Action = "custom:wf:app::Hello";

        public Task<IDictionary<string, object>> Execute(IDictionary<string, object> inputs, IActivityContext context)
        {
            string name = "Custom Workflow!";
            if (inputs.TryGetValue("name", out var temp))
            {
                name = temp as string ?? name;
            }

            IDictionary<string, object> result = new Dictionary<string, object>()
            {
                ["hello"] = $"Hello, '{name}'"
            };

            return Task.FromResult(result);
        }
    }
}
