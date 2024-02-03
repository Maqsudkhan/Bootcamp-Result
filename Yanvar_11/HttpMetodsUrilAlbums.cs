using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yanvar_11
{
    public class HttpMetodsUrilAlbums
    {
        public static async Task GetAsync(HttpClient httpClient)
        {
            var result = httpClient.GetStringAsync("posts/100");
            Console.WriteLine(result.Result);
        }


        public static async ValueTask<string> PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId = 1,
                    id = 1,
                    title = "Ttitle appand",
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("albums", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId = 999999,
                    id = 100,
                    title = "Ttitle update bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync("albums/10", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId = 123456,
                    title = "body update bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("albums/20", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }

        public static async ValueTask<string> DeleteAsync(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("albums/30");
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }
    }
}
