using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using test0330.Classes;

Console.WriteLine("Hello, World!");

string key = "19e4ec7e774d4439a4e3f3cd22f88b4e";
string endPoint = "https://api.cognitive.microsofttranslator.com/";
string text = "You are really cool programmers and I hope that you'll do your fucking best to realize all your potential!";
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

        Console.WriteLine("\n\n");

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