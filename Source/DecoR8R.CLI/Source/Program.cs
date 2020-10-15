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
                CreateDecorateCommands()
            };

            return await root.InvokeAsync(args);
        }

        private static Command CreateDecorateCommands()
        {
            var result_ = new Command(
                name: "decorate",
                description: "Decorate shell, tmux or Neovim");
            result_.AddAlias("d");
            result_.AddCommand(CreateDecorateShellCommand());

            return result_;
        }

        private enum Shell
        {
            Bash,
            PowerShell,
            ZSH,
        }

        private static Command CreateDecorateShellCommand()
        {
            var result_ = new Command(
                name: "shell",
                description: "Decorate command prompt"
            );

            var shell_ = new Argument<Shell>(
                name: "shell",
                description: "Target shell"
            );
            result_.AddArgument(shell_);

            var path_ = new Argument<FileSystemInfo>(
                name: "path",
                description: "Path to decorate"
            );
            result_.AddArgument(path_);

            result_.Handler = CommandHandler.Create<Shell, DirectoryInfo> (HandleShellDecoration);

            return result_;
        }

        private static void HandleShellDecoration(Shell shell, DirectoryInfo path)
        {
            Console.Out.WriteLine(shell);
            Console.Out.WriteLine(path);
        }
    }

    class DecorateCommandBuilder
    {
    }
}
