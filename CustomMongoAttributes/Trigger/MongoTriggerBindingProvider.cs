using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Triggers;

namespace WebJobs.Extension.Mongo
{
    public class MongoTriggerBindingProvider : ITriggerBindingProvider
    {
        /// <summary>
        /// MongoExtensionConfigProvider instance variable. Used to create the
        /// context
        /// </summary>
        private MongoExtensionConfigProvider _provider;

        public MongoTriggerBindingProvider(MongoExtensionConfigProvider provider)
        {
            _provider = provider;
        }

        public async Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            var attribute = context.Parameter.GetCustomAttribute<MongoTriggerAttribute>(false);

            var mongoTrigger = context.Parameter.GetCustomAttribute<MongoTriggerAttribute>(inherit: false);
            return mongoTrigger == null ? null : new MongoTriggerBinding(_provider.CreateContext(attribute));
        }
    }
}
