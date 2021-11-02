using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace WebJobs.Extension.Mongo
{
    public class MongoExtensionConfigProvider: IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<MongoTriggerAttribute>()
                .BindToTrigger(new MongoTriggerBindingProvider(this));
        }

        public MongoTriggerContext CreateContext(MongoTriggerAttribute attribute)
        {
            return new MongoTriggerContext(attribute, "foo");
        }
    }
}