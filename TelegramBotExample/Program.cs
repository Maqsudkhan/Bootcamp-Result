using Telegram.Bot;
using TelegramBotExample.TelegramBotFolder;

namespace TelegramBotExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string token = "6749506990:AAErvNlQs68MkvZ5n9m0pUr7JEzGBaVONQQ";

            TelegramBotHandler handler = new TelegramBotHandler(token);
            try
            {
                await handler.BotHandle();
            }
            catch (Exception ex)
            {
                throw new Exception("try Catch ishlayapti");
            }
        }
    }
}