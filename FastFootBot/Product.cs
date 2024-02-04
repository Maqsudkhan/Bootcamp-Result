using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Text.Json;


namespace FastFootBot
{
    public class Product
    {
        public string Product_name { get; set; }

        private static string path = @"D:\BFN\.Net\C#\FastFootBot\Product.json";

        public static void Add(Product product)
        {
            List<Product> list = DeserilizeSerelizeProduct<Product>.GetAll(path);
            foreach (var u in list)
            {
                if (u.Product_name == product.Product_name)
                {
                    return;
                }
            }
            list.Add(product);
            DeserilizeSerelizeProduct<Product>.Save(list, path);
        }

        public static string ShowAll()
        {
            StringBuilder sb = new StringBuilder();
            List<Product> list = DeserilizeSerelizeProduct<Product>.GetAll(path);
            foreach (Product u in list)
            {
                sb.Append($"Product name → {u.Product_name}\n\n");
            }
            return sb.ToString().ToLower();
        }

        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string PayTaype_name, string new_name)
        {
            List<Product> list = DeserilizeSerelizeProduct<Product>.GetAll(path);
            int index = list.FindIndex(us => us.Product_name == PayTaype_name);
            Console.WriteLine(index);
            if (index != -1)
            {
                list[index].Product_name = new_name;
                DeserilizeSerelizeProduct<Product>.Save(list, path);
            }
            else if (index == -1)
            {
                await botClient.SendTextMessageAsync(
                     chatId: update.Message!.Chat.Id,
                     text: "Siz mavjud bo'lmagan ma'lumot kiritdingiz❗❗❗",
                     replyMarkup: ButtonController.AdminButton
                 );
            }
            // Ma'lumotlarni to'g'ri kiriting!\nMisol: {eski ma'lumor}, {yangi ma'lumot}
        }
        public static void Delete(string Prodct)
        {
            List<Product> list = DeserilizeSerelizeProduct<Product>.GetAll(path);
            int index = list.FindIndex(us => us.Product_name == Prodct.ToLower());

            if (index != -1)
            {
                list.RemoveAt(index);
                DeserilizeSerelizeProduct<Product>.Save(list, path);
            }
        }
    }

    class DeserilizeSerelizeProduct<T>
    {
        public static List<T> GetAll(string path)
        {
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                return new List<T>();
            }
        }

        public static void Save(List<T> lst, string path)
        {
            string json = JsonSerializer.Serialize(lst);
            System.IO.File.WriteAllText(path, json);
        }


    }


}

