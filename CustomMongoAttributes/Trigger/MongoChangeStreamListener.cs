using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

using MongoDB.Driver;

namespace WebJobs.Extension.Mongo
{
    public class MongoChangeStreamListener : IListener
    {
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly MongoTriggerContext _context;

        /// <summary>
        /// MongoChangeStreamListener constructor
        /// </summary>
        ///
        /// <param name="executor"><c>ITriggeredFunctionExecutor</c> instance</param>
        /// <param name="context"><c>NatsTriggerContext</c> instance</param>
        public MongoChangeStreamListener(ITriggeredFunctionExecutor executor, MongoTriggerContext context)
        {
            _executor = executor;
            _context = context;
        }

        private Task executeFunction(string message)
        {
            var triggerData = new TriggeredFunctionData
            {
                TriggerValue = message
            };

            return _executor.TryExecuteAsync(triggerData, CancellationToken.None);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await executeFunction("Starting Listener");

            using (var cursor = _context.Client.Watch())
            {
                foreach (var change in cursor.ToEnumerable())
                {
                    await executeFunction("Change stream event!");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Cancel any pending operation
        /// </summary>
        public void Cancel()
        {
           
        }

        /// <summary>
        ///  Dispose method
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
