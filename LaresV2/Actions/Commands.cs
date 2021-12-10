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
    public static class Commands
    {
        public static class Handler
        {
            public static async Task SlashCommandHandler(SocketSlashCommand command)
            {
                OnCommand(command);
            }
            public static Action<SocketSlashCommand> OnCommand;
        }
        public static async Task Testing()
        {
            if (LaresUtils.Constants.Guilds.Guild.Lares.GetApplicationCommandsAsync().Result.Count > 0)
            await LaresUtils.Constants.Guilds.Guild.Lares.DeleteApplicationCommandsAsync();

            await CMD.Create(new("convert", "A unit converter of many scopes.", (cmd) =>
            {
                var fieldOne = cmd.Data.Options.First();
                var args = fieldOne.Options.ToArray();
                var from = (string)args[1].Value;
                var to = (string)args[2].Value;
                var val = (double)args[3].Value;
                double output = double.MinValue;
                var embed = new EmbedBuilder().WithTitle($"{val} | {args[1].Name} => {args[2].Name}");
                switch (fieldOne.Name)
                {
                    case "temperature":
                        switch (from)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        switch (to)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        break;
                    case "angle":
                        switch (from)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        switch (to)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        break;
                    case "length":
                        switch (from)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        switch (to)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        break;
                    case "mass":
                        switch (from)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        switch (to)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        break;
                    case "time":
                        switch (from)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        switch (to)
                        {
                            case "":

                                break;
                            default:
                                return;
                        }
                        break;
                    default:
                        return;
                }
                cmd.RespondAsync(null, new[] { embed.WithDescription(output.ToString()).Build() });
            }, LaresUtils.Constants.Guilds.ID.Lares, new SlashCommandOptionBuilder[]
            {
                new SlashCommandOptionBuilder()
                    .WithName("temperature")
                    .WithDescription("Converts between various types of temperature units")
                    .WithType(ApplicationCommandOptionType.SubCommand)
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("from")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit to convert")
                            .WithRequired(true)
                                .AddChoice("celcius", "c")
                                .AddChoice("fahrenheit", "f")
                                .AddChoice("kelvin", "k")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("to")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit type to convert to")
                            .WithRequired(true)
                                .AddChoice("celcius", "c")
                                .AddChoice("fahrenheit", "f")
                                .AddChoice("kelvin", "k")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("value")
                            .WithType(ApplicationCommandOptionType.Number)
                            .WithDescription("The unit's value")
                            .WithRequired(true)
                         ),
                new SlashCommandOptionBuilder()
                    .WithName("angle")
                    .WithDescription("Converts between the two types of angle units")
                    .WithType(ApplicationCommandOptionType.SubCommand)
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("from")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit to convert")
                            .WithRequired(true)
                                .AddChoice("radians", "r")
                                .AddChoice("degrees", "d")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("to")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit type to convert to")
                            .WithRequired(true)
                                .AddChoice("radians", "r")
                                .AddChoice("degrees", "d")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("value")
                            .WithType(ApplicationCommandOptionType.Number)
                            .WithDescription("The unit's value")
                            .WithRequired(true)
                         ),
                new SlashCommandOptionBuilder()
                    .WithName("length")
                    .WithDescription("Converts between the many length units")
                    .WithType(ApplicationCommandOptionType.SubCommand)
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("from")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit to convert")
                            .WithRequired(true)
                                .AddChoice("centimeter", "cm")
                                .AddChoice("millimeter", "mm")
                                .AddChoice("meter", "m")
                                .AddChoice("kilometer", "km")
                                .AddChoice("inch", "in")
                                .AddChoice("foot", "ft")
                                .AddChoice("yard", "y")
                                .AddChoice("mile", "M")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("to")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit type to convert to")
                            .WithRequired(true)
                                .AddChoice("centimeter", "cm")
                                .AddChoice("millimeter", "mm")
                                .AddChoice("meter", "m")
                                .AddChoice("kilometer", "km")
                                .AddChoice("inch", "in")
                                .AddChoice("foot", "ft")
                                .AddChoice("yard", "y")
                                .AddChoice("mile", "M")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("value")
                            .WithType(ApplicationCommandOptionType.Number)
                            .WithDescription("The unit's value")
                            .WithRequired(true)
                         ),
                new SlashCommandOptionBuilder()
                    .WithName("mass")
                    .WithDescription("Converts between mass units")
                    .WithType(ApplicationCommandOptionType.SubCommand)
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("from")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit to convert")
                            .WithRequired(true)
                                .AddChoice("milligram", "mg")
                                .AddChoice("gram", "g")
                                .AddChoice("kilogram", "kg")
                                .AddChoice("milligram", "mg")
                                .AddChoice("ton", "t")
                                .AddChoice("pound", "p")
                                .AddChoice("ounce", "o")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("to")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit type to convert to")
                            .WithRequired(true)
                                .AddChoice("milligram", "mg")
                                .AddChoice("gram", "g")
                                .AddChoice("kilogram", "kg")
                                .AddChoice("milligram", "mg")
                                .AddChoice("ton", "t")
                                .AddChoice("pound", "p")
                                .AddChoice("ounce", "o")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("value")
                            .WithType(ApplicationCommandOptionType.Number)
                            .WithDescription("The unit's value")
                            .WithRequired(true)
                         ),
                new SlashCommandOptionBuilder()
                    .WithName("time")
                    .WithDescription("Converts between various chronical units")
                    .WithType(ApplicationCommandOptionType.SubCommand)
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("from")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit to convert")
                            .WithRequired(true)
                                .AddChoice("seconds", "s")
                                .AddChoice("minutes", "m")
                                .AddChoice("hours", "h")
                                .AddChoice("days", "d")
                                .AddChoice("weeks", "w")
                                .AddChoice("months", "M")
                                .AddChoice("years", "y")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("to")
                            .WithType(ApplicationCommandOptionType.String)
                            .WithDescription("The unit type to convert to")
                            .WithRequired(true)
                                .AddChoice("seconds", "s")
                                .AddChoice("minutes", "m")
                                .AddChoice("hours", "h")
                                .AddChoice("days", "d")
                                .AddChoice("weeks", "w")
                                .AddChoice("months", "M")
                                .AddChoice("years", "y")
                         )
                        .AddOption(new SlashCommandOptionBuilder()
                            .WithName("value")
                            .WithType(ApplicationCommandOptionType.Number)
                            .WithDescription("The unit's value")
                            .WithRequired(true)
                         ),
            }));
        }
        public static async Task MainLine()
        {
            await CMD.Create(new CMD("leave", "Leaves the current server or all servers.", (cmd) =>
            {
                if ((bool)cmd.Data.Options.First().Value)
                {
                    cmd.RespondAsync("leaving every f||hi||king server !!");
                    foreach (var g in Program._client.Guilds)
                    {
                        g.LeaveAsync();
                    }
                }
                else
                {
                    cmd.RespondAsync($"Farewell, {cmd.Channel.GetGuild().Name}.");
                    cmd.Channel.GetGuild().LeaveAsync();
                }
            }, null, new SlashCommandOptionBuilder[]
            {
                new()
                {
                    Name = "all",
                    Description = "leaves all servers",
                    Type = ApplicationCommandOptionType.Boolean,
                    IsRequired = true
                }
            }));

            await CMD.Create(new CMD("calc", "A string based calculator.", (cmd) =>
            {
                var input = (string)cmd.Data.Options.First();
                cmd.RespondAsync(null,
                    new[]
                    {
                    new EmbedBuilder()
                        .WithColor(Color.Orange)
                        .WithTitle($"Input: {input}")
                        .WithDescription(LaresUtils.StringCompute(input))
                        .Build()
                    }, allowedMentions: AllowedMentions.None);
            }, null, new SlashCommandOptionBuilder[]
            {
            new()
            {
                Name = "input",
                Description = "The string input that will be computed",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true,

            },
            }));

            await CMD.Create(new CMD("echo", "A command that repeats it's input.", (cmd) =>
            {
                var args = cmd.Data.Options.ToArray();
                cmd.RespondAsync(args.Length == 2 && (bool)args[1].Value ? ((string)args[0]).AlternateCase() : (string)args[0], allowedMentions: AllowedMentions.None);
            }, null, new SlashCommandOptionBuilder[]
            {
            new()
            {
                Name = "input",
                Description = "The string input that will be echoed",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true,
            },
            new()
            {
                Name = "alternatecase",
                Description = "Toggles wether the echo will return a string with alternating casings.",
                Type = ApplicationCommandOptionType.Boolean,
                IsRequired = false,
            }
            }));

            await CMD.Create(new CMD("echolink", "A command that repeats it's input to a specific server and channel.", (cmd) =>
            {
                var args = cmd.Data.Options.ToArray();
                var guild = Convert.ToUInt64((string)args[0].Value);
                var channel = Convert.ToUInt64((string)args[1].Value);
                var input = (string)args[2].Value;
                Program._client.GetGuild(guild).GetTextChannel(channel).SendMessageAsync(input);
            }, null, new SlashCommandOptionBuilder[]
            {
            new()
            {
                Name = "server",
                Description = "The server the input will be echoed to",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true,
            },
            new()
            {
                Name = "channel",
                Description = "The channel the input will be echoed to",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true,
            },
            new()
            {
                Name = "input",
                Description = "The string input that will be echoed",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true,
            },
            }));

            await CMD.Create(new("rng", "Generates a random number between the minimum and maximum.", (cmd) =>
            {
                var args = cmd.Data.Options.ToArray();
                int min = Convert.ToInt32(args[0].Value);
                int max = Convert.ToInt32(args[1].Value);
                if (min > max) return;
                cmd.RespondAsync(null, new[]
                {
                new EmbedBuilder()
                .WithColor(Color.Orange)
                .WithTitle($"Random Number [{min} - {max}]")
                .WithDescription(LaresUtils.Random.Int(min, max).ToString())
                .Build()
                });
            }, null, new SlashCommandOptionBuilder[]
            {
            new()
            {
                Name = "minimum",
                Description = "The minimum number to be picked from the randomization.",
                Type = ApplicationCommandOptionType.Integer,
                IsRequired = true
            },
            new()
            {
                Name = "maximum",
                Description = "The maximum number to be picked from the randomization.",
                Type = ApplicationCommandOptionType.Integer,
                IsRequired = true
            },
            }));

            await CMD.Create(new CMD("regex", "A RegEx mathing or replacing engine", (cmd) =>
            {
                var args = cmd.Data.Options.ToArray();
                string pattern = $"{args[1].Value}";
                string input = $"{args[2].Value}";

                var embed = new EmbedBuilder().WithColor(Color.Orange);

                switch (args[0].Value)
                {
                    case "m":
                        embed.WithTitle($"Match\n\ninput: `{input}`\npattern: `{pattern}`\n");
                        var desc = input;
                        foreach (Match match in Regex.Matches(input, pattern))
                        {
                            desc = desc.Replace(match.Value, $"`{match.Value}`");
                        }
                        embed.WithDescription(desc);
                        break;
                    case "r":
                        string replacement = $"{args[3].Value}";
                        embed.WithTitle($"Replace\n\ninput: `{input}`\npattern: `{pattern}`\nreplacement: `{replacement}`\n");
                        embed.WithDescription(Regex.Replace(input, pattern, replacement));
                        break;
                    default:
                        return;
                }

                cmd.RespondAsync(null, new[] { embed.Build() }, allowedMentions: AllowedMentions.None);

            }, null, new SlashCommandOptionBuilder[]
            {
            new Func<SlashCommandOptionBuilder>(() =>
            {
                return new SlashCommandOptionBuilder()
                {
                    Name = "action",
                    Description = "Wether the engine will attempt to match or replace your string.",
                    Type = ApplicationCommandOptionType.String,
                    IsRequired = true,
                }.AddChoice("Match", "m").AddChoice("Replace", "r");
            })(),
            new()
            {
                Name = "pattern",
                Description = "The RegEx pattern to be used for matching.",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true
            },
            new()
            {
                Name = "input",
                Description = "The input that will be matched to the pattern.",
                Type = ApplicationCommandOptionType.String,
                IsRequired = true
            },
            new()
            {
                Name = "replacement",
                Description = "The replacement to be used for the replace option.",
                Type = ApplicationCommandOptionType.String,
                IsRequired = false
            },
            }));

            await CMD.Create(new("ping", "Shows the latency from you to the discord bot.", (cmd) =>
            {
                cmd.RespondAsync($"pong!\n\nEstimated latency: {Program._client.Latency}");
            }, null));

            await CMD.Create(new("kill", "Shuts down the bot.", (cmd) =>
            {
                cmd.RespondAsync($"murderer{string.Join("", new char[LaresUtils.Random.Int(8, 12)].Select(x => LaresUtils.Random.Int(0, 3) == 0 ? "," : "."))}");
                Program._client.LogoutAsync();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }, null));

            await CMD.Create(new("a", "super cool special deluxe incredible unique shrimp only command", (cmd) =>
            {
                if (cmd.User.Id == LaresUtils.Constants.Users.ID.Shrimp)
                    cmd.RespondAsync("a.");
                else
                    cmd.RespondAsync($"you're the wrong guy{string.Join("", new char[LaresUtils.Random.Int(8, 12)].Select(x => LaresUtils.Random.Int(0, 3) == 0 ? "," : "."))}");
            }, null));

            await CMD.Create(new CMD("color", "Displays a color", (cmd) =>
            {
                var fieldOne = cmd.Data.Options.First();
                var args = fieldOne.Options.ToArray();
                switch (fieldOne.Name)
                {
                    case "rgb":
                        if (args.Length == 3)
                        {
                            byte[] values = new byte[3];
                            try
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    values[i] = Convert.ToByte(args[i].Value);
                                }
                            }
                            catch
                            {
                                cmd.RespondAsync("Color data greater than `255` or less than `0`.", ephemeral: true);
                                return;
                            }
                            var col = new Color(values[0], values[1], values[2]);
                            cmd.RespondAsync(null, new[]
                            {
                            new EmbedBuilder()
                                .WithTitle("Color")
                                .AddField("RGB", $"red: {col.R}\ngreen: {col.G}\nblue: {col.B}\n{col.R}, {col.G}, {col.B}")
                                .AddField("Hex", col.ToString())
                                .WithColor(col)
                                .Build()
                            });
                            return;
                        }
                        break;
                    case "hex":
                        if (args.Length == 1 && ((string)args[0].Value).Length == 6)
                        {
                            var col = LaresUtils.HexToColor((string)args[0].Value);
                            cmd.RespondAsync(null, new[]
                            {
                            new EmbedBuilder()
                                .WithTitle("Color")
                                .AddField("RGB", $"red: {col.R}\ngreen: {col.G}\nblue: {col.B}\n{col.R}, {col.G}, {col.B}")
                                .AddField("Hex", col.ToString())
                                .WithColor(col)
                                .Build()
                            });
                            return;
                        }
                        break;
                    default:
                        break;
                }
                cmd.RespondAsync("Invalid color option.", ephemeral: true);
            }, null, new SlashCommandOptionBuilder[]
            {
            new SlashCommandOptionBuilder().WithName("rgb")
                .WithDescription("uses an RGB color format for the command")
                .WithType(ApplicationCommandOptionType.SubCommand)
                    .AddOption("red",  ApplicationCommandOptionType.Integer, "the red color value to be used",  true)
                    .AddOption("green",ApplicationCommandOptionType.Integer, "the green color value to be used",true)
                    .AddOption("blue", ApplicationCommandOptionType.Integer, "the blue color value to be used", true),

            new SlashCommandOptionBuilder().WithName("hex")
                .WithDescription("Uses a hex color format for the command")
                .WithType(ApplicationCommandOptionType.SubCommand)
                    .AddOption(new SlashCommandOptionBuilder()
                        .WithName("value")
                        .WithDescription("The hex color value to be interpretted as a color.")
                        .WithType(ApplicationCommandOptionType.String)
                        .WithRequired(true)
               ),
            }));
        }
        public class CMD
        {
            private SlashCommandBuilder _builder;
            private ulong? _guildID;
            private Action<SocketSlashCommand> _onRun;
            public CMD(string Name, string Description, Action<SocketSlashCommand> OnRun, ulong? GuildID = null, params SlashCommandOptionBuilder[] Parameters)
            {
                var builder = new SlashCommandBuilder()
                                    .WithName(Name)
                                    .WithDescription(Description);

                if (Parameters.Length > 0)
                {
                    builder.AddOptions(Parameters);
                }

                _onRun = (cmd) =>
                {
                    if (cmd.Data.Name == Name)
                        OnRun(cmd);
                };
                _builder = builder;
                _guildID = GuildID;
            }
            public static async Task Create(CMD command)
            {
                Handler.OnCommand += command._onRun;
                if (command._guildID != null)
                    await Program._client.Rest.CreateGuildCommand(command._builder.Build(), command._guildID.Value);
                else
                    await Program._client.Rest.CreateGlobalCommand(command._builder.Build());
            }
        }
    }
}
