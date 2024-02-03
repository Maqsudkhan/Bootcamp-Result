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

var botClient = new TelegramBotClient("6579551595:AAHKzkNaFPyP-HrngAD1dA1oFPFwhI_hgCA");

using CancellationTokenSource cts = new();

string PathJson = "D:\\BFN\\.Net\\C#\\ZipTelegramBot\\bin\\Debug\\net8.0\\barchaId.json";

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

string OldingiItemPath = "";
string PathniBerish = null;
string FileNameniBerish = null;
string OldingiItemFileName = "";

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
    var handler = update.Type switch
    {
        UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
        UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
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

    var message = update.Message;
    if (IdTekshirish(message.Chat.Id))
    {
        AddIdToJson(message.Chat.Id);
    }
    ReplyKeyboardMarkup replyKeyboardMarkup =
    new(
        new[]
        {
                new KeyboardButton[] { "Path✅", "FileName✅" },
        }
    )
    {
        ResizeKeyboard = true
    };
    if (message.Text == "/start" || message.Text == "start")
    {
        await botClient.SendTextMessageAsync(
        chatId: message.Chat.Id,
        text: "Let's begin",
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: cancellationToken);

    }


    else if (message.Text == "Path✅")
    {
        await botClient.SendTextMessageAsync(
        chatId: message.Chat.Id,
        text: "Path waiting",
        cancellationToken: cancellationToken);
        OldingiItemPath = "Path✅";
    }


    else if (message.Text == "FileName✅")
    {
        await botClient.SendTextMessageAsync(
        chatId: message.Chat.Id,
        text: "FileName waiting",
        cancellationToken: cancellationToken);
        OldingiItemFileName = "FileName✅";
    }
    else if (update.Message.Text.StartsWith("C:") || update.Message.Text.StartsWith("D:") || update.Message.Text.StartsWith("E:") || update.Message.Text.StartsWith("F:"))
    {
        PathniBerish = message.Text;
    }
    else { FileNameniBerish = message.Text; }

    if (PathniBerish != null && FileNameniBerish != null)
    {
        await SendZipFileToUsers(botClient, update, cancellationToken, PathniBerish, FileNameniBerish);
        PathniBerish = null; FileNameniBerish = null;
    }
}

async Task SendZipFileToUsers(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string path, string zipPath)
{
    string sourceFilePath = Path.Combine(path, zipPath);
    string zipFilePath;
    if (System.IO.File.Exists(sourceFilePath))
    {
        string justname = zipPath.Split('.')[0];
        zipFilePath = path + "\\" + justname + ".zip";
    }
    else
    {
        zipFilePath = path + "\\" + zipPath + ".zip";
    }

    ZipFileWithSingleEntry(sourceFilePath, zipFilePath, update, cancellationToken);


    string alldata;
    using (StreamReader toread = new StreamReader(PathJson))
    {
        alldata = toread.ReadToEnd();
    }
    List<long> ids = JsonSerializer.Deserialize<List<long>>(alldata);

    foreach (var id in ids!)
    {
        await using Stream stream = System.IO.File.OpenRead(zipFilePath);
        await botClient.SendDocumentAsync(
            chatId: id,
            document: InputFile.FromStream(stream: stream, fileName: $"{zipPath}.zip"),
            caption: "Hammasi tayyor✅"
            );
        stream.Dispose();
    }
}

async Task ZipFileWithSingleEntry(string sourcePath, string zipFilePath, Update update, CancellationToken cancellationToken)
{
    try
    {
        if (System.IO.File.Exists(sourcePath))
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            try
            {
                string destinationFile = Path.Combine(tempDirectory, Path.GetFileName(sourcePath));
                System.IO.File.Copy(sourcePath, destinationFile);

                using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(destinationFile, Path.GetFileName(destinationFile));
                }
            }
            finally
            {
                Directory.Delete(tempDirectory, true);
            }
        }
        else if (Directory.Exists(sourcePath))
        {
            ZipFile.CreateFromDirectory(sourcePath, zipFilePath);
        }
        else
        {
            await botClient.SendTextMessageAsync(
                  chatId: update.Message.Chat.Id,
                  text: "‼️Berilgan manzilda fayl yoki papka topilmadi",
                  cancellationToken: cancellationToken);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"‼️Xatolik yuz berdi: {ex.Message}");
    }
}
void AddIdToJson(long id)
{
    string alldata;
    using (StreamReader toread = new StreamReader(PathJson))
    {
        alldata = toread.ReadToEnd();
    }
    List<long> ids = JsonSerializer.Deserialize<List<long>>(alldata);
    ids.Add(id);
    string strIds = JsonSerializer.Serialize(ids);
    using (StreamWriter toread = new StreamWriter(PathJson))
    {
        toread.Write(strIds);
    }
}

bool IdTekshirish(long id)
{
    string alldata;
    using (StreamReader toread = new StreamReader(PathJson))
    {
        alldata = toread.ReadToEnd();
    }
    List<long> ids = JsonSerializer.Deserialize<List<long>>(alldata);
    return ids.Contains(id);
}



Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}

Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
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