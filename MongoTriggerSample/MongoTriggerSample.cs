﻿
using CustomMongoAttributes;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MongoTriggerSample
{
    public static class MongoTriggerSample
    {
        [FunctionName("MongoTriggerSample")]
        public static void Run(
            [MongoTrigger(Connection = "MongoConnection", QueueGroup = "SampleGroup")] string message,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}

