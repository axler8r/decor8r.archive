namespace DecOR8R.CLI
{
    public enum Type
    {
        ANSI,
        MonoChrome
    }

    public class TerminalOptions
    {
        public TerminalOptions(int width, Type type)
        {
            Width = width;
            Type = type;
        }

        public Type Type { get; private set; }

        public int Width { get; private set; }
    }
}
