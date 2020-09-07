using CommandLine;

namespace DecoR8R.CLI.Configuration
{
    // TODO: Turn mutex comands (init & show) into verbs
    [Verb("config", HelpText = "Configure DecoR8R.")]
    public class ConfigurationCommand
    {
        private const string CONFIG_DIRECTORY = "~/.config/decor8r";

        [Option('i', "init",
                SetName = "Initialization",
                HelpText = "Create or orverwrite configuration file.")]
        public bool Initialize { get; set; } = false;

        [Option('d', "directory",
                SetName = "Initialization",
                MetaValue = "DIR",
                HelpText = "Configuration directory.")]
        public string Directory { get; set; } = CONFIG_DIRECTORY;

        [Option('s', "show",
                SetName = "Information",
                HelpText = "Show current configuration.")]
        public bool ShowConfiguration { get; set; } = false;
    }
}
