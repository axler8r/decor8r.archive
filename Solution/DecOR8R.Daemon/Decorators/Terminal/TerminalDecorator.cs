using Serilog;

using static System.CommandLine.Rendering.Ansi;

namespace DecOR8R.Daemon.Decorators.Terminal;

class TerminalDecorator : IDecorator<string>
{
    private static readonly ILogger Log = Serilog.Log.ForContext<TerminalDecorator>();

    public string Decorate(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
        {
            throw new System.ArgumentException($"'{nameof(subject)}' cannot be null or whitespace.", nameof(subject));
        }

        var result = subject.Replace("/", "  ");
        result = $"{Base16.Foreground.Base2}{Base16.Background.Blue}{result} {Color.Background.Default}{Color.Foreground.Default}{Base16.Foreground.Blue}{Base16.Foreground.Default}";

        return result;
    }
}
