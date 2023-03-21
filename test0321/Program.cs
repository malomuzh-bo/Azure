using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

Console.WriteLine("Hello, World!");

string endPoint = "https://cog-service-malomuzh.cognitiveservices.azure.com/";
string key = "0ca279656659479aa1a5e75add7473fb";
ComputerVisionClient cvClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endPoint };

string legend = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/af/Arnold_Schwarzenegger_by_Gage_Skidmore_4.jpg/800px-Arnold_Schwarzenegger_by_Gage_Skidmore_4.jpg";
string url2 = "https://img.favcars.com/toyota/hilux/images_toyota_hilux_2004_1.jpg";
string car = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.mos.cms.futurecdn.net%2Fzp95CQLBjFR7SDjxAZigeK.jpg&f=1&nofb=1&ipt=734cb199e002ed3ac1cccb167954761edff4129769ecc65ff466fb26d5878119&ipo=images";
string girl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fcdn.ebaumsworld.com%2FmediaFiles%2Fpicture%2F749525%2F80619963.jpg&f=1&nofb=1&ipt=c55231cfa51328eadc43bf5d4cdabd3f8e19e46f496da0927815f552f2b50160&ipo=images";
string url = "https://www.hdwallpaper.nu/wp-content/uploads/2015/04/1820411.jpg";

List<VisualFeatureTypes?> features = Enum.GetValues(typeof(VisualFeatureTypes)).OfType<VisualFeatureTypes?>().ToList();
//List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() { VisualFeatureTypes.Tags };
ImageAnalysis imgAnalysis = await cvClient.AnalyzeImageAsync(url, features);
//wow

/****************BRANDS****************/
/*foreach (var item in imgAnalysis.Brands)
{
	Console.WriteLine("Property: " + item.Name);
	Console.WriteLine("Confidence: " + item.Confidence);
	Console.WriteLine("X: " + item.Rectangle.X);
	Console.WriteLine("Y: " + item.Rectangle.Y);
	Console.WriteLine("Width: " + item.Rectangle.W);
	Console.WriteLine("Height: " + item.Rectangle.H + "\n");
}*/

/****************FACES****************/
/*foreach (var item in imgAnalysis.Faces)
{
	Console.WriteLine("Gender: " + item.Gender);
	Console.WriteLine("Age: " + item.Age);
	Console.WriteLine("Top: " + item.FaceRectangle.Top);
	Console.WriteLine("Left: " + item.FaceRectangle.Left);
	Console.WriteLine("Width: " + item.FaceRectangle.Width);
	Console.WriteLine("Height: " + item.FaceRectangle.Height);
}*/

/****************ADULT CONTENT****************/
/*Console.WriteLine("Is adult? " + imgAnalysis.Adult.IsAdultContent);
Console.WriteLine("Is racy? " + imgAnalysis.Adult.IsRacyContent);
Console.WriteLine("Adult score: " + imgAnalysis.Adult.AdultScore);
Console.WriteLine("Racy score: " + imgAnalysis.Adult.RacyScore);*/

/****************COLORS****************/
Console.WriteLine("Accent color: " + imgAnalysis.Color.AccentColor);
Console.WriteLine("Foreground color: " + imgAnalysis.Color.DominantColorForeground);
Console.WriteLine("Background color: " + imgAnalysis.Color.DominantColorBackground);
Console.WriteLine("Dominant colors: " + string.Join(", ", imgAnalysis.Color.DominantColors));
Console.WriteLine("Is black-white: " + imgAnalysis.Color.IsBWImg);