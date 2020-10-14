using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using static System.Environment;


namespace DecoR8R.CLI
{
    class Program
    {
        static async Task<int> Main(params string[] args)
        {
            var root = new RootCommand("decor8r")
            {
                CreateDecorateCommand()
            };

            return await root.InvokeAsync(args);
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
                description: "Decorate command terminals")
            {
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
                (currentWorkingDirectory, width, shell) =>
                {
                    var _width = width == 0 ? Console.WindowWidth : width;
                    Console.WriteLine($"Decorating {shell}...");
                    Console.WriteLine($"Decorating {currentWorkingDirectory}...");
                    Console.WriteLine($"The width of the terminal is {_width}...");

                    var _components = currentWorkingDirectory.FullName.
                        Split(Path.DirectorySeparatorChar).
                        Where(c => !String.IsNullOrEmpty(c));

                    var _result = "";
                    foreach (var _c in _components)
                    {
                        _result += _c;
                        _result += "  ";
                    }
                    Console.WriteLine($"Result is {_result}...");
                }
            );

            var decorateCommand = new Command("decorate", description: "Decorate the specified prompt or status area")
            {
                decorateShellCommand,
            };

            return decorateCommand;
        }
    }
}
