namespace DecOR8R.CLI
{
    internal class TerminalDecorationOptions
    {
        internal TerminalDecorationOptions(int width, TerminalType type)
        {
            this.Width = width;
            this.Type = type;
        }

        internal TerminalType Type { get; private set; }

        internal int Width { get; private set; }
    }
}
