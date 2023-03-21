using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace hw0903.Models
{
    public static class Queue
    {
        static string conn_str = "DefaultEndpointsProtocol=https;AccountName=storageidk;AccountKey=A/VMaeuCjtx3sctTfA9L3ZLpEM0iAE3LMfF77ewgq7Kvxtb9RnyNRpbHlpX1xykgRgBPfzcN78ZO+AStU265LQ==;EndpointSuffix=core.windows.net";
        static QueueServiceClient qsClient = new QueueServiceClient(conn_str);
		static async Task<QueueClient> GetQueueClientAsync()
        {
            try
            {
                return await qsClient.CreateQueueAsync("queuehw0903");
            }
            catch (Exception)
            {
                return qsClient.GetQueueClient("queuehw0903");
            }
        }

        public static async Task createLot(Lot lot)
        {
            lot.Id = Guid.NewGuid().ToString();
            string message = JsonConvert.SerializeObject(lot);
            await (await GetQueueClientAsync()).SendMessageAsync(message);
        }
        public static async Task delLot(string id)
        {
            var arr = (await (await GetQueueClientAsync()).ReceiveMessagesAsync(maxMessages: 10, visibilityTimeout: TimeSpan.FromSeconds(1))).Value;
            var message = arr.Where(q => q.MessageId.Equals(id)).First();
            await (await GetQueueClientAsync()).DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }
        public static async Task<PeekedMessage[]> getLots()
        {
            return (await (await GetQueueClientAsync()).PeekMessagesAsync(maxMessages: 10)).Value;
        }
    }
}
