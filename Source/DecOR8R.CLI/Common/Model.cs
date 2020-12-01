namespace DecOR8R.CLI
{
    internal enum TerminalType
    {
        ANSI,
        MonoChrome,
    }

    internal class TerminalSepcification
    {
        internal TerminalSepcification(int width, TerminalType type)
        {
            this.Width = width;
            this.Type = type;
        }

        internal TerminalType Type { get; private set; }

        internal int Width { get; private set; }
    }

    internal class TerminalDecorationConfiguration
    {
    }
}
