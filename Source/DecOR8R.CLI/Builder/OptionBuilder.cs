using System;
using System.CommandLine;

namespace DecOR8R.CLI
{
    public class OptionBuilder<T>
    {
        private readonly Option<T> __option;

        public OptionBuilder(string name)
        {
            __option = new Option<T>(name);
        }

        public OptionBuilder(string name, Func<T> defaultValue)
        {
            __option = new Option<T>(name, defaultValue);
        }

        public OptionBuilder<T> SetDescription(string description)
        {
            __option.Description = description;

            return this;
        }

        public OptionBuilder<T> SetRequried(bool required)
        {
            __option.IsRequired = required;

            return this;
        }

        public OptionBuilder<T> AddAlias(string alias)
        {
            __option.AddAlias(alias);

            return this;
        }

        private OptionBuilder<T> AddValidator()
        {
            __option.AddValidator(null);

            return this;
        }

        public Option<T> Build()
        {
            return __option;
        }
    }
}
