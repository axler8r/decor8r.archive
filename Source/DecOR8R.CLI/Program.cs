using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

namespace DecOR8R.CLI
{
    internal partial class Program
    {
        private static async Task<int> Main(params string[] args)
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
                        .AddOption<TerminalType>(
                            new OptionBuilder<TerminalType>("--type", () => TerminalType.ANSI)
                            .SetDescription("Type of terminal")
                            .AddAlias("-t")
                            .Build())
                        .AddArgument<DirectoryInfo>(
                            new ArgumentBuilder<DirectoryInfo>("path")
                            .SetDescription("Path to decorate")
                            .SetArity(ArgumentArity.ExactlyOne)
                            .Build())
                        .SetHandler(
                            CommandHandler.Create<DirectoryInfo, TerminalSepcification>(
                                (DirectoryInfo path, TerminalSepcification termSpec) =>
                                {
                                    var terminalConfiguration_ = Configurator.GetTerminalDecorationConfiguration();
                                    TerminalDecorator.Decorate(path, termSpec, terminalConfiguration_);
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
                    .Build(),
            };

            return await decor8r_.InvokeAsync(args);
        }
    }
}
