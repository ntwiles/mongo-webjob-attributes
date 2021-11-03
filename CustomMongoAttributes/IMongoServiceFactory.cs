
using MongoDB.Driver;

namespace WebJobs.Extension.Mongo
{
    /// <summary>
    /// Mongo Service factory. Create MongoDB Client and return.
    /// </summary>
    public interface IMongoServiceFactory
    {
        /// <summary>
        /// Create MongoDB Client from connection string
        /// </summary>
        /// <param name="connection">MongoDB Connection string</param>
        /// <returns>Returns MongoClient instance</returns>
        public MongoClient CreateMongoClient(string connection);
    }
}