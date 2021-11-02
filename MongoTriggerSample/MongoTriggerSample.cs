using System;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using WebJobs.Extension.Mongo;

namespace MongoTriggerSample
{
    public static class MongoTriggerSample
    {
        [FunctionName("MongoTriggerSample")]
        public static void Run(
            [MongoTrigger(Connection = "MongoConnection", QueueGroup = "SampleGroup")] string message)
        {
            Console.WriteLine($"Function Triggered: {message}");
        }
    }
}
