using static System.CommandLine.Rendering.Ansi;
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
        result = $"{Base16.Foreground.Base2}{Base16.Background.Blue}{result}{Color.Background.Default}{Color.Foreground.Default}{Base16.Foreground.Blue} {Base16.Foreground.Default}";

        return result;
    }
}
