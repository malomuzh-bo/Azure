using hw0323.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hw0323.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        string text = "https://storageidk.blob.core.windows.net/images0323/image_2023-03-23_20-43-24.png";
        string landmark = "https://storageidk.blob.core.windows.net/images0323/image_2023-03-23_21-00-05.png";
        string celebrity = "https://storageidk.blob.core.windows.net/images0323/Jay-Z_@_Shawn_'Jay-Z'_Carter_Foundation_Carnival_(crop_2).jpg";
        string alcohol = "https://storageidk.blob.core.windows.net/images0323/theme_liquor_alcohol_bottle-shutterstock-portfolio_703929226-scaled-3469097587.jpg";
        MyService custom = new MyService();
        List<string> imgs = new List<string>();

        public HomeController(ILogger<HomeController> logger)
        {
            imgs.Add(landmark);
            imgs.Add(celebrity);
            imgs.Add(alcohol);
            imgs.Add(text);

            _logger = logger;
            ViewBag.images = imgs;
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
		public async Task<IActionResult> AddPhotoAsync(IFormFile fileName)
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