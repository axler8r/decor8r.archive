using Serilog;

namespace DecOR8R.Daemon.Services;

public class TerminalDecorator
{
    private static readonly ILogger Log = Serilog.Log.ForContext<TerminalDecorator>();

    internal string Decorate(string path)
    {
        var result = path.Replace("/", "  ");

        return result;
    }
}
