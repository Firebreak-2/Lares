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
using LaresV2.Core;
using Discord.Net;
using Newtonsoft.Json;

namespace LaresV2.Actions
{
    public static class WhenMessage
    {
        public static class Sent
        {
            public static Task Do(SocketMessage message)
            {
                if (message.Author.IsBot) return Task.CompletedTask;

                RandomReact(message);
                RePing(message);

                return Task.CompletedTask;
            }
            private static void RandomReact(SocketMessage message)
            {
                if (LaresUtils.Random.Int(0, 200) == 0)
                {
                    message.AddReactionAsync(Program._client.GetGuild(784348580055220234).Emotes.RandomItem());
                }
            }
            private static void RePing(SocketMessage message)
            {
                if (message.MentionedUsers.Count > 0)
                {
                    string pingee = "";
                    foreach (var item in message.MentionedUsers)
                    {
                        if (item.IsDev())
                        {
                            pingee += $"{item.Mention}!\n";
                        }
                    }
                    message.Channel.SendMessageAsync(pingee);
                }
            }
        }
        public static class Deleted
        {
            public static Task Do(Cacheable<IMessage, ulong> c_message, Cacheable<IMessageChannel, ulong> c_channel)
            {
                DeGhostPing(c_message, c_channel);

                return Task.CompletedTask;
            }
            private static void DeGhostPing(Cacheable<IMessage, ulong> c_message, Cacheable<IMessageChannel, ulong> c_channel)
            {
                var message = c_message.GetOrDownloadAsync().Result;
                if (message is not null)
                {
                    if (message.MentionedEveryone || message.MentionedRoleIds.Count() > 0 || message.MentionedUserIds.Count() > 0)
                    {
                        var embed = new EmbedBuilder();
                        embed.AddField("Ghost Ping Detected\n\nMessage content:", $"{message.Content}");
                        embed.AddField("Mentioned Users:", $"{(message.MentionedUserIds.Count > 0 ? string.Join(", ", message.MentionedUserIds.Select(x => $"<@!{x}>")) : "None")}");
                        embed.AddField("Mentioned Roles:", $"{(message.MentionedRoleIds.Count > 0 ? string.Join(", ", message.MentionedRoleIds.Select(x => $"<@&{x}>")) : "None")}");
                        embed.AddField("Mentioned Everyone:", $"{message.MentionedEveryone}");
                        embed.WithAuthor(message.Author);
                        embed.Color = Color.Gold;
                        message.Channel.SendMessageAsync(embed: embed.Build(), allowedMentions: AllowedMentions.None);
                    }
                }
            }
        }
    }
}
