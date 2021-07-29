using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionKubernetes
{
    public static class QueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public static void Run([QueueTrigger("myqueue", Connection = "")] QueueData myQueueItem,
        [Blob("accepted-data/{rand-guid}")] out string acceptedData,
        [Blob("rejected-data/{rand-guid}")] out string rejectedData,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            acceptedData = null;
            rejectedData = null;

            try
            {
                if (myQueueItem.Id >= 1)
                {
                    acceptedData = JsonConvert.SerializeObject(myQueueItem);
                }
                else
                {
                    rejectedData = JsonConvert.SerializeObject(myQueueItem);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
