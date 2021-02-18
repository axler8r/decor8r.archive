using System;
using System.IO;
using System.CommandLine.Rendering;

namespace DecOR8R.CLI
{
    public static class TerminalDecorator
    {
        internal static void Decorate(
            DirectoryInfo path,
            TerminalDecorationOptions tdopts,
            Configuration configuration)
        {
            //Program.Logger.Information("About to enter Decorate");

            var pathToDecorate_ = path.ToString();
            var pathToHome_ = (
                Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX
            ) ? Environment.GetEnvironmentVariable("HOME")
              : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var tilde_ = configuration.Symbol.Common.Tilde;
            pathToDecorate_ = pathToDecorate_.Replace(pathToHome_, tilde_);
            var l2rSoft_ = configuration.Symbol.Common.Delimit.LeftToRight.Soft;
            var paths_ = pathToDecorate_.Replace(Path.DirectorySeparatorChar.ToString(), $" {l2rSoft_} ");

            Console.WriteLine($"{Ansi.Color.Background.LightBlue}{Ansi.Color.Foreground.White}{paths_}{Ansi.Color.Foreground.Default}{Ansi.Color.Background.Default}");

            //Program.Logger.Information("About to exit Decorate");
        }
    }
}
