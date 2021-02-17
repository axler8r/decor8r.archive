using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

using Serilog;

namespace DecOR8R.CLI
{
    internal partial class Program
    {
        private static readonly ILogger _logger = new LoggerConfiguration()
            .WriteTo.File("decor8r.log")
            .CreateLogger();

        public static ILogger Logger => _logger;

        private static async Task<int> Main(params string[] args)
        {
            Logger.Information("About to enter decor8r");

            var decor8r_ = new RootCommand("decor8r")
            {
                new CommandBuilder("configure")
                    .SetDescription("Configure decorator")
                    .AddAlias("config")
                    .AddCommand(new CommandBuilder("initialize")
                        .SetDescription("Create a default configuration file")
                        .AddAlias("init")
                        .SetHandler(CommandHandler.Create(
                            () =>
                            {
                                var config_ = Configurator.GetConfiguration();
                                var json_ = System.Text.Json.JsonSerializer.Serialize(config_);
                                System.Console.WriteLine(json_);
                            }))
                        .Build())
                    .Build(),
                new CommandBuilder("decorate")
                    .AddCommand(new CommandBuilder("terminal")
                        .AddOption<int>(new OptionBuilder<int>(
                                name: "--width",
                                defaultValue: () => System.Console.WindowWidth)
                            .SetDescription("Terminal width")
                            .AddAlias("-w")
                            .Build())
                        .AddOption<TerminalType>(new OptionBuilder<TerminalType>(
                                name: "--type",
                                defaultValue: () => TerminalType.ANSI)
                            .SetDescription("Type of terminal")
                            .AddAlias("-t")
                            .Build())
                        .AddArgument<DirectoryInfo>(new ArgumentBuilder<DirectoryInfo>(
                                name: "path")
                            .SetDescription("Path to decorate")
                            .SetArity(ArgumentArity.ExactlyOne)
                            .Build())
                        .SetHandler(CommandHandler.Create<DirectoryInfo, TerminalDecorationOptions>(
                            (DirectoryInfo path, TerminalDecorationOptions tdos) =>
                            {
                                var configuration_ = Configurator.GetConfiguration();
                                TerminalDecorator.Decorate(path, tdos, configuration_);
                            }))
                        .Build())
                    .AddCommand(new CommandBuilder("neovim")
                        .Build())
                    .AddCommand(new CommandBuilder("tmux")
                        .Build())
                    .Build(),
            };

            Logger.Information("About to exit decor8r");

            return await decor8r_.InvokeAsync(args);
        }
    }
}
