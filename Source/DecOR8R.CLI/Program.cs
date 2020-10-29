using System;
using System.IO;
using System.Threading.Tasks;

using System.CommandLine;
using System.CommandLine.Invocation;

namespace DecOR8R.CLI
{
    partial class Program
    {

        static async Task<int> Main(params string[] args)
        {
            var decor8r_ = new RootCommand("decor8r")
            {
                new CommandBuilder("config")
                    .AddCommand(
                        new CommandBuilder("initialize")
                        .Build())
                    .Build(),
                new CommandBuilder("decorate")
                    .AddCommand(
                        new CommandBuilder("terminal")
                        .AddOption<int>(
                            new OptionBuilder<int>("--width", () => System.Console.WindowWidth)
                            .SetDescription("Terminal width")
                            .AddAlias("-w")
                            .Build())
                        .AddOption<Type>(
                            new OptionBuilder<Type>("--type", () => Type.ANSI)
                            .SetDescription("Type of terminal")
                            .AddAlias("-t")
                            .Build())
                        .AddArgument<DirectoryInfo>(
                            new ArgumentBuilder<DirectoryInfo>("path")
                            .SetDescription("Path to decorate")
                            .SetArity(ArgumentArity.ExactlyOne)
                            .Build())
                        .SetHandler(
                            CommandHandler.Create<DirectoryInfo, TerminalOptions>(
                                (DirectoryInfo path, TerminalOptions options) =>
                                {
                                    Console.WriteLine(path);
                                    Console.WriteLine(options.Type);
                                    Console.WriteLine(options.Width);
                                }
                            )
                        )
                        .Build())
                    .AddCommand(
                        new CommandBuilder("neovim")
                        .Build())
                    .AddCommand(
                        new CommandBuilder("tmux")
                        .Build())
                    .Build()
        };

            return await decor8r_.InvokeAsync(args);
        }
    }
}
