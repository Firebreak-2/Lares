using Discord;
using Discord.WebSocket;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace LaresV2.Core
{
	public class Program
	{
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

        public static readonly string LaresPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Lares";
        public static DiscordSocketClient _client;

        public async Task MainAsync()
        {
            string token = null;
            if (!Directory.Exists(LaresPath))
                Directory.CreateDirectory(LaresPath);
            if (File.Exists($"{LaresPath}\\token.txt"))
                token = File.ReadAllText($"{LaresPath}\\token.txt");
            else
            {
                Console.WriteLine("No token found. Killing..");
                return;
            }

            _client = new(new DiscordSocketConfig() { MessageCacheSize = 120, LogGatewayIntentWarnings = false });
            _client.Log += Log;
            _client.Ready += Actions.Commands.Testing;
            _client.Ready += Actions.Commands.MainLine;
            _client.SlashCommandExecuted += Actions.Commands.Handler.SlashCommandHandler;
            _client.MessageReceived += Actions.WhenMessage.Sent.Do;
            _client.MessageDeleted += Actions.WhenMessage.Deleted.Do;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }
    }
}
