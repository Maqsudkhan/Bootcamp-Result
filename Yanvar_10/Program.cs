using System.Text.Json;

HttpClient httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json");
var response = httpClient.SendAsync(request).Result;
var body = response.Content.ReadAsStringAsync().Result;
var courses = JsonSerializer.Deserialize<List<Valyuta>>(body);

Console.Write("Qaysi pul birligidan: ");
string item1 = Console.ReadLine();
Console.Write("Pul miqdorini kiriting: ");
double item2 = double.Parse(Console.ReadLine());
Console.Write("Qaysi pul birligiga: ");
string item3 = Console.ReadLine();  
if (item1 == item3)
{
    Console.WriteLine($"{item2} {item1} = {item2} {item3}");
}
else
{
    if (item1 == "UZS")
    {
        foreach (var c1 in courses)
        {
            if (item3 == c1.code.ToString())
            {
                Console.WriteLine($"{item2} {item1} = {item2 / double.Parse(c1.cb_price)} {item3}");
                return;
            }
        }
    }
    else
    {
        foreach (var c in courses)
        {
            if (item1 == c.code.ToString())
            {
                double item_1 = item2 * double.Parse(c.cb_price);

                foreach (var c1 in courses)
                {
                    if (item3 == c1.code.ToString())
                    {
                        double item_3 = item_1 / double.Parse(c1.cb_price);
                        Console.WriteLine($"{item2} {item1} = {item_3} {item3}");
                        return;
                    }
                    if (item1 == c1.code.ToString() && item3 == "UZS")
                    {
                        Console.WriteLine($"{item2} {item1} = {double.Parse(c.cb_price) * item2} {item3}");
                        return;
                    }
                }
            }
        }
    }
}
public class Valyuta
{
    public string title { get; set; }
    public string code { get; set; }
    public string cb_price { get; set; }
    public string nbu_buy_price { get; set; }
    public string nbu_cell_price { get; set; }
    public string date { get; set; }
}










/*

HttpClient httpClientTwo = new HttpClient();

Console.Write("Kino nomini kiriting: ");
string kinoName = Console.ReadLine();
string FullApiName = "https://www.omdbapi.com/?t=" + kinoName + "&apikey=d21b5d09";
var request = new HttpRequestMessage(HttpMethod.Get, FullApiName);
var response = httpClientTwo.SendAsync(request).Result;
var body = response.Content.ReadAsStringAsync().Result;

var informations = JsonSerializer.Deserialize<Root>(body);
Console.WriteLine();
Console.WriteLine($"\tTitle: {informations.Title}");
Console.WriteLine($"\tYear: {informations.Year}");
Console.WriteLine($"\tRated: {informations.Rated}");
Console.WriteLine($"\tReleased: {informations.Released}");
Console.WriteLine($"\tRuntime: {informations.Runtime}");
Console.WriteLine($"\tGenre: {informations.Genre}");
Console.WriteLine($"\tDirector: {informations.Director}");
Console.WriteLine($"\tWriter: {informations.Writer}");
Console.WriteLine($"\tActors: {informations.Actors}");
Console.WriteLine($"\tPlot: {informations.Plot}");
Console.WriteLine($"\tLanguage: {informations.Language}");
Console.WriteLine($"\tCountry: {informations.Country}");
Console.WriteLine($"\tAwards: {informations.Awards}");
Console.WriteLine($"\tPoster: {informations.Poster}");

foreach (var i in informations.Ratings)
{
    Console.WriteLine($"\tSource: {i.Source}");
    Console.WriteLine($"\tSource: {i.Value}");
}
Console.WriteLine($"\tMetascore: {informations.Metascore}");
Console.WriteLine($"\timdbRating: {informations.imdbRating}");
Console.WriteLine($"\timdbVotes: {informations.imdbVotes}");
Console.WriteLine($"\timdbID: {informations.imdbID}");
Console.WriteLine($"\tType: {informations.Type}");
Console.WriteLine($"\tDVD: {informations.DVD}");
Console.WriteLine($"\tBoxOffice: {informations.BoxOffice}");
Console.WriteLine($"\tProduction: {informations.Production}");
Console.WriteLine($"\tWebsite: {informations.Website}");
Console.WriteLine($"\tResponse: {informations.Response}");






public class Rating
{
    public string Source { get; set; }
    public string Value { get; set; }
}
public class Root
{
    public string Title { get; set; }
    public string Year { get; set; }
    public string Rated { get; set; }
    public string Released { get; set; }
    public string Runtime { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Actors { get; set; }
    public string Plot { get; set; }
    public string Language { get; set; }
    public string Country { get; set; }
    public string Awards { get; set; }
    public string Poster { get; set; }
    public List<Rating> Ratings { get; set; }
    public string Destination { get; set; }
    public string Metascore { get; set; }
    public string imdbRating { get; set; }
    public string imdbVotes { get; set; }
    public string imdbID { get; set; }
    public string Type { get; set; }
    public string DVD { get; set; }
    public string BoxOffice { get; set; }
    public string Production { get; set; }
    public string Website { get; set; }
    public string Response { get; set; }
}




*/