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

        // TODO: Finish me.
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var triggerData = new TriggeredFunctionData
            {
                TriggerValue = "foo"
            };

            return _executor.TryExecuteAsync(triggerData, CancellationToken.None);
            // task.Wait()
        }

        // TODO: Finish me.
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                // _context.Client.Disconnect();
            });
        }

        /// <summary>
        /// Cancel any pending operation
        /// </summary>
        public void Cancel()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///  Dispose method
        /// </summary>
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
