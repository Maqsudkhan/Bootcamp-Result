using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6376249120:AAHsdY4LlnPoScWrjY-eZCUFz3CqU5AOrpw");

var path_users = "D:\\BFN\\.Net\\C#\\FastFootBot\\Users.json";
var path_admins = "D:\\BFN\\.Net\\C#\\FastFootBot\\Admins.json";

int isPushCategory = 0;
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

    if (CheckAdminId(message.Chat.Id))
    {
        var requestReplyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Category✅"),
                    new KeyboardButton("Product✅"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Pay taype✅"),
                    new KeyboardButton("Order status✅")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Download list orders⏬"),
                    new KeyboardButton("Download list customers⏬")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("🔙"),
                    new KeyboardButton("Admin append👨🏻‍💻")
                }
            })
        {
            ResizeKeyboard = true,
        };

        requestReplyKeyboard.ResizeKeyboard = true;
        requestReplyKeyboard.OneTimeKeyboard = true;

        await botClient.SendTextMessageAsync(
             chatId: message.Chat.Id,
             text: "Buttonlardan birini bosing!",
             replyMarkup: requestReplyKeyboard);

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


        if(isPushCategory == 1)
        {
            if(message.Text == "Create✔️")
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
            if(isPushCRUD == 1)
            {
                Category.Add(new Category()
                {
                    Category_name = message.Text!
                });
            }
            else if (isPushCRUD == 2)
            {
                string[] str = message.Text.Split(", ");
                Category.Update(str[0], str[1]);
            }
            else if (isPushCRUD == 3)
            {
                Category.Delete(message.Text);
            }
            else if (isPushCRUD == 4)
            {
                await botClient.SendTextMessageAsync(chatId:message.Chat.Id,text:Category.ShowAll(),cancellationToken:cancellationToken);
            }
        }
        if (message.Text == "Category✅")
        {
            isPushCategory = 1;
            var requestReplyKeyboard1 = new ReplyKeyboardMarkup(
                new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Create✔️"),
                    new KeyboardButton("Update🔄️"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Delate❌"),
                    new KeyboardButton("Show all✅")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("🔙")
                }
            })
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buttonlardan birini bosing!",
            replyMarkup: requestReplyKeyboard1);
            return;
        }

    }

    else if (CheckUsersId(message.Chat.Id))
    {
        ReplyKeyboardMarkup requestReplyKeyboard = new(
        new[]
        {
                 new KeyboardButton("Ichimlar🍹☕🍻"),
                 new KeyboardButton("Burgerlar🍔"),
                 new KeyboardButton("Lavashlar🌯"),
                 new KeyboardButton("Shaurmalar🌮"),
                 new KeyboardButton("Xot-doglar🌭"),
                 new KeyboardButton("Desertlar🍰"),

        });



        requestReplyKeyboard.ResizeKeyboard = true;
        requestReplyKeyboard.OneTimeKeyboard = true;
        await botClient.SendTextMessageAsync(
             chatId: message.Chat.Id,
             text: "Buttonlardan birini bosing!",
             replyMarkup: requestReplyKeyboard
         );

        /*        if (message.Text == "/Admin")
                {
                    await GetMe(message.Chat.Id, requestReplyKeyboard);
                }
                if (message.Text == "/Adminmas")
                {
                    await GetUsers(message.Chat.Id, requestReplyKeyboard);
                }*/
    }
    else
    {
        if (message.Type == MessageType.Contact)
        {
            await AddUserToJsonFile(new Person() { id = message.Chat.Id, Name = message.Contact!.FirstName, Phone_Number = message.Contact.PhoneNumber });
            ReplyKeyboardMarkup requestReplyKeyboard = new(
        new[]
        {
            new KeyboardButton[]
            {
                 new KeyboardButton("Ichimlar🍹☕🍻"),
                 new KeyboardButton("Burgerlar🍔"),
                 new KeyboardButton("Lavashlar🌯"),
            },

            new KeyboardButton[]
            {
                 new KeyboardButton("Shaurmalar🌮"),
                 new KeyboardButton("Xot-doglar🌭"),
                 new KeyboardButton("Desertlar🍰"),
            }

        });
            requestReplyKeyboard.ResizeKeyboard = true;
            requestReplyKeyboard.OneTimeKeyboard = true;

            await botClient.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 text: "Buttonlardan birini bosing!",
                 replyMarkup: requestReplyKeyboard
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

    public static  string ShowAll()
    {
        StringBuilder sb = new StringBuilder();
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        foreach (Category u in list)
        {
            sb.Append($"Category name: {u.Category_name}\n");
        }
        return sb.ToString();
    }

    public static void Update(string Category_name,string new_name)
    {
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        int index = list.FindIndex(us => us.Category_name == Category_name);

        if (index != -1)
        {
            list[index].Category_name = new_name;
            DeserilizeSerelize<Category>.Save(list, path);
        }
    }
    public static void Delete(string Cat_nm)
    {
        List<Category> list = DeserilizeSerelize<Category>.GetAll(path);
        int index = list.FindIndex(us => us.Category_name == Cat_nm);

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





