using System;
using System.CommandLine;

namespace DecOR8R.CLI
{
    internal class OptionBuilder<T>
    {
        private readonly Option<T> __option;

        internal OptionBuilder(string name)
        {
            __option = new Option<T>(name);
        }

        internal OptionBuilder(string name, Func<T> defaultValue)
        {
            __option = new Option<T>(name, defaultValue);
        }

        internal OptionBuilder<T> SetDescription(string description)
        {
            __option.Description = description;

            return this;
        }

        internal OptionBuilder<T> SetRequried(bool required)
        {
            __option.IsRequired = required;

            return this;
        }

        internal OptionBuilder<T> AddAlias(string alias)
        {
            __option.AddAlias(alias);

            return this;
        }

        private OptionBuilder<T> AddValidator()
        {
            __option.AddValidator(null);

            return this;
        }

        internal Option<T> Build()
        {
            return __option;
        }
    }
}
