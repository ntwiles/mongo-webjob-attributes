using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Triggers;

namespace WebJobs.Extension.Mongo
{
    public class MongoTriggerBindingProvider : ITriggerBindingProvider
    {
        public async Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            return new MongoTriggerBinding();
        }
    }
}
