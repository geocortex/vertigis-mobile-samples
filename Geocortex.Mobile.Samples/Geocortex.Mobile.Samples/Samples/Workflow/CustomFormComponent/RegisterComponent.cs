using Geocortex.Workflow.Runtime;
using Geocortex.Workflow.Runtime.Activities.App;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VertiGIS.Mobile.Samples.Samples.Workflow.CustomFormComponent
{
    class RegisterComponent : RegisterCustomFormElementBase
    {
        public const string Action = "CustomComponent";

        public override Task<IDictionary<string, object>> Execute(IDictionary<string, object> inputs, IActivityContext context)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            Register("CustomComponent", typeof(CustomFormComponent), context);
            return Task.FromResult(result);
        }
    }
}
