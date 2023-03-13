using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

Console.WriteLine("Hello, World!");

string conn_str = Environment.GetEnvironmentVariable("CUSTOM_OBJECT");
string contatiner = "containerc6f01c85-75f5-4bcf-a110-4634a7044fe4";

BlobServiceClient bsClient = new BlobServiceClient(conn_str);
BlobContainerClient bcClient = bsClient.GetBlobContainerClient(contatiner);

await bcClient.DeleteAsync();

await foreach (BlobItem item in bcClient.GetBlobsAsync())
{
    Console.WriteLine("Item name: " + item.Name);
    BlobClient bClient = bcClient.GetBlobClient(item.Name);
    //Console.WriteLine(bClient.Name);
    Console.WriteLine("Uri: " + bClient.Uri.AbsoluteUri);
    Console.WriteLine("Content type: " + item.Properties.ContentType);
    Console.WriteLine("Access tier: " + item.Properties.AccessTier.ToString());
}





/*BlobClient bClient = bcClient.GetBlobClient(contatiner);
string path = "/data";
Directory.CreateDirectory(path);
string fileName = "test2.txt";
string filePath = Path.Combine(path, fileName);
if (!File.Exists(filePath))
{
    await File.WriteAllTextAsync(filePath, "Hello, my homie, my braza, Azure 2.0!");
}

await bClient.UploadAsync(filePath);

await foreach (var item in bcClient.GetBlobsAsync())
{
    Console.WriteLine(item.Name);
}

Console.ReadLine();*/
