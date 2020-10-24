using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;


namespace DecoR8R.CLI.Terminal
{
    internal enum TerminalColourSupport
    {
        ANSI,
        Monochrome,
    }

    internal struct TerminalDecorationOptions
    {
        public TerminalDecorationOptions(TerminalColourSupport colour = TerminalColourSupport.ANSI)
        {
            Colour = colour;
        }

        public TerminalColourSupport Colour { get; private set; }
    }

    internal static class Factory
    {
        internal static Command CreateCommand()
        {
            var result_ = new Command(name: "terminal", description: "Decorate command prompt")
            {
                new Option<TerminalDecorationOptions>(
                    aliases: new [] {"--colour", "--color", "-c"},
                    description: "Terminal color support"),
                new Argument<FileSystemInfo>(
                    name: "path",
                    description: "Path to decorate"),
            };
            result_.Handler = CommandHandler.Create<DirectoryInfo, TerminalDecorationOptions>(
                (DirectoryInfo path, TerminalDecorationOptions options) =>
                    Terminal.Decorator.Decorate(path, options)
            );

            return result_;
        }
    }
}
