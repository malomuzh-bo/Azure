using Azure.Storage.Blobs;

namespace hw0323.Models
{
    public class MyService
    {
        string conn_str = Environment.GetEnvironmentVariable("CUSTOM_OBJECT");
        string path = "home";
        BlobServiceClient bsClient { get; set; }
        BlobContainerClient bcClient { get; set; }
        BlobClient bClient { get; set; }
        public string fileName { get; set; }
        public MyService()
        {
            bsClient = new BlobServiceClient(conn_str);
            createContainer();
        }

        public void createContainer()
        {
            bcClient = new BlobContainerClient(conn_str, path);
        }

        public async Task createItemAsync(string item_name)
        {
            /*string local_path = "/data";
			Directory.CreateDirectory(local_path);
			string fileName = item_name;
			string localFilePath = Path.Combine(local_path, fileName);

			using FileStream fs = File.OpenRead(localFilePath);
			bClient = bcClient.GetBlobClient(fileName);
			await bClient.UploadAsync(fs);
			fs.Close();*/
            fileName = Path.GetFileName(item_name);
            string filePath = Path.Combine(path, fileName);
            bClient = bcClient.GetBlobClient(fileName);
            await bClient.UploadAsync(item_name);
        }
        public async Task getUrl(string photo)
        {

        }
    }
}
