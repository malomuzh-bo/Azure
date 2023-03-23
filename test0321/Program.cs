using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

Console.WriteLine("Hello, World!");

string endPoint = "https://cog-service-malomuzh.cognitiveservices.azure.com/";
string key = "0ca279656659479aa1a5e75add7473fb";
ComputerVisionClient cvClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endPoint };

string legend = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.3lqcoaNRq2VFtjq0tEHx_gHaIy%26pid%3DApi&f=1&ipt=ded62a73f39ec2332bffac0515b56d5df8cd33170b688f0e96297f664f041276&ipo=images";
string url2 = "https://img.favcars.com/toyota/hilux/images_toyota_hilux_2004_1.jpg";
string car = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.mos.cms.futurecdn.net%2Fzp95CQLBjFR7SDjxAZigeK.jpg&f=1&nofb=1&ipt=734cb199e002ed3ac1cccb167954761edff4129769ecc65ff466fb26d5878119&ipo=images";
string girl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fcdn.ebaumsworld.com%2FmediaFiles%2Fpicture%2F749525%2F80619963.jpg&f=1&nofb=1&ipt=c55231cfa51328eadc43bf5d4cdabd3f8e19e46f496da0927815f552f2b50160&ipo=images";
string url = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2F1.bp.blogspot.com%2F-nOtFipX417A%2FT169Ds1wVBI%2FAAAAAAAAIAM%2FLtu6HbTTR1Y%2Fs1600%2Fdubai_burj_khalifa_268437.jpg&f=1&nofb=1&ipt=3cac68203ab77a8fa929639bb4b2bea9985b443d1b010e2aae664593810e3e48&ipo=images";
string Biden = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F210104155441-joe-biden-1222-file-super-tease.jpg&f=1&nofb=1&ipt=7fee1fbf66b2ceb9fd53396362f3d2ae8a24f71930b82a6703da464a3b2fea83&ipo=images";
string text = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2F3.bp.blogspot.com%2F-thmtvpMNwOM%2FUXHC7RyPFaI%2FAAAAAAAAAbw%2FWzRC0vM0FyI%2Fs1600%2FSlide19.PNG&f=1&nofb=1&ipt=efecd60b5195c81c18ddb4d2666132121e90c548775db6cf6811c91d90b151ec&ipo=images";

List<VisualFeatureTypes?> features = Enum.GetValues(typeof(VisualFeatureTypes)).OfType<VisualFeatureTypes?>().ToList();
//List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() { VisualFeatureTypes.Tags };
ImageAnalysis imgAnalysis = await cvClient.AnalyzeImageAsync(car, features);
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
/*Console.WriteLine("Accent color: " + imgAnalysis.Color.AccentColor);
Console.WriteLine("Foreground color: " + imgAnalysis.Color.DominantColorForeground);
Console.WriteLine("Background color: " + imgAnalysis.Color.DominantColorBackground);
Console.WriteLine("Dominant colors: " + string.Join(", ", imgAnalysis.Color.DominantColors));
Console.WriteLine("Is black-white: " + imgAnalysis.Color.IsBWImg);*/

/****************LANDMARKS****************/
/*foreach (var item in imgAnalysis.Categories)
{
	if (item.Detail?.Landmarks != null)
	{
		foreach (var lmark in item.Detail.Landmarks)
		{
			Console.WriteLine("Name: " + lmark.Name);
			Console.WriteLine("Name: " + lmark.Confidence);
		}
	}
}*/

/****************CELEBRITIES****************/
/*foreach (var item in imgAnalysis.Categories)
{
    if (item.Detail?.Celebrities != null)
    {
        foreach (var lmark in item.Detail.Celebrities)
        {
            Console.WriteLine("Name: " + lmark.Name);
            Console.WriteLine("Name: " + lmark.Confidence);
        }
    }
}*/

/****************TEXT****************/
var result = await cvClient.RecognizePrintedTextAsync(true, text);

foreach (var item in result.Regions)
{
	foreach (var line in item.Lines)
	{
		foreach (var word in line.Words)
		{
            Console.Write(word.Text + " ");
        }
    }
}