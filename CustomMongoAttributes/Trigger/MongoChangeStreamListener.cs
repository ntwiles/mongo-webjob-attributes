using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace WebJobs.Extension.Mongo
{
    public class MongoChangeStreamListener : IListener
    {
        private readonly ITriggeredFunctionExecutor _executor;

        /// <summary>
        /// MongoChangeStreamListener constructor
        /// </summary>
        ///
        /// <param name="executor"><c>ITriggeredFunctionExecutor</c> instance</param>
        public MongoChangeStreamListener(ITriggeredFunctionExecutor executor)
        {
            _executor = executor;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var triggerData = new TriggeredFunctionData
            {
                TriggerValue = "[My Triggering Event]"
            };

            return _executor.TryExecuteAsync(triggerData, CancellationToken.None);
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
