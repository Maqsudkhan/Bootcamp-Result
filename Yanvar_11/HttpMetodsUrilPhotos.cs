using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yanvar_11
{
    public class HttpMetodsUrilPhotos
    {
        public static async Task GetAsync(HttpClient httpClient)
        {
            var result = httpClient.GetStringAsync("photos/5000");
            Console.WriteLine(result.Result);
        }


        public static async ValueTask<string> PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    albumId =  1,
                    id =  3,
                    title =  "Title append",
                    url = "https://via.placeholder.com/600/24f355",
                    thumbnailUrl =  "https://via.placeholder.com/150/24f355"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("photos", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    albumId = 1,
                    id = 3,
                    title = "Title Update",
                    url = "https://via.placeholder.com/100/24f37465545 Update",
                    thumbnailUrl = "https://via.placeholder.com/100/24f88888 Update"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync("photos/1234", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    title = "Title Update",
                    url = "https://via.placeholder.com/100/24f3746589856556 Update"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("photos/2345", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }

        public static async ValueTask<string> DeleteAsync(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("photos/3456");
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }
    }
}
