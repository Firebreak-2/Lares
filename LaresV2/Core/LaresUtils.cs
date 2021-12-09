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
    public static class LaresUtils
    {
        private static DataTable dataTable = new();
        /// <summary>
        /// A string based calculator
        /// </summary>
        /// <param name="inputToCompute">The string input that will be computed</param>
        /// <returns>the output of the calculation</returns>
        public static string StringCompute(string inputToCompute)
        {
            return dataTable.Compute(inputToCompute, null).ToString();
        }
        public static Color HexToColor(string hexString)
        {
            if (hexString.IndexOf('#') != -1)
                hexString = hexString.Replace("#", "");

            int r, g, b;

            r = int.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            g = int.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            b = int.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return new Color(r, g, b);
        }
        public static Color HSLToRGB(int Hue, float Sat, float Lum)
        {
            static float HueToRGB(float v1, float v2, float vH)
            {
                if (vH < 0)
                    vH += 1;

                if (vH > 1)
                    vH -= 1;

                if ((6 * vH) < 1)
                    return (v1 + (v2 - v1) * 6 * vH);

                if ((2 * vH) < 1)
                    return v2;

                if ((3 * vH) < 2)
                    return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

                return v1;
            }
            byte r;
            byte g;
            byte b;

            if (Sat == 0)
            {
                r = g = b = (byte)(Lum * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)Hue / 360;

                v2 = (Lum < 0.5) ? (Lum * (1 + Sat)) : ((Lum + Sat) - (Lum * Sat));
                v1 = 2 * Lum - v2;

                r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
                g = (byte)(255 * HueToRGB(v1, v2, hue));
                b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
            }

            return new(r, g, b);
        }
        public static class Random
        {
            private static System.Random rand = new();
            public static int Int(int min, int max) => rand.Next(min, max + 1);
        }
        public static class Constants
        {
            public static class Users
            {
                public static class ID
                {
                    public const ulong Firebreak = 751535897287327865;
                    public const ulong Shrimp = 291684752363225098;
                    public static bool IsDev(ulong userID) => IsDev(userID);
                }
                public static class User
                {
                    public static SocketUser Fireberak => Program._client.GetUser(ID.Firebreak);
                    public static SocketUser Shrimp => Program._client.GetUser(ID.Shrimp);
                    public static bool IsDev(SocketUser user) => IsDev(user);
                }
                public static bool IsDev(SocketMessage message) => IsDev(message.Author);
                public static bool IsDev(SocketUser user) => IsDev(user.Id);
                public static bool IsDev(ulong userID)
                {
                    var id = userID.ToString();
                    return Guilds.Guild.Lares.GetTextChannel(915280854031429703).GetPinnedMessagesAsync().Result.Any(x => x.Content == id);
                }
            }
            public static class Guilds
            {
                public static class ID
                {
                    public const ulong Lares = 915280394117591130;
                }
                public static class Guild
                {
                    public static SocketGuild Lares => Program._client.GetGuild(ID.Lares);
                }
            }
        }
    }
}
