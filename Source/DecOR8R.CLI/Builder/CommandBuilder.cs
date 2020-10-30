using System.CommandLine;
using System.CommandLine.Invocation;

namespace DecOR8R.CLI
{
    public class CommandBuilder
    {
        private readonly Command __command;

        public CommandBuilder(string name)
        {
            // TODO: Add checks for arguments
            __command = new Command(name);
        }

        public CommandBuilder(string name, string description)
        {
            // TODO: Add checks for arguments
            __command = new Command(name, description);
        }

        public CommandBuilder SetDescription(string description)
        {
            // TODO: Add checks for arguments
            __command.Description = description;

            return this;
        }

        public CommandBuilder SetHandler(ICommandHandler handler)
        {
            // TODO: Add checks for arguments
            __command.Handler = handler;

            return this;
        }

        public CommandBuilder AddAlias(string alias)
        {
            // TODO: Add checks for arguments
            __command.AddAlias(alias);

            return this;
        }

        public CommandBuilder AddArgument<T>(Argument<T> argument)
        {
            // TODO: Add checks for arguments
            __command.AddArgument(argument);

            return this;
        }

        public CommandBuilder AddOption<T>(Option<T> option)
        {
            // TODO: Add checks for arguments
            __command.AddOption(option);

            return this;
        }

        public CommandBuilder AddCommand(Command command)
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

        public Command Build()
        {
            return __command;
        }
    }
}
