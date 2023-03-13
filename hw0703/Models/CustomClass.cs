using Azure.Storage.Blobs;

namespace hw0703.Models
{
	public class CustomClass
	{
		string conn_str;
		BlobServiceClient bsClient;
		BlobContainerClient bcClient;
		BlobClient bClient;
		public CustomClass()
		{
			conn_str = Environment.GetEnvironmentVariable("CUSTOM_OBJECT");
			bsClient = new BlobServiceClient(conn_str);
		}

		public async void createContainerAsync(string c_name)
		{
			bcClient = await bsClient.CreateBlobContainerAsync(c_name);
		}

		public async void createItemAsync(string item_name)
		{
            string local_path = "/data";
			Directory.CreateDirectory(local_path);
			string fileName = item_name;
			string localFilePath = Path.Combine(local_path, fileName);

			using FileStream fs = File.OpenRead(localFilePath);
			bClient = bcClient.GetBlobClient(fileName);
			await bClient.UploadAsync(fs);
			fs.Close();
		}
	}
}
