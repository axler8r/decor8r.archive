using System;
using System.IO;
using System.Text;

namespace DecOR8R.CLI
{
    public static class TerminalDecorator
    {
        public static void Decorate(
            DirectoryInfo path,
            TerminalSepcification termSpec,
            TerminalDecorationConfiguration configuration)
        {

            var paths_ = path.ToString().Split(Path.DirectorySeparatorChar);
            var builder_ = new StringBuilder();
            foreach (var path_ in paths_)
            {
                builder_.Append(path_).Append(" > ");
            }
            Console.WriteLine(builder_.ToString());
        }
    }
}
