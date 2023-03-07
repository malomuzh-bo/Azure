using Azure.Storage.Blobs;

Console.WriteLine("Hello, World!");

string conn_str = Environment.GetEnvironmentVariable("CUSTOM_OBJECT");
string contatiner = "containerc6f01c85-75f5-4bcf-a110-4634a7044fe4";

BlobServiceClient bsClient = new BlobServiceClient(conn_str);
BlobContainerClient bcClient = bsClient.GetBlobContainerClient(contatiner);
BlobClient bClient = bcClient.GetBlobClient(contatiner);

/*string path = "/data";
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
}*/

Console.ReadLine();
