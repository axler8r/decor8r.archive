using System.CommandLine;

namespace DecOR8R.CLI
{
    public class CommandBuilder
    {
        private readonly Command __command;

        public CommandBuilder(Command command)
        {
            __command = command;
        }

        public CommandBuilder AddAlias(string alias)
        {
            __command.AddAlias(alias);

            return this;
        }

        public CommandBuilder AddArgument()
        {
            __command.AddArgument(null);

            return this;
        }

        public CommandBuilder AddCommand()
        {
            __command.AddCommand(null);

            return this;
        }

        public CommandBuilder AddOption()
        {
            __command.AddOption(null);

            return this;
        }

        public CommandBuilder AddValidator()
        {
            __command.AddValidator(null);

            return this;
        }

        public Command Build()
        {
            return __command;
        }
    }
}
