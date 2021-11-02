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
        /// <c>NatsClient</c> instance to connect and subscribe to NATS
        /// </summary>
        public string Client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attribute">Attribute instnace</param>
        /// <param name="client">NatsClient instance</param>
        public MongoTriggerContext(MongoTriggerAttribute attribute, string client)
        {
            this.TriggerAttribute = attribute;
            this.Client = client;
        }
    }
}