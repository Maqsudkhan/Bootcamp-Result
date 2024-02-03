

using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6500758739:AAHA3XQEga2iZW7XIeBO1qwxTG4KnSE9mf0");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
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

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var message = update.Message;

    HttpClient httpClient = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json");
    var response = httpClient.SendAsync(request).Result;
    var body = response.Content.ReadAsStringAsync().Result;
    var items = JsonSerializer.Deserialize<List<Valyuta>>(body);

    ReplyKeyboardMarkup markup = new(
    new[]
        {
        new KeyboardButton[]
        {
         new KeyboardButton("AED"),
         new KeyboardButton("AUD"),
         new KeyboardButton("CAD"),
         new KeyboardButton("CHF"),
        },
        new KeyboardButton[]
        {
         new KeyboardButton("CNY"),
         new KeyboardButton("DKK"),
         new KeyboardButton("EGP"),
         new KeyboardButton("EUR"),
        },
        new KeyboardButton[]
        {
         new KeyboardButton("GBP"),
         new KeyboardButton("ISK"),
         new KeyboardButton("JPY"),
         new KeyboardButton("KRW"),
        },
        new KeyboardButton[] 
        {  
         new KeyboardButton("KWD"),
         new KeyboardButton("KZT"),
         new KeyboardButton("LBP"),
         new KeyboardButton("MYR"),
        },
        new KeyboardButton[]
        {
         new KeyboardButton("NOK"),
         new KeyboardButton("PLN"),
         new KeyboardButton("RUB"),  
         new KeyboardButton("SEK"), 
        },
        new KeyboardButton[]
        {
         new KeyboardButton("SGD"),
         new KeyboardButton("TRY"),
         new KeyboardButton("UAH"),
         new KeyboardButton("USD"),
        },
        });

    markup.ResizeKeyboard = true;

    foreach (var i in items)
    {
        if (message.Text == i.code)
        {
            await botClient.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 text: $"100{i.code} = {double.Parse(i.cb_price) * 100} so'm",
                 replyMarkup: markup
             );
            return;
        }
    } 

    await botClient.SendTextMessageAsync(
         chatId: message.Chat.Id,
         text: "Pul birligini kiriting:",
         replyMarkup: markup
     );
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


public class Valyuta
{
    public string title { get; set; }
    public string code { get; set; }
    public string cb_price { get; set; }
    public string nbu_buy_price { get; set; }
    public string nbu_cell_price { get; set; }
    public string date { get; set; }

}