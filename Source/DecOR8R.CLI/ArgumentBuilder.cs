using System.CommandLine;

namespace DecOR8R.CLI
{
    public class ArgumentBuilder<T>
    {
        private readonly Argument<T> __argument;

        public ArgumentBuilder(string name)
        {
            // TODO: Add checks for arguments
            __argument = new Argument<T>(name);
        }

        public ArgumentBuilder(string name, string description)
        {
            // TODO: Add checks for arguments
            __argument = new Argument<T>(name, description);
        }

        public ArgumentBuilder<T> AddAlias(string alias)
        {
            // TODO: Add checks for arguments
            __argument.AddAlias(alias);

            return this;
        }

        public ArgumentBuilder<T> SetArity(ArgumentArity arity)
        {
            // TODO: Add checks for arguments
            __argument.Arity = arity;

            return this;
        }

        public ArgumentBuilder<T> SetDescription(string description)
        {
            // TODO: Add checks for arguments
            __argument.Description = description;

            return this;
        }

        public ArgumentBuilder<T> SetDefaultValue(T value)
        {
            // TODO: Add checks for arguments
            __argument.SetDefaultValue(value);

            return this;
        }

        private ArgumentBuilder<T> AddValidator()
        {
            // TODO: Implement!
            // TODO: Add checks for arguments
            __argument.AddValidator(null);

            return this;
        }

        public Argument Build()
        {
            return __argument;
        }
    }
}
