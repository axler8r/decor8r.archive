using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

namespace DecoR8R.CLI
{
    class Program
    {
        static async Task<int> Main(params string[] args)
        {
            var configureCommand = CreateConfigureCommand();
            var decorateCommand = CreateDecorateCommand();
            var root = new RootCommand("decor8r") {
                configureCommand,
                decorateCommand
            };

            return await root.InvokeAsync(args);
        }

        private static Command CreateDecorateCommand()
        {
            var decorateShellCommand = new Command(
                "shell",
                description: "Decorate command terminals") {
                new Argument<string>("shell"),
            };
            decorateShellCommand.Handler = CommandHandler.Create<string>(
                (s) => {
                    Console.WriteLine($"Decorating {s}...");
                }
            );

            var decorateTMuxCommand = new Command(
                "tmux",
                description: "Decorate tmux status line(s)");
            
            var decorateNeovimCommand = new Command(
                "nvim",
                description: "Decorate Neovim status line(s)");
            
            var decorateCommand = new Command(
                "decorate",
                description: "Decorate the specified prompt or status area") {
                decorateShellCommand,
                decorateTMuxCommand,
                decorateNeovimCommand
            };

            return decorateCommand;
        }

        private static Command CreateConfigureCommand()
        {
            var configureInitCommand = new Command(
                "init",
                description: "Initialize decor8r") {
                new Option<DirectoryInfo>(
                    new string[] {"-d", "--directory"},
                    description: "Custom configuration directory"
                ),
                new Option<FileInfo>(
                    new string[] {"-i", "--import"},
                    description: "Import existing configuration file"
                ),
            };
            configureInitCommand.AddAlias("initialize");
            configureInitCommand.Handler = CommandHandler.Create<DirectoryInfo, FileInfo>(
                (di, fi) =>
                {
                    Console.WriteLine("In init command hadler...");
                }
            );

            var configureCommand = new Command(
                "config",
                description: "Configure decor8r") {
                new Option<bool>(
                    new string[] {"-s", "--show"},
                    description: "Show the current configuration"
                ),
                configureInitCommand,
            };
            configureCommand.AddAlias("configure");
            configureCommand.Handler = CommandHandler.Create<bool>(
                (b) =>
                {
                    Console.WriteLine("In configure command handler...");
                }
            );

            return configureCommand;
        }
    }
}
