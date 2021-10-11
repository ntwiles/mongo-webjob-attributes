using System;
using Microsoft.Azure.WebJobs.Description;

namespace CustomMongoAttributes
{
    /// <summary>
    /// <c>Attribute</c> class for Trigger
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    class MongoTriggerAttribute : Attribute
    {
        public string Connection { get; set; }
        public string QueueGroup { get; set; }

        // <summary>
        // Helper method to get connection string from environment variables
        // </summary>
        internal string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable(Connection);
        }
    }
}
