using System.CommandLine;

namespace DecOR8R.CLI
{
    internal class ArgumentBuilder<T>
    {
        private readonly Argument<T> __argument;

        internal ArgumentBuilder(string name)
        {
            // TODO: Add checks for arguments
            __argument = new Argument<T>(name);
        }

        internal ArgumentBuilder(string name, string description)
        {
            // TODO: Add checks for arguments
            __argument = new Argument<T>(name, description);
        }

        internal ArgumentBuilder<T> AddAlias(string alias)
        {
            // TODO: Add checks for arguments
            __argument.AddAlias(alias);

            return this;
        }

        internal ArgumentBuilder<T> SetArity(IArgumentArity arity)
        {
            // TODO: Add checks for arguments
            __argument.Arity = arity;

            return this;
        }

        internal ArgumentBuilder<T> SetDescription(string description)
        {
            // TODO: Add checks for arguments
            __argument.Description = description;

            return this;
        }

        internal ArgumentBuilder<T> SetDefaultValue(T value)
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

        internal Argument<T> Build()
        {
            return __argument;
        }
    }
}
