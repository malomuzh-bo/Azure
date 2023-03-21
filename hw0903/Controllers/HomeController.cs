using hw0903.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Azure.Storage.Queues;
using Azure;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace hw0903.Controllers
{
	public class HomeController : Controller
	{
		string conn_str = "DefaultEndpointsProtocol=https;AccountName=storageidk;AccountKey=A/VMaeuCjtx3sctTfA9L3ZLpEM0iAE3LMfF77ewgq7Kvxtb9RnyNRpbHlpX1xykgRgBPfzcN78ZO+AStU265LQ==;EndpointSuffix=core.windows.net";
		
		[HttpPost]
		public async Task<IActionResult> Index([Bind]Lot lot)
		{
			await Queue.createLot(lot);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			QueueClient qClient = new QueueClient(conn_str, "queuehw0903");
			ViewBag.result = (await qClient.PeekMessagesAsync(maxMessages: 10)).Value.Reverse().ToList();

			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> BuyLot(string id)
		{
			await Queue.delLot(id);

			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}