using System;
using System.IO;
using System.Text;

namespace DecOR8R.CLI
{
    public static class TerminalDecorator
    {
        internal static void Decorate(
            DirectoryInfo path,
            TerminalSepcification termSpec,
            TerminalDecorationConfiguration configuration)
        {
            var pathToDecorate_ = path.ToString();
            var pathToHome_ = (
                Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX
            ) ? Environment.GetEnvironmentVariable("HOME")
              : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            pathToDecorate_ = pathToDecorate_.Replace(pathToHome_, "~");
            var paths_ = pathToDecorate_.Replace(Path.DirectorySeparatorChar.ToString(), "  ");

            var x_ = " ";

            var currentEncoding_ = Console.OutputEncoding;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{x_}, {pathToHome_}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(paths_);
            Console.ResetColor();
            Console.OutputEncoding = currentEncoding_;
        }
    }
}
