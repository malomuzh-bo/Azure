// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Storage.Blobs;

Console.WriteLine("Hello, World!");

string conn_str = "DefaultEndpointsProtocol=https;AccountName=storagemalomuzh;AccountKey=ZH6CedAdgB61TULsTCXuXNDlzD6FnHp2Q5eoXNBoAfv0z2BuqA3Db7+yyi+y+m/y3u5G5YC6+aUp+ASti6ihaQ==;EndpointSuffix=core.windows.net";

BlobServiceClient bsClient = new BlobServiceClient(conn_str);
string container = "container" + Guid.NewGuid().ToString();

string local_path = "./data";
Directory.CreateDirectory(local_path);

await File.WriteAllTextAsync(Path.Combine(local_path, fileName), "Hello, my homie, my braza, Azure!");

BlobContainerClient bcClient = await bsClient.CreateBlobContainerAsync(container);
BlobClient bClient = bcClient.GetBlobClient(fileName);

await bClient.UploadAsync(Path.Combine(local_path, fileName));


await foreach (var item in bcClient.GetBlobsAsync())
{
    Console.WriteLine(item.Name);
}

Console.ReadLine();