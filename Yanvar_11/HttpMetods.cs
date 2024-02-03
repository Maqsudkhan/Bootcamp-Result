using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yanvar_11
{
    public class HttpMetods
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
                    userId = 77,
                    id = 77,
                    title =  "Ttitle appand",
                    body = "body append"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("posts", jsonContent);
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
                    title = "Ttitle update bo'ldi",
                    body = "body update bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync("posts/33", jsonContent);
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
                    body = "body update bo'ldi"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("posts/12", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;

        }


        public static async ValueTask<string> DeleteAsync(HttpClient httpClient)
        {

            HttpResponseMessage response = await httpClient.DeleteAsync("posts/65");
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;

        }
    }
}









