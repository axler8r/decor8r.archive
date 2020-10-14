using System.CommandLine;
using System.CommandLine.Builder;
using System.IO;

using static System.Environment;

namespace DecoR8R.CLI
{
    class ConfigureCommandFactory
    {
        static Command CreateConfigureCommand()
        {
            var configureCommandBuilder_ = FactoryUtilities.NewCommandBuilder(
                new Command(name: "config", description: "Configuration driver")
            );

            configureCommandBuilder_.AddArgument(
                new Argument<DirectoryInfo>(
                    name: "direcotry",
                    description: "Configuration directory",
                    getDefaultValue: DefaultConfigurationDirectory)
                {
                    Name = "DIR",
                    Description = "Configuration directory",
                    Arity = ArgumentArity.ZeroOrOne,
                }
            );

            configureCommandBuilder_.AddOption(
                new Option<FileInfo>(
                    aliases:new string[] {"-f", "--file"},
                    description: "Template configureation file"
                )
            );

            return configureCommandBuilder_.Command;
        }

        private static DirectoryInfo DefaultConfigurationDirectory()
        {

            var defaultConfigurationDirectory_ = new DirectoryInfo(
                Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "decor8r")
            );
            if (!defaultConfigurationDirectory_.Exists)
            {
                defaultConfigurationDirectory_.Create();
            }
            return defaultConfigurationDirectory_;
        }
    }

    class DecorateCommandFactory
    {
        static Command CreateDecorateCommand() {
            var decoratorCommandBuilder_ = FactoryUtilities.NewCommandBuilder(
                new Command(name: "decorate", description: "Decoration driver")
            );

            return decoratorCommandBuilder_.Command;
        }
    }

    class FactoryUtilities
    {
        internal static CommandLineBuilder GetNewCommandLineBuilder()
        {
            var builder_ = new CommandLineBuilder();

            return builder_;
        }

        internal static CommandBuilder NewCommandBuilder(Command command)
        {
            if (command is null)
            {
                throw new System.ArgumentNullException(nameof(command));
            }

            var commandBuilder_ = new CommandBuilder(command);

            return commandBuilder_;
        }
    }
}
