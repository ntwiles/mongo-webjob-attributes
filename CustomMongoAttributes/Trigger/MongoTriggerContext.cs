using MongoDB.Driver;

namespace WebJobs.Extension.Mongo
{
    /// <summary>
    /// Trigger context class
    /// </summary>
    public class MongoTriggerContext
    {
        /// <summary>
        /// <c>Attribute</c> instance
        /// </summary>
        public MongoTriggerAttribute TriggerAttribute;

        /// <summary>
        /// <c>MongoClient</c> instance to connect to MongoDB.
        /// </summary>
        public MongoClient Client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attribute">Attribute instance</param>
        /// <param name="client">MongoClient instance</param>
        public MongoTriggerContext(MongoTriggerAttribute attribute, MongoClient client)
        {
            this.TriggerAttribute = attribute;
            this.Client = client;
        }
    }
}