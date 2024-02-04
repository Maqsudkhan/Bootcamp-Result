using Telegram.Bot;
using Telegram.Bot.Types;
using IO = System.IO;

namespace FastFootBot
{
    public static class GetPDF
    {
        public static async Task Run(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var direct = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            var FilePath = Path.Combine(direct.FullName, "Users");

            IronPdf.License.IsValidLicense("IRONSUITE.SHAHANSHOH819.GMAIL.COM.17684-2C4E16D18D-DGHHMUQ-HK4XMOWKF75W-O4LXWBRK3MOJ-2MQNMVAUBAGG-GVHG64RZWDRP-HFBUCWC7JIEG-UPQ2JMHM5FIO-UPPYQB-TF7FQ66HK2GLUA-DEPLOYMENT.TRIAL-I72N5S.TRIAL.EXPIRES.04.MAR.2024");

            string text = IO.File.ReadAllText(FilePath + ".json");
            ChromePdfRenderer renderer = new ChromePdfRenderer();
            PdfDocument pdf = renderer.RenderHtmlAsPdf(text);
            pdf.SaveAs(FilePath + ".pdf");

            await using Stream stream = IO.File.OpenRead(FilePath + ".pdf");
            await botClient.SendDocumentAsync(
                chatId: update.Message.Chat.Id,
                document: InputFile.FromStream(stream: stream, fileName: $"datas.pdf"),
                caption: "Customers informations❗"
                );
            stream.Dispose();

        }
    }
}
