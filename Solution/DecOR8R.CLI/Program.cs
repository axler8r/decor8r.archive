using System;
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
            var decor8r_ = new RootCommand() {
                new OptionBuilder<FileInfo>("--configuration")
                    .AddAlias("--config")
                    .SetRequried(false)
                    .Build(),
                new ArgumentBuilder<String>(
                    name: "path",
                    description: "Path to decorate")
                    .Build()
            };
            decor8r_.Handler = CommandHandler.Create<FileInfo, String>((configuration, path) =>
            {
                if (configuration != null && !configuration.Exists)
                {
                    System.Console.WriteLine(String.Format(
                        "{0}\n\t{1}\n\t{2}\n\t{3}",
                        "Error! Cannot load configuration file (ECFG000).",
                        "To learn more, run: decor8r describe ECFG000.",
                        "To create a valid configuration file run: decor8r config init.",
                        "For more information visit https://github.com/axler8r/decor8r/wiki/Configuration."));
                }
                else
                {
                    System.Console.WriteLine(path);
                }
            });

            return await decor8r_.InvokeAsync(args);
        }
    }
}
