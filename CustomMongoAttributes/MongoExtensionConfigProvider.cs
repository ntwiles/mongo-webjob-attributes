using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace CustomMongoAttributes
{
    public class MongoExtensionConfigProvider: IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<MongoTriggerAttribute>()
                .BindToTrigger(new MongoTriggerBindingProvider());
        }
    }
}