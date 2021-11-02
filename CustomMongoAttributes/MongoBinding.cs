using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

using WebJobs.Extension.Mongo;

[assembly: WebJobsStartup(typeof(MongoBinding.Startup))]
namespace WebJobs.Extension.Mongo
{
    /// <summary>
    /// Starup object
    /// </summary>
    public class MongoBinding
    {
        /// <summary>
        /// IWebJobsStartup startup class
        /// </summary>
        public class Startup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {
                // Add Mongo extensions
                builder.AddMongoExtension();
            }
        }
    }
}