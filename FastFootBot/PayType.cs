using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Text.Json;
using Telegram.Bot;

namespace FastFootBot
{
    public class PayType
    {
        public string Paytype_name { get; set; }

        private static string path = @"D:\BFN\.Net\C#\FastFootBot\PayType.json";

        public static void Add(PayType pt)
        {
            List<PayType> list = DeserilizeSerelize<PayType>.GetAll(path);
            foreach (var u in list)
            {
                if (u.Paytype_name == pt.Paytype_name)
                {
                    return;
                }
            }
            list.Add(pt);
            DeserilizeSerelize<PayType>.Save(list, path);
        }

        public static string ShowAll()
        {
            StringBuilder sb = new StringBuilder();
            List<PayType> list = DeserilizeSerelize<PayType>.GetAll(path);
            foreach (PayType u in list)
            {
                sb.Append($"Pay Type name → {u.Paytype_name}\n\n");
            }
            return sb.ToString().ToLower();
        }

        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string PayTaype_name, string new_name)
        {
            List<PayType> list = DeserilizeSerelize<PayType>.GetAll(path);
            int index = list.FindIndex(us => us.Paytype_name == PayTaype_name);
            Console.WriteLine(index);
            if (index != -1)
            {
                list[index].Paytype_name = new_name;
                DeserilizeSerelize<PayType>.Save(list, path);
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
        public static void Delete(string Paytyp)
        {
            List<PayType> list = DeserilizeSerelize<PayType>.GetAll(path);
            int index = list.FindIndex(us => us.Paytype_name == Paytyp.ToLower());

            if (index != -1)
            {
                list.RemoveAt(index);
                DeserilizeSerelize<PayType>.Save(list, path);
            }
        }
    }

    class DeserilizeSerelize<T>
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
