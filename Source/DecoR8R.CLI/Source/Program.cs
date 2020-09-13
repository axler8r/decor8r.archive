using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
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

        private static Command CreateConfigureCommand()
        {
            var configureInitCommand = new Command(
                "init",
                description: "Initialize decor8r") {
                new Option<DirectoryInfo>(
                    new string[] {"-d", "--directory"},
                    description: "Custom configuration directory"
                ).ExistingOnly(),
                new Option<FileInfo>(
                    new string[] {"-i", "--import"},
                    description: "Import existing configuration file"
                ).ExistingOnly(),
            };
            configureInitCommand.AddAlias("initialize");
            configureInitCommand.Handler = CommandHandler.Create<FileSystemInfo, FileSystemInfo>(
                (directory, import) =>
                {
                    Console.WriteLine("In init command hadler...");
                    Console.WriteLine($"DirectoryInfo is {directory}...");
                    Console.WriteLine($"FileInfo is {import}...");
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
                (show) =>
                {
                    Console.WriteLine("In configure command handler...");
                    Console.WriteLine($"Show is {show}...");
                }
            );

            return configureCommand;
        }

        private enum Shell
        {
            Bash,
            Fish,
            PowerShell,
            ZSH,
        }

        private static Command CreateDecorateCommand()
        {
            var decorateShellCommand = new Command(
                "shell",
                description: "Decorate command terminals") {
                    new Option<int>(
                        new string[] {"-w", "--width"},
                        description: "Width of the terminal"
                    ),
                    new Option<DirectoryInfo> (
                        new string[] {"-c", "--current-working-directory"},
                        description: "Directory to decorate"
                    ).ExistingOnly(),
                    new Argument<Shell>("shell"),
            };
            decorateShellCommand.Handler = CommandHandler.Create<FileSystemInfo, int, Shell>(
                (currentWorkingDirectory, width, shell) => {
                    var _width = width == 0 ? Console.WindowWidth : width;
                    Console.WriteLine($"Decorating {shell}...");
                    Console.WriteLine($"Decorating {currentWorkingDirectory}...");
                    Console.WriteLine($"The width of the terminal is {_width}...");

                    var _components = currentWorkingDirectory.FullName.
                        Split(Path.DirectorySeparatorChar).
                        Where(c => !String.IsNullOrEmpty(c));
                    
                    var _result = "";
                    foreach (var _c in _components) {
                        _result += _c;
                        _result += "  ";
                    }
                    Console.WriteLine($"Result is {_result}...");
                }
            );

            var decorateTMuxCommand = new Command(
                "tmux",
                description: "Decorate tmux status line(s)");
            decorateTMuxCommand.Handler = CommandHandler.Create(
                () => {}
            );
            
            var decorateNeovimCommand = new Command(
                "nvim",
                description: "Decorate Neovim status line(s)");
            decorateNeovimCommand.Handler = CommandHandler.Create(
                () => {}
            );
            
            var decorateCommand = new Command(
                "decorate",
                description: "Decorate the specified prompt or status area") {
                decorateShellCommand,
                decorateTMuxCommand,
                decorateNeovimCommand
            };

            return decorateCommand;
        }
   }
}
