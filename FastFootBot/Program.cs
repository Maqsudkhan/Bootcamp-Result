using FastFootBot;
using System.Text;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6376249120:AAHsdY4LlnPoScWrjY-eZCUFz3CqU5AOrpw");

var path_users = "D:\\BFN\\.Net\\C#\\FastFootBot\\Users.json";
var path_admins = "D:\\BFN\\.Net\\C#\\FastFootBot\\Admins.json";

int isPushCategory = 0;
int isPushPayType = 0;
int isPushCRUD = 0;
using CancellationTokenSource cts = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};


botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);


var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();


cts.Cancel();
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Task handler = update.Type switch
    {
        UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
        _ => HandleUnknownUpdateType(botClient, update, cancellationToken),
    };
    try
    {
        await handler;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error chiqdi:{ex.Message}");
    }
}
async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Message message = update.Message!;
    Console.WriteLine($"Received a '{message!.Text}' message in chat {message.Chat.Id}. UserName =>  {message.Chat.Username}");

    if (message.Text == "/start" && CheckAdminId(update.Message!.Chat.Id))
    {
        await botClient.SendTextMessageAsync(
             chatId: message.Chat.Id,
             text: "Buttonlardan birini bosing!",
             replyMarkup: ButtonController.AdminButton);
    }

    if (CheckAdminId(message.Chat.Id))
    {
        if (message.Text == "Admin append👨🏻‍💻")
        {
            await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Yangi Adminning Chat Idsini kiriting❗");
        }
        if (message.Text!.Length == 10 && Convert.ToInt64(message.Text).GetType() == typeof(Int64))
        {
            await findUserAndAddAdmin(message.Text, update);
        }


        if (isPushCategory == 1)
        {
            if (message.Text == "Create✔️")
            {
                isPushCRUD = 1;
                return;
            }
            else if (message.Text == "Update🔄️")
            {
                isPushCRUD = 2;
                return;
            }
            else if (message.Text == "Delate❌")
            {
                isPushCRUD = 3;
                return;
            }
            else if (message.Text == "Show all✅")
            {
                isPushCRUD = 4;
            }
            else if (message.Text == "🔙")
            {
                await botClient.SendTextMessageAsync(
                     chatId: message.Chat.Id,
                     text: "Buttonlardan birin bosing!",
                     replyMarkup: ButtonController.AdminButton
                 );
            }
            if (isPushCRUD == 1)
            {
                await IsDone("Category qo'shildi.\nBoshqa qo'shish uchun Create✔️ ni bosing.");
                isPushCRUD = 0;
                Category.Add(new Category()
                {
                    Category_name = message.Text!
                });
            }
            else if (isPushCRUD == 2)
            {
                await IsDone("Category update qilindi.\nYana Update qilish uchun Update🔄️ ni bosing.");
                isPushCRUD = 0;
                string[] str = message.Text.Split(", ");
                await Category.Update(botClient, update, cancellationToken, str[0], str[1]);
            }
            else if (isPushCRUD == 3)
            {
                await IsDone("Category o'chirildi.\nYana o'chirish uchun Delate❌ ni bosing.");
                isPushCRUD = 0;
                Category.Delete(message.Text);
            }
            else if (isPushCRUD == 4 && Category.ShowAll().Count() == 0)
            {
                isPushCRUD = 0;
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Categoryda hech narsa yuq❗❗❗", cancellationToken: cancellationToken);
            }
            else if (isPushCRUD == 4)
            {
                isPushCRUD = 0;
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: Category.ShowAll(), cancellationToken: cancellationToken);
            }
        }
        else if (isPushCategory == 6)
        {
            isPushCategory = 0;
            await GetPDF.Run(botClient, update, cancellationToken);
        }
        else if (isPushCategory == 3)
        {
            if (message.Text == "Create✔️")
            {
                isPushCRUD = 31;
                return;
            }
            else if (message.Text == "Update🔄️")
            {
                isPushCRUD = 32;
                return;
            }
            else if (message.Text == "Delate❌")
            {
                isPushCRUD = 33;
                return;
            }
            else if (message.Text == "Show all✅")
            {
                isPushCRUD = 34;
            }
            else if (message.Text == "🔙")
            {
                await botClient.SendTextMessageAsync(
                     chatId: message.Chat.Id,
                     text: "Buttonlardan birin bosing!",
                     replyMarkup: ButtonController.AdminButton
                 );
            }
            if (isPushCRUD == 31)
            {
                await IsDone("Pay Type qo'shildi.\nBoshqa qo'shish uchun Create✔️ ni bosing.");
                isPushCRUD = 0;
                PayType.Add(new PayType()
                {
                    Paytype_name = message.Text!
                });
            }
            else if (isPushCRUD == 32)
            {
                await IsDone("Pay Type update qilindi.\nYana Update qilish uchun Update🔄️ ni bosing.");
                isPushCRUD = 0;
                string[] str = message.Text.Split(", ");
                await PayType.Update(botClient, update, cancellationToken, str[0], str[1]);
            }
            else if (isPushCRUD == 33)
            {
                await IsDone("Pay Type o'chirildi.\nYana o'chirish uchun Delate❌ ni bosing.");
                isPushCRUD = 0;
                PayType.Delete(message.Text);
            }
            else if (isPushCRUD == 34 && PayType.ShowAll().Count() == 0)
            {
                isPushCRUD = 0;
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Pay Type hech narsa yuq❗❗❗", cancellationToken: cancellationToken);
            }
            else if (isPushCRUD == 34)
            {
                isPushCRUD = 0;
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: PayType.ShowAll(), cancellationToken: cancellationToken);
            }

        }


        if (message.Text == "Category✅")
        {
            isPushCategory = 1;
            await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buttonlardan birini bosing!",
            replyMarkup: ButtonController.CRUD);
            return;
        }
        else if (message.Text == "Download PDF list customers⏬")
        {
            isPushCategory = 6;
            return;
        }

        else if (message.Text == "Pay type✅")
        {
            isPushCategory = 3;
            await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buttonlardan birini bosing!",
            replyMarkup: ButtonController.CRUD);
            return;
        }

        
        async Task IsDone(string status)
        {
            await botClient.SendTextMessageAsync
            (
                 chatId: message.Chat.Id,
                 text: status,
                 replyMarkup: ButtonController.CRUD
            );
        }




    }
    else if (CheckUsersId(message.Chat.Id))
    {
        await botClient.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 text: "Buttonlardan birin bosing!",
                 replyMarkup: ButtonController.UserCategory
             );
    }
    else
    {
        if (message.Type == MessageType.Contact)
        {
            await AddUserToJsonFile(new Person() { id = message.Chat.Id, Name = message.Contact!.FirstName, Phone_Number = message.Contact.PhoneNumber });
            await botClient.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 text: "Xush kelibsiz!",
                 replyMarkup: ButtonController.UserCategory
             );
        }
        else
        {
            ReplyKeyboardMarkup markup1 = new ReplyKeyboardMarkup(KeyboardButton.WithRequestContact("Contact Send📤."));
            markup1.ResizeKeyboard = true;
            markup1.OneTimeKeyboard = true;
            await botClient.SendTextMessageAsync(
                chatId: message!.Chat.Id,
                text: "Raqamingizni junating📤",
                replyMarkup: markup1
            );
        }


    }
}

