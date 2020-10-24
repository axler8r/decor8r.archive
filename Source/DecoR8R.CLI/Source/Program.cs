using System.CommandLine;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace DecoR8R.CLI
{
    class Program
    {
        private static readonly ILogger<Program> _logger;

        static async Task<int> Main(params string[] args)
        {
            var root_ = new RootCommand("decor8r")
            {
                CreateDecorateCommands()
            };

            return await root_.InvokeAsync(args);
        }

        private static Command CreateDecorateCommands()
        {
            _logger.LogTrace("Createing decorate commands...");

            var result_ = new Command(
                name: "decorate",
                description: "Decorate shell, tmux or Neovim");
            result_.AddCommand(Terminal.Factory.CreateCommand());

            return result_;
        }
    }
}
