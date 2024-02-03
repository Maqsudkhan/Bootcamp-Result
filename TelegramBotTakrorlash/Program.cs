using System.Text.Json;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6915756848:AAFqEXhGilSSnEaRgFbHUq1Ooxt_WkBq-e0");

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
    Console.WriteLine($"Received a '{message.Text}' message in chat {message.Chat.Id}. UserName =>  {message.Chat.Username}");
    var handler = message.Type switch
    {
        MessageType.Text => HandleTextAsync(botClient, update, cancellationToken),
        MessageType.Video => HandleVideoAsync(botClient, update, cancellationToken),
        MessageType.Photo => HandlePhotaAsync(botClient, update, cancellationToken),
        MessageType.Audio => HandleAudioAsync(botClient, update, cancellationToken),
        MessageType.Sticker => HandleStickerAysnc(botClient, update, cancellationToken),
        MessageType.Document => HandleDocumentAsync(botClient, update, cancellationToken),
        MessageType.Animation => HandleAnimationAsync(botClient, update, cancellationToken)
    };
}



async Task HandleTextAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendTextMessageAsync(
        chatId: update.Message.Chat.Id,
        text: "Your said:  " + update.Message.Text,
        cancellationToken: cancellationToken);
}

async Task HandleVideoAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendVideoAsync(
    //var filestream = new FileStream(@"C:\Users\Maqsudkhan\Downloads\Telegram Desktop\kuku.mp4", FileMode.Open);
    chatId: update.Message.Chat.Id,
    video: InputFile.FromFileId(update.Message.Video!.FileId),
    cancellationToken: cancellationToken);
    //filestream.Dispose();
}

async Task HandlePhotaAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendPhotoAsync(
    chatId: update.Message!.Chat.Id,
    photo: InputFile.FromFileId(update.Message.Photo!.Last().FileId),
    cancellationToken: cancellationToken);
}

async Task HandleAudioAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
{
    await client.SendAudioAsync(
    chatId: update.Message.Chat.Id,
    audio: InputFile.FromFileId(update.Message.Audio!.FileId),
    cancellationToken: cancellationToken);
}


async Task HandleStickerAysnc(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendStickerAsync(
    chatId: update.Message!.Chat.Id,
    sticker: InputFile.FromFileId(update.Message.Sticker!.FileId),
    cancellationToken: cancellationToken);
}

async Task HandleDocumentAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendDocumentAsync(
    chatId: update.Message!.Chat.Id,
    document: InputFile.FromFileId(update.Message.Document!.FileId),
    cancellationToken: cancellationToken);
}

async Task HandleAnimationAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendAnimationAsync(
    chatId: update.Message.Chat.Id,
    animation: InputFile.FromFileId(update.Message.Animation.FileId),
    cancellationToken: cancellationToken);
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









