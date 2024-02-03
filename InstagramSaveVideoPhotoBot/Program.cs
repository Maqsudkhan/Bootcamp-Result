using System.IO.Compression;
using System.IO.Enumeration;
using System.Text.Json;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6930873354:AAEOg1HfSRJUbV5Nwcaj6P88Wazt9xDHOCg");

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
    cancellationToken: cts.Token);

var me = await botClient.GetMeAsync();
Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();
cts.Cancel();
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    //var message = update.Message;
    var errorcha = update.Type switch
    {
        UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken)
    };
    try
    {
        await errorcha;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error chiqdi: {ex.Message}");
    }
}

async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var message = update.Message;
    Console.WriteLine($"Received a '{message!.Text}' message in chat {message.Chat.Id}. UserName =>  {message.Chat.Username}");

    string replaceMessage = message.Text!.Replace("www.", "dd");

    /*    if (message.Text.StartsWith("https"))
        {
            await botClient.SendVideoAsync(
                chatId: message.Chat.Id,
                video: $"{replaceMessage}",
                //supportsStreaming: true,
                cancellationToken: cancellationToken);
        }*/


    if (message.Text.StartsWith("https"))
    {
        await botClient.SendPhotoAsync(
            chatId: message.Chat.Id,
            photo: $"{replaceMessage}",
            cancellationToken: cancellationToken);
    }


    var messageText = update.Message!.Text;
    var id = update.Message.From!.Id;
    var chatId = update.Message.Chat.Id;


    //set text all lowercase
    messageText = messageText!.ToLower();



    if (messageText == "/start" || messageText == "start")
    {

        var getchatmember = await botClient.GetChatMemberAsync(/*ID or NAME of the chat*/"@toyonaa",/*user id*/ id);
        var getchatmember2 = await botClient.GetChatMemberAsync(/*ID or NAME of the chat*/"@n11Najottalim",/*user id*/ id);

        if (getchatmember.ToString() != "Member")
        {
            await UserIsSubscriber(botClient, id, cancellationToken);

        }
        else if (getchatmember2.ToString() == "Member")
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Thank You for subscription",
                cancellationToken: cancellationToken);
        }
    }
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





async Task UserIsSubscriber(ITelegramBotClient botClient, long id, CancellationToken cancellationToken)
{

    // create the "buttons" with the URL of the channel to join.
    InlineKeyboardMarkup inlineKeyboard = new(new[]
          {
                    //First row. You can also add multiple rows.
                    new []
                    {
                        InlineKeyboardButton.WithUrl(text: "Canale 1", url: "https://t.me/toyonaa"),
                        InlineKeyboardButton.WithUrl(text: "Canale 2", url: "https://t.me/n11Najottalim"),
                    },
                });

    Message sentMessage = await botClient.SendTextMessageAsync(
    chatId: id,
    text: "Before use the bot you must follow this channels.\nWhen you are ready, click -> /home <- to continue",
    replyMarkup: inlineKeyboard,
    cancellationToken: cancellationToken);

}




























