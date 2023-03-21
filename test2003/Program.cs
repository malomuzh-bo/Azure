using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

var builder = new HostBuilder();
builder.ConfigureWebJobs(q => { q.AddAzureStorageCoreServices(); q.AddAzureStorage(); });
//wow
builder.ConfigureLogging((q, a) => 
{
	a.AddConsole();
	string key = q.Configuration["AzureWebJobsStorage"]; 
});
var host = builder.Build();

using (host)
{
	host.Run();


}