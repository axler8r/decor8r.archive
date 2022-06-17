using System;
using static System.CommandLine.Rendering.Ansi;

namespace DecOR8R.Daemon.Decorators.Terminal;

internal class TerminalDecorator : IDecorator<string>
{
    public string Decorate(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new ArgumentException($"'{nameof(subject)}' cannot be null or whitespace.", nameof(subject));

        var result_ = subject.Replace("/", "  ");
        result_ = $"{Base16.Foreground.Base2}{Base16.Background.Blue}{result_} {Color.Background.Default}{Color.Foreground.Default}{Base16.Foreground.Blue}{Base16.Foreground.Default}";

        return result_;
    }
}
