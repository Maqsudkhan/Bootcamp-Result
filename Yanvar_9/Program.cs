using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
/*
string path = "D:\\BFN\\.Net\\C#\\Yanvar_9\\New_json.json";
string word;
using(StreamReader sr = new StreamReader(path))
{
    word = sr.ReadToEnd();
}
List<Roots> root = JsonConvert.DeserializeObject<List<Roots>>(word);

foreach(var i in root)
{
    Console.WriteLine($"UserId: {i.userId}\nid: {i.id}\ntitle: {i.title}\nbody: {i.body}\n\n");
}


public class Roots
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }

}
*/






/*
string path = "D:\\BFN\\.Net\\C#\\Yanvar_9\\exemple2.json";
string word;
using (StreamReader sr = new StreamReader(path))
{
    word = sr.ReadToEnd();
}
List<Root> root = JsonConvert.DeserializeObject<List<Root>>(word);

foreach (var i in root)
{
    if (i.title != "")
    {
        Console.WriteLine($"UserId: {i.userId}\nid: {i.id}\ntitle: {i.title}\nbody: {i.body}\n\n");
    }
}
public class Root
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}
*/








string path = "D:\\BFN\\.Net\\C#\\Yanvar_9\\exemple3.json";
string data;
using (StreamReader sr = new StreamReader(path))
{
    data = sr.ReadToEnd();
}
JArray obj = JArray.Parse(data)!;

foreach (JObject i in obj)
{
    if ((int)i["id"] == 0 ) i.Remove("id");
    if(i["title"].ToString() == "") i.Remove("title");
    if(i["body"].ToString() == "") i.Remove("body");
}

foreach (var j in obj) Console.WriteLine(j);
public class Root
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}












