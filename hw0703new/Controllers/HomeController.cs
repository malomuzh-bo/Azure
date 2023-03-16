using hw0703new.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hw0703new.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public CustomClass custom = new CustomClass();
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddItemAsync(IFormFile fileName)
		{
			var items = Request.Form.Files;
			if (items.Count > 0)
			{
				string folder = $@"{Directory.GetCurrentDirectory()}\wwwroot\img";
				Directory.CreateDirectory(folder);
				string filePath = Path.Combine(folder, items[0].Name);
				using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
				{
					items[0].CopyTo(fs);
				}
				await custom.createItemAsync(filePath);
			}
			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}