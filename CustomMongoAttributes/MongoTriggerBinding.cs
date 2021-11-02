using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace WebJobs.Extension.Mongo
{
    public class MongoTriggerBinding : ITriggerBinding
    {
        private readonly MongoTriggerContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">MongoTriggerContext instance</param>
        public MongoTriggerBinding(MongoTriggerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Trigger value type string
        /// </summary>
        public Type TriggerValueType => typeof(string);

        /// <summary>
        /// BindingDataContract
        /// </summary>
        public IReadOnlyDictionary<string, Type> BindingDataContract => new Dictionary<string, Type>();

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var bindingData = new Dictionary<string, object>();
            var triggerData = new TriggerData(bindingData);

            return Task.FromResult<ITriggerData>(triggerData);
        }

        public async Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            await Task.Run(() => 1);
            return new MongoChangeStreamListener(context.Executor);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new TriggerParameterDescriptor
            {
                Name = "Mongo",
                DisplayHints = new ParameterDisplayHints
                {
                    Prompt = "Mongo",
                    Description = "Mongo message trigger"
                }
            };
        }
    }
}
