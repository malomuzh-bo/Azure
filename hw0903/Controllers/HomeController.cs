using hw0903.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Azure.Storage.Queues;
using Azure;
using Azure.Storage.Queues.Models;

namespace hw0903.Controllers
{
	public class HomeController : Controller
	{
		[HttpPost]
		public async Task<IActionResult> Index([Bind]Lot lot)
		{
			await Queue.createLot(lot);
			return View();
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}