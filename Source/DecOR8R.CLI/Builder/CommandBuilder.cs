using System.CommandLine;
using System.CommandLine.Invocation;

namespace DecOR8R.CLI
{
    internal class CommandBuilder
    {
        readonly Command __command;

        internal CommandBuilder(string name)
        {
            // TODO: Add checks for arguments
            __command = new Command(name);
        }

        internal CommandBuilder(string name, string description)
        {
            // TODO: Add checks for arguments
            __command = new Command(name, description);
        }

        internal CommandBuilder SetDescription(string description)
        {
            // TODO: Add checks for arguments
            __command.Description = description;

            return this;
        }

        internal CommandBuilder SetHandler(ICommandHandler handler)
        {
            // TODO: Add checks for arguments
            __command.Handler = handler;

            return this;
        }

        internal CommandBuilder AddAlias(string alias)
        {
            // TODO: Add checks for arguments
            __command.AddAlias(alias);

            return this;
        }

        internal CommandBuilder AddArgument<T>(Argument<T> argument)
        {
            // TODO: Add checks for arguments
            __command.AddArgument(argument);

            return this;
        }

        internal CommandBuilder AddOption<T>(Option<T> option)
        {
            // TODO: Add checks for arguments
            __command.AddOption(option);

            return this;
        }

        internal CommandBuilder AddCommand(Command command)
        {
            // TODO: Add checks for arguments
            __command.AddCommand(command);

            return this;
        }

        private CommandBuilder AddValidator()
        {
            // TODO: Implement!
            // TODO: Add checks for arguments
            __command.AddValidator(null);

            return this;
        }

        internal Command Build()
        {
            return __command;
        }
    }
}
