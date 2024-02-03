using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yanvar_11
{
    public class HttpMetodsUrilTodos
    {
        public static async Task GetAsync(HttpClient httpClient)
        {
            var result = httpClient.GetStringAsync("todos/200");
            Console.WriteLine(result.Result);
        }


        public static async ValueTask<string> PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId =  1,
                    id = 7,
                    title = "Title Append",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("todos", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId = 11111,
                    id = 22,
                    title = "Title Update",
                    completed = true
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync("todos/111", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId = 10000,
                    title = "Title Update"
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("todos/122", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }

        public static async ValueTask<string> DeleteAsync(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("todos/133");
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }
    }
}
