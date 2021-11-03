using MongoDB.Driver;

namespace WebJobs.Extension.Mongo
{
    /// <summary>
    /// MongoDB Service Factory, responsible for creating MongoClient
    /// </summary>
    public class MongoServiceFactory : IMongoServiceFactory
    {
        /// <summary>
        /// Create Nats Client from connection string
        /// </summary>
        /// <param name="connection">Connection String</param>
        /// <returns>Returns NatsClient</returns>
        public MongoClient CreateMongoClient(string connection)
        {
            return new MongoClient(connection);
        }
    }
}