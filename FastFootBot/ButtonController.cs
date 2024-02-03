using Telegram.Bot.Types.ReplyMarkups;

namespace FastFootBot
{
    public static class ButtonController
    {
        public static ReplyKeyboardMarkup AdminButton = new ReplyKeyboardMarkup(
    new List<KeyboardButton[]>()
    {
                new KeyboardButton[]
                {
                    new KeyboardButton("Category✅"),
                    new KeyboardButton("Product✅"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Pay type✅"),
                    new KeyboardButton("Order status✅")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Download list orders⏬"),
                    new KeyboardButton("Download list customers⏬")
                },
                new KeyboardButton[]
                {
                    //new KeyboardButton("🔙"),
                    new KeyboardButton("Admin append👨🏻‍💻")
                }
    })
        {
            ResizeKeyboard = true, 
        };

        public static ReplyKeyboardMarkup CRUD = new ReplyKeyboardMarkup(
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

        public static ReplyKeyboardMarkup UserCategory = new (
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

    }
}
