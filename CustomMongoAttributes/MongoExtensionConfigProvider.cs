using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Triggers;

using MongoDB.Driver;

namespace WebJobs.Extension.Mongo
{
    public class MongoExtensionConfigProvider: IExtensionConfigProvider
    {
        /// <summary>
        /// A MongoDB client, used to create context
        /// </summary>
        public IMongoServiceFactory _serviceFactory;

        public MongoExtensionConfigProvider(IMongoServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<MongoTriggerAttribute>()
                .BindToTrigger(new MongoTriggerBindingProvider(this));
        }

        public MongoTriggerContext CreateContext(MongoTriggerAttribute attribute)
        {
            var service = _serviceFactory.CreateMongoClient(attribute.GetConnectionString());
            return new MongoTriggerContext(attribute, service);
        }
    }
}