using System.Text.Json;
using Yanvar_11;
public class Program
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
    };

    static async Task Main(string[] args)
    {

        //HttpMetods.GetAsync(sharedClient).Wait();

        Console.WriteLine("\t\t\t\tPosts Urili uchun\n\n");
        Console.WriteLine("yangi ID li malumot qushildi:");
        string result1  = await HttpMetods.PostAsync(sharedClient);
        Console.WriteLine(result1);


        Console.WriteLine("\n\n33 chi ID li malumot (Put bilan) UPDATE bo'ldi:");
        string result2  = await HttpMetods.PutAsync(sharedClient);
        Console.WriteLine(result2);


        Console.WriteLine("\n\n12 chi ID li malumotni UserId si va Body si (Patch bilan) UPDATE bo'ldi:");
        string result3 = await HttpMetods.PatchAsync(sharedClient);
        Console.WriteLine(result3);


        Console.WriteLine("\n\n65 chi ID li malumot DELETE bo'ldi:");
        string result4 = await HttpMetods.DeleteAsync(sharedClient);
        Console.WriteLine(result4);



        Console.WriteLine("\t\t\t\tComments Urili uchun\n\n");
        Console.WriteLine("yangi ID li malumot qushildi:");
        string result5 = await HttpMetodsUriComments.PostAsync(sharedClient);
        Console.WriteLine(result5);

        Console.WriteLine("\n\n123 chi ID li malumot (Put bilan) UPDATE bo'ldi:");
        string result6 = await HttpMetodsUriComments.PutAsync(sharedClient);
        Console.WriteLine(result6);


        Console.WriteLine("\n\n345 chi ID li malumotni Name si va Emaili (Patch bilan) UPDATE bo'ldi:");
        string result7 = await HttpMetodsUriComments.PatchAsync(sharedClient);
        Console.WriteLine(result7);


        Console.WriteLine("\n\n456 chi ID li malumot DELETE bo'ldi:");
        string result8 = await HttpMetodsUriComments.DeleteAsync(sharedClient);
        Console.WriteLine(result8);


        Console.WriteLine("\t\t\t\tAlbums Urili uchun\n\n");
        Console.WriteLine("yangi ID li malumot qushildi:");
        string result9 = await HttpMetodsUrilAlbums.PostAsync(sharedClient);
        Console.WriteLine(result9);

        Console.WriteLine("\n\n10 chi ID li malumot (Put bilan) UPDATE bo'ldi:");
        string result10 = await HttpMetodsUrilAlbums.PutAsync(sharedClient);
        Console.WriteLine(result10);


        Console.WriteLine("\n\n20 chi ID li malumotni Name si va Emaili (Patch bilan) UPDATE bo'ldi:");
        string result11 = await HttpMetodsUrilAlbums.PatchAsync(sharedClient);
        Console.WriteLine(result11);


        Console.WriteLine("\n\n30 chi ID li malumot DELETE bo'ldi:");
        string result12 = await HttpMetodsUrilAlbums.DeleteAsync(sharedClient);
        Console.WriteLine(result12);


        Console.WriteLine("\t\t\t\tPhotos Urili uchun\n\n");
        Console.WriteLine("yangi ID li malumot qushildi:");
        string result13 = await HttpMetodsUrilPhotos.PostAsync(sharedClient);
        Console.WriteLine(result13);

        Console.WriteLine("\n\n1234 chi ID li malumot (Put bilan) UPDATE bo'ldi:");
        string result14 = await HttpMetodsUrilPhotos.PutAsync(sharedClient);
        Console.WriteLine(result14);


        Console.WriteLine("\n\n2345 chi ID li malumotni Title va Url (Patch bilan) UPDATE bo'ldi:");
        string result15 = await HttpMetodsUrilPhotos.PatchAsync(sharedClient);
        Console.WriteLine(result15);


        Console.WriteLine("\n\n3456 chi ID li malumot DELETE bo'ldi:");
        string result16 = await HttpMetodsUrilPhotos.DeleteAsync(sharedClient);
        Console.WriteLine(result16);


        Console.WriteLine("\t\t\t\tTodos Urili uchun\n\n");
        Console.WriteLine("yangi ID li malumot qushildi:");
        string result17 = await HttpMetodsUrilTodos.PostAsync(sharedClient);
        Console.WriteLine(result13);

        Console.WriteLine("\n\n111 chi ID li malumot (Put bilan) UPDATE bo'ldi:");
        string result18 = await HttpMetodsUrilTodos.PutAsync(sharedClient);
        Console.WriteLine(result18);


        Console.WriteLine("\n\n122 chi ID li malumotni Title va UserId (Patch bilan) UPDATE bo'ldi:");
        string result19 = await HttpMetodsUrilTodos.PatchAsync(sharedClient);
        Console.WriteLine(result19);


        Console.WriteLine("\n\n133 chi ID li malumot DELETE bo'ldi:");
        string result20 = await HttpMetodsUrilTodos.DeleteAsync(sharedClient);
        Console.WriteLine(result20);


        Console.WriteLine("\t\t\t\tUsers Urili uchun\n\n");
        Console.WriteLine("yangi ID li malumot qushildi:");
        string result21 = await HttpMetodsUrilUsers.PostAsync(sharedClient);
        Console.WriteLine(result21);

        Console.WriteLine("\n\n5 chi ID li malumot (Put bilan) UPDATE bo'ldi:");
        string result22 = await HttpMetodsUrilUsers.PutAsync(sharedClient);
        Console.WriteLine(result22);


        Console.WriteLine("\n\n6 chi ID li malumotni  (Patch bilan) bazi bir malumotlari UPDATE bo'ldi:");
        string result23 = await HttpMetodsUrilUsers.PatchAsync(sharedClient);
        Console.WriteLine(result23);


        Console.WriteLine("\n\n7 chi ID li malumot DELETE bo'ldi:");
        string result24 = await HttpMetodsUrilUsers.DeleteAsync(sharedClient);
        Console.WriteLine(result24);
    }
}




