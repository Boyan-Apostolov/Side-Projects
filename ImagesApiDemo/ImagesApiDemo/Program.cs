
using ImagesApiDemo;
using Newtonsoft.Json;
using System.Net;

Console.Write("Enter keyword to download: ");
var keyword = Console.ReadLine();

Console.Write("Enter number of images to download: ");
var numberOfImages = int.Parse(Console.ReadLine());

string API = $"https://api.pexels.com/v1/search/?per_page={numberOfImages}&query={keyword}";
const string API_KEY = "563492ad6f9170000100000191c82e20b6e64c6a9c8c062728ea86ec";

var images = await GetImagesFromAPI(API, API_KEY);

Console.WriteLine($"Found {images.Per_Page} images...");

var path = Directory.GetCurrentDirectory() + @"\Images";
Directory.CreateDirectory(path);

foreach (var imageItem in images.Photos)
{
    var fileName = imageItem.Alt.Trim().Replace(" ", "_");

    using (WebClient client = new WebClient())
    {
        client.DownloadFile(new Uri(imageItem.Src.Original), @$"{path}\{fileName}.jpeg");
    }

    Console.WriteLine($"Downloaded -> {fileName}");
}

async Task<Images> GetImagesFromAPI(string API, string API_KEY)
{
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", API_KEY);

    var page = await client.GetAsync(API);

    string imagesInfoAsString = await page.Content.ReadAsStringAsync();

    var parsedImages = JsonConvert.DeserializeObject<Images>(imagesInfoAsString);

    return parsedImages;
}