using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

Console.WriteLine("Hello, World!");

string conn_str = "DefaultEndpointsProtocol=https;AccountName=storageidk;AccountKey=A/VMaeuCjtx3sctTfA9L3ZLpEM0iAE3LMfF77ewgq7Kvxtb9RnyNRpbHlpX1xykgRgBPfzcN78ZO+AStU265LQ==;EndpointSuffix=core.windows.net";

QueueServiceClient qsClient = new QueueServiceClient(conn_str);
QueueClient qClient = qsClient.GetQueueClient("queueidk");

await qClient.SendMessageAsync("Yo");
await qClient.SendMessageAsync("It's");
await qClient.SendMessageAsync("Me");

List<QueueMessage> messages = new List<QueueMessage>();
Response<QueueMessage[]> response = await qClient.ReceiveMessagesAsync(maxMessages: 3, visibilityTimeout: TimeSpan.FromSeconds(1));

foreach (QueueMessage item in response.Value)
{
	UpdateReceipt upd = await qClient.UpdateMessageAsync(item.MessageId, item.PopReceipt, item.Body.ToString(), visibilityTimeout: TimeSpan.FromSeconds(5));
	messages.Add(item.Update(upd));
}

Task.Delay(5000).Wait();

foreach (QueueMessage item in messages)
{
    Console.WriteLine("Message id: " + item.MessageId);
    Console.WriteLine("Message: " + item.Body.ToString());
    Console.WriteLine("Inserted: " + item.InsertedOn.ToString());
    Console.WriteLine("Dequeue count: " + item.DequeueCount.ToString() + "\n");

	await qClient.DeleteMessageAsync(item.MessageId, item.PopReceipt);
}














//SendReceipt sr = await qClient.SendMessageAsync("Hello, my homie from Ghetto", timeToLive: new TimeSpan(0, 0, -1));
//SendReceipt sr = await qClient.SendMessageAsync("Welcome to the club", TimeSpan.FromMinutes(17));

//
/*foreach (PeekedMessage item in (await qClient.PeekMessagesAsync(maxMessages: 3)).Value)
{
	Console.WriteLine("Message id: " + item.MessageId);
	Console.WriteLine("Message: " + item.Body.ToString());
	Console.WriteLine("Inserted: " + item.InsertedOn.ToString());
	Console.WriteLine("Dequeue count: " + item.DequeueCount.ToString() + "\n");
}*/

/*QueueMessage[] arr = (await qClient.ReceiveMessagesAsync(maxMessages: 2)).Value;

await qClient.DeleteMessageAsync(arr[1].MessageId, arr[1].PopReceipt);
foreach (QueueMessage item in arr)
{
	Console.WriteLine("Message id: " + item.MessageId);
	Console.WriteLine("Message: " + item.Body.ToString());
	Console.WriteLine("Pop receipt: " + item.PopReceipt);
	Console.WriteLine("Dequeue count: " + item.DequeueCount.ToString() + "\n");
}*/



//драматична пауза
//тут могла бути ваша реклама, але буде моя
//зара шось придумаю, якщо встигну
//setx parameter_name(CAPS)
//коротше, реклама
//ви готові?
//не готовий я
//і так, у мене є 

/*QueueClient qClient2 = qsClient.GetQueueClient("del_queue");
await qClient2.DeleteIfExistsAsync();*/