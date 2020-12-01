namespace DecOR8R.CLI
{
    internal struct Configuration
    {
        public char Tilde { get; private set; }

        public char Elipsis { get; private set; }

        public char RightPathSeparator { get; private set; }
        
        public char RightSectionTerminator { get; private set; }
        
        public char LeftPathSeparator { get; private set; }
        
        public char LeftSectionTerminator { get; private set; }
        
        public char CompressionCharacter { get; private set; }
    }

    internal class Configurator
    {
        internal Configurator() {}

        internal static TerminalDecorationConfiguration GetTerminalDecorationConfiguration()
        {
            return new TerminalDecorationConfiguration();
        }
    }
}
