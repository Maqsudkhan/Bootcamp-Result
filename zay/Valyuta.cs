using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace zay
{
    public class Valyuta
    {

    }
}


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

