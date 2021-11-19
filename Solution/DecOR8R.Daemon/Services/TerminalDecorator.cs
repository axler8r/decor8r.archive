using Serilog;

namespace DecOR8R.Daemon.Services;

public class TerminalDecorator
{
    private static readonly ILogger Log = Serilog.Log.ForContext<TerminalDecorator>();

    internal string Decorate(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new System.ArgumentException($"'{nameof(path)}' cannot be null or whitespace.", nameof(path));
        }

        var result = path.Replace("/", "  ");

        return result;
    }
}
