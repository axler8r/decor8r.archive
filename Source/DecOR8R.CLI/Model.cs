namespace DecOR8R.CLI
{
    public enum TerminalType
    {
        ANSI,
        MonoChrome,
    }

    public class TerminalSepcification
    {
        public TerminalSepcification(int width, TerminalType type)
        {
            this.Width = width;
            this.Type = type;
        }

        public TerminalType Type { get; private set; }

        public int Width { get; private set; }
    }

    public class TerminalDecorationConfiguration
    {
    }
}
