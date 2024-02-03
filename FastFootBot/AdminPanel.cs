//using System.Text.Json;
//using Telegram.Bot;
//using Telegram.Bot.Types;

//namespace FastFootBot
//{
//    public static class AdminPanel
//    {
//        public static string path_users = "D:\\BFN\\.Net\\C#\\FastFootBot\\Users.json";

//        public static string path_admins = "D:\\BFN\\.Net\\C#\\FastFootBot\\Admins.json";

//        public static async Task RunPanel(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, int isPushCRUD, int isPushCategory)
//        {
//            if (update.Message is not { } message) return;
//            if (message.Text == "Admin append👨🏻‍💻")
//            {
//                await botClient.SendTextMessageAsync(
//                chatId: message.Chat.Id,
//                text: "Yangi Adminning Chat Idsini kiriting❗");
//            }
//            if (message.Text!.Length == 10 && Convert.ToInt64(message.Text).GetType() == typeof(Int64))
//            {
//                await findUserAndAddAdmin(botClient, update, cancellationToken, message.Text);
//            }


//            if (isPushCategory == 1)
//            {
//                if (message.Text == "Create✔️")
//                {
//                    isPushCRUD = 1;
//                    return;
//                }
//                else if (message.Text == "Update🔄️")
//                {
//                    isPushCRUD = 2;
//                    return;
//                }
//                else if (message.Text == "Delate❌")
//                {
//                    isPushCRUD = 3;
//                    return;
//                }
//                else if (message.Text == "Show all✅")
//                {
//                    isPushCRUD = 4;
//                }
//                if (isPushCRUD == 1)
//                {
//                    Category.Add(new Category()
//                    {
//                        Category_name = message.Text!
//                    });
//                }
//                else if (isPushCRUD == 2)
//                {
//                    string[] str = message.Text.Split(", ");
//                    Category.Update(str[0], str[1]);
//                }
//                else if (isPushCRUD == 3)
//                {
//                    Category.Delete(message.Text);
//                }
//                else if (isPushCRUD == 4)
//                {
//                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: Category.ShowAll(), cancellationToken: cancellationToken);
//                }
//            }
//            if (message.Text == "Category✅")
//            {
//                isPushCategory = 1;


//                await botClient.SendTextMessageAsync(
//                chatId: message.Chat.Id,
//                text: "Buttonlardan birini bosing!",
//                replyMarkup: ButtonController.CRUD);
//                return;
//            }
//        }


//        public static async Task findUserAndAddAdmin(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string givenId)
//        {
//            //if (update.Message is not { } message) return;
//            string txt;

//            using (StreamReader reader = new StreamReader(path_users))
//            {
//                txt = reader.ReadToEnd();
//            }
//            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
//            foreach (Person person in persons)
//            {
//                if (person.id == Convert.ToInt64(givenId))
//                {
//                    //await AddAdminToJsonFile(new Person() { id = person.id, Name = person.Name, Phone_Number = person.Phone_Number });
//                    AddAdminToJsonFile(person);
//                    await botClient.SendTextMessageAsync(
//                    chatId: update.Message!.Chat.Id,
//                    text: "Admin muvofaqqiyatli qo'shildi✅");
//                    return;
//                }
//            }
//            await botClient.SendTextMessageAsync(
//                chatId: update.Message!.Chat.Id,
//                text: $"Bunday CHat Id li User topilmadi❗");
//        }
//        public static async Task AddAdminToJsonFile(Person person)
//        {
//            string txt;
//            using (StreamReader reader = new StreamReader(path_admins))
//            {
//                txt = reader.ReadToEnd();
//            }
//            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
//            persons!.Add(person);
//            using (StreamWriter sw = new StreamWriter(path_admins))
//            {
//                string newData = JsonSerializer.Serialize(persons);
//                sw.Write(newData);
//            }
//        }
//    }
//}
