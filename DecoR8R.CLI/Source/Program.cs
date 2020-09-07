using DecoR8R.CLI.Configuration;
using CommandLine;
using System;

namespace DecoR8R.CLI
{
    class Program
    {
        static int Main(string[] args)
        {
            Parser.Default.ParseArguments<ConfigurationCommand>(args)
                .WithParsed<ConfigurationCommand>(RunConfigurationCommand);
            return 0;
        }

        private static void RunConfigurationCommand(ConfigurationCommand configuration) {
            Console.WriteLine(configuration.Directory);
        }
    }
}
