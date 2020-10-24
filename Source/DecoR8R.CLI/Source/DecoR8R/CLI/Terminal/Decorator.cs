using System.IO;
using System.Linq;

using DecoR8R.Configuration;

namespace DecoR8R.CLI.Terminal
{
    class Decorator
    {
        internal static string Decorate(DirectoryInfo path, TerminalDecorationOptions options)
        {
            // split the path into inidvitual directories
            var hierarchy_ = path.ToString()
                .Split(Path.DirectorySeparatorChar)
                .Where(h_ => !string.IsNullOrEmpty(h_));
            System.Console.WriteLine(hierarchy_);
            // read path compression configuration if it exists
            var configuration_ = DecoR8R.Configuration.Configurator.Read(null);
            System.Console.Write(configuration_);
            // read the directory colorization configuration if it exists
            // read the direcotry separator configuraiton if it exists
            // determine the width of the terminal
            // add separators and colorize path

            foreach (var dir_ in hierarchy_)
            {
                System.Console.WriteLine(dir_);
            }
            System.Console.WriteLine(options.Colour);

            return "";
        }
    }
}
