using hw0330.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace hw0330.Controllers
{
	public class HomeController : Controller
	{
		List<string> translations = new List<string>();
		List<Language> languages = new List<Language>();
		string key = "19e4ec7e774d4439a4e3f3cd22f88b4e";
		string endPoint = "https://api.cognitive.microsofttranslator.com/";
		public HomeController()
		{
			languages = JsonConvert.DeserializeObject<List<Language>>(System.IO.File.ReadAllText("languages.json"));
		}

		public IActionResult Index()
		{
			ViewBag.languages = languages;
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}
		public async Task<IActionResult> Translate(string text)
		{
			using (HttpClient client = new HttpClient())
			{
				using (HttpRequestMessage hreqMess = new HttpRequestMessage())
				{
					hreqMess.Method = HttpMethod.Post;
					hreqMess.RequestUri = new Uri(endPoint + "translate?api-version=3.0&to=uk&to=pl&to=uz");
					hreqMess.Headers.Add("Ocp-Apim-Subscription-Key", key);
					hreqMess.Headers.Add("Ocp-Apim-Subscription-Region", "switzerlandnorth");

					object[] body = new object[] { new { Text = text } };
					string request = JsonConvert.SerializeObject(body);

					hreqMess.Content = new StringContent(request, Encoding.Unicode, "application/json");

					HttpResponseMessage hresMess = await client.SendAsync(hreqMess).ConfigureAwait(false);
					string result = await hresMess.Content.ReadAsStringAsync();

					Console.WriteLine(result);

					List<Root> roots = JsonConvert.DeserializeObject<List<Root>>(result);

					foreach (Root item in roots)
					{
						Console.WriteLine("Detected language: " + item.detectedLanguage.language.ToString());
						Console.WriteLine("Score: " + item.detectedLanguage.language.ToString());
						foreach (var str in item.translations)
						{
							Console.WriteLine("Translate to " + str.to + ": " + str.text);
						}
					}
				}
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}