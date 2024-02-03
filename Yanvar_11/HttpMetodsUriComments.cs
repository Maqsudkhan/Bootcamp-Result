using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yanvar_11
{
    public class HttpMetodsUriComments
    {

        public static async Task GetAsync(HttpClient httpClient)
        {
            var result = httpClient.GetStringAsync("comments/500");
            Console.WriteLine(result.Result);
        }


        public static async ValueTask<string> PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    postId = 1,
                    id = 2,
                    name = "Name append bo'ldi",
                    email = "Email append bo'ldi",
                    body = "Body append bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("comments", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;

        }


        public static async ValueTask<string> PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    postId = 1,
                    id = 2,
                    name =  "Name UPDATE bo'ldi",
                    email = "Email UPDATE bo'ldi",
                    body = "BODY UPDATE bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync("comments/123", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;

        }


        public static async ValueTask<string> PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    name = "Name UPDATE bo'ldi",
                    email = "Email UPDATE bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("comments/345", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;

        }


        public static async ValueTask<string> DeleteAsync(HttpClient httpClient)
        {

            HttpResponseMessage response = await httpClient.DeleteAsync("comments/456");
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;

        }
    }
}

