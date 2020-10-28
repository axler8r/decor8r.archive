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

        public OptionBuilder(string name, string description)
        {
            __option = new Option<T>(name, description);
        }

        public OptionBuilder(string[] names)
        {
            __option = new Option<T>(names);
        }

        public OptionBuilder(string[] names, string description)
        {
            __option = new Option<T>(names, description);
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

        public Option Build()
        {
            return __option;
        }
    }
}
