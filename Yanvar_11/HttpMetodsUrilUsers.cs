using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yanvar_11
{
    public class HttpMetodsUrilUsers
    {
        public static async Task GetAsync(HttpClient httpClient)
        {
            var result = httpClient.GetStringAsync("users/10");
            Console.WriteLine(result.Result);
        }


        public static async ValueTask<string> PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    id = 3,
                    name = "Append name",
                    username = "Append",
                    email = "Append",
                    address = new
                    {
                        street = "Append",
                        suite = "Append",
                        city = "Append",
                        zipcode = "Append",
                        geo = new
                        {
                            lat = "Append",
                            lng = "Append"
                        }
                    },
                    phone = "Append",
                    website = "Append",
                    company = new
                    {
                        name = "Append",
                        catchPhrase = "Appende",
                        bs = "Append"
                    }
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("users", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    id = 3,
                    name = "Update name",
                    username = "Update",
                    email = "Update",
                    address = new
                    {
                        street = "Update",
                        suite = "Update",
                        city = "Update",
                        zipcode = "Update",
                        geo = new
                        {
                            lat = "Update",
                            lng = "Update"
                        }
                    },
                    phone = "Update",
                    website = "Update",
                    company = new
                    {
                        name = "Update",
                        catchPhrase = "Update",
                        bs = "Update"
                    }
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync("users/5", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    id = 3,
                    name = "Update name",
                    email = "Update",
                    address = new
                    {
                        street = "Update",
                        suite = "Update",
                        geo = new
                        {
                            lat = "Update",
                        }
                    },
                    phone = "Update",
                    company = new
                    {
                        name = "Update",
                        bs = "Update"
                    }
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("users/6", jsonContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }

        public static async ValueTask<string> DeleteAsync(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("users/7");
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }
    }
}
