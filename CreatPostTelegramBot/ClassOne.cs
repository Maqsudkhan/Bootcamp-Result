﻿using CreatPostTelegramBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CreatPostTelegramBot
{
    public class EssentialControlBot
    {
        public async Task WorkingBot()
        {
            TelegramBotClient botClient = new TelegramBotClient("6196116985:AAGmx4BWZn85KQ6tmWqahmU1ddwliYmeDxE");
            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
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
        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { })
                return;

            var handler = update.Type switch
            {

                UpdateType.Message => ControlMessageClass.EssentialAsyncMessga(botClient, update, cancellationToken),
                _ => ControlMessageClass.OtherMessga(botClient, update, cancellationToken),
            };
            try
            {
                await handler;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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
    }
}