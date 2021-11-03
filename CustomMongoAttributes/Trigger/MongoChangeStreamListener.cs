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

        public Task StartAsync(CancellationToken cancellationToken)
        {

            using (var cursor = _context.Client.Watch())
            {
                foreach (var change in cursor.ToEnumerable())
                {
                    var triggerData = new TriggeredFunctionData
                    {
                        TriggerValue = "[My Triggering Event]"
                    };

                    return _executor.TryExecuteAsync(triggerData, CancellationToken.None);
                }
            }

            return null;
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
