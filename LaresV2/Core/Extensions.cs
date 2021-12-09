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
    public static class Extensions
    {
        public static T RandomItem<T>(this IEnumerable<T> collection) => collection.ToArray()[LaresUtils.Random.Int(0, collection.Count() - 1)];
        public static SocketGuild GetGuild(this ISocketMessageChannel channel) => Program._client.Guilds.First(x => x.Channels.Any(y => y.Id == channel.Id));
        public static bool IsDev(this SocketUser user) => LaresUtils.Constants.Users.IsDev(user);
        public static string AlternateCase(this string text) => string.Join("", text.Select((c, i) => i % 2 == 0 ? char.ToUpper(c) : char.ToLower(c)));
    }
}
