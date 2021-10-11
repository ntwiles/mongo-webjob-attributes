using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace CustomMongoAttributes
{
    /// <summary>
    /// WebJobBuilder extension to add Mongo Change Stream watcher extensions
    /// </summary>
    public static class MongoWebJobsBuilderExtensions
    {
        /// <summary>
        /// Extension method to add our custom extensions
        /// </summary>
        /// <param name="builder"><c>IWebJobsBuilder</c> instance</param>
        /// <returns><c>IWebJobsBuilder</c> instance</returns>
        /// <exception>Throws ArgumentNullException if builder is null</exception>
        public static IWebJobsBuilder AddMongoExtension(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<MongoExtensionConfigProvider>();
            // TODO: Replace this.
            //builder.Services.AddSingleton<INatsServiceFactory, NatsServiceFactory>();

            return builder;
        }
    }
}