#region
/*async Task GetMe(long id, ReplyKeyboardMarkup requestReplyKeyboard)
{
    string txt;
    using (StreamReader reader = new StreamReader(path_users))
    {
        txt = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
    foreach (Person person in persons)
    {
        if (person.id == id)
        {
            await botClient.SendTextMessageAsync(
            chatId: id,
            text: $"\tUser Id => {person.id}\n\tUser Name => {person.Name}\n\tUser number => {person.Phone_Number}\n",
            replyMarkup: requestReplyKeyboard);
            return;
        }
    }
}
async Task GetUsers(long id, ReplyKeyboardMarkup requestReplyKeyboard)
{
    string txt;
    using (StreamReader reader = new StreamReader(path_users))
    {
        txt = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
    foreach (Person person in persons)
    {
        await botClient.SendTextMessageAsync(
        chatId: id,
        text: $"\tUser Id => {person.id}\n\tUser Name => {person.Name}\n\tUser number => {person.Phone_Number}\n",
        replyMarkup: requestReplyKeyboard);
    }
}*/
#endregion

async Task AddUserToJsonFile(Person person)
{
    string txt;
    using (StreamReader reader = new StreamReader(path_users))
    {
        txt = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
    persons!.Add(person);
    using (StreamWriter sw = new StreamWriter(path_users))
    {
        string newData = JsonSerializer.Serialize(persons);
        sw.Write(newData);
    }
}
async Task findUserAndAddAdmin(string givenId, Update update)
{
    string txt;
    using (StreamReader reader = new StreamReader(path_users))
    {
        txt = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
    foreach (Person person in persons)
    {
        if (person.id == Convert.ToInt64(givenId))
        {
            //await AddAdminToJsonFile(new Person() { id = person.id, Name = person.Name, Phone_Number = person.Phone_Number });
            AddAdminToJsonFile(person);
            await botClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            text: "Admin muvofaqqiyatli qo'shildi✅");
            return;
        }
    }
    await botClient.SendTextMessageAsync(
        chatId: update.Message!.Chat.Id,
        text: $"Bunday CHat Id li User topilmadi❗");
}

async Task AddAdminToJsonFile(Person person)
{
    string txt;
    using (StreamReader reader = new StreamReader(path_admins))
    {
        txt = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
    persons!.Add(person);
    using (StreamWriter sw = new StreamWriter(path_admins))
    {
        string newData = JsonSerializer.Serialize(persons);
        sw.Write(newData);
    }
}

bool CheckUsersId(long id)
{
    string txt;
    using (StreamReader reader = new StreamReader(path_users))
    {
        txt = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt)!;
    foreach (Person person in persons)
    {
        if (person.id == id)
        {
            return true;
        }
    }
    return false;
}


bool CheckAdminId(long id)
{
    string txt_admins;
    using (StreamReader reader = new StreamReader(path_admins))
    {
        txt_admins = reader.ReadToEnd();
    }
    List<Person> persons = JsonSerializer.Deserialize<List<Person>>(txt_admins)!;
    foreach (Person person in persons)
    {
        if (person.id == id)
        {
            return true;
        }
    }
    return false;
}




Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}


Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
class Person
{
    public long id { get; set; }
    public string? Name { get; set; }
    public string? Phone_Number { get; set; }
}
class AdminId
{
    public long id { get; set; }

}




class Category
{
    public string Category_name { get; set; }

    private static string path = @"D:\BFN\.Net\C#\FastFootBot\Categories.json";

    public static void Add(Category ct)
    {
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        foreach (var u in list)
        {
            if (u.Category_name == ct.Category_name)
            {
                return;
            }
        }
        list.Add(ct);
        DeserilizeSerelize<Category>.Save(list, path);
    }

    public static string ShowAll()
    {
        StringBuilder sb = new StringBuilder();
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        foreach (Category u in list)
        {
            sb.Append($"Category name → {u.Category_name}\n\n");
        }
        return sb.ToString().ToLower();
    }

    public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string Category_name, string new_name)
    {
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        int index = list.FindIndex(us => us.Category_name == Category_name);
        Console.WriteLine(index);
        if (index != -1)
        {
            list[index].Category_name = new_name;
            DeserilizeSerelize<Category>.Save(list, path);
        }
        else if (index == -1)
        {
            await botClient.SendTextMessageAsync(
                 chatId: update.Message.Chat.Id,
                 text: "Siz mavjud bo'lmagan ma'lumot kiritdingiz❗❗❗",
                 replyMarkup: ButtonController.CRUD
             );
        }
        // Ma'lumotlarni to'g'ri kiriting!\nMisol: {eski ma'lumor}, {yangi ma'lumot}
    }
    public static void Delete(string Cat_nm)
    {
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        int index = list.FindIndex(us => us.Category_name == Cat_nm.ToLower() );

        if (index != -1)
        {
            list.RemoveAt(index);
            DeserilizeSerelize<Category>.Save(list, path);
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





