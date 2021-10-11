using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace CustomMongoAttributes
{
    public class MongoTriggerBinding : ITriggerBinding
    {
        public Type TriggerValueType => throw new NotImplementedException();

        public IReadOnlyDictionary<string, Type> BindingDataContract => throw new NotImplementedException();

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            return new MongoChangeStreamListener(context.Executor);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            throw new NotImplementedException();
        }
    }
}
