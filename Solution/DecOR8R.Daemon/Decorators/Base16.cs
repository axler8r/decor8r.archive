using System.CommandLine.Rendering;
using static System.CommandLine.Rendering.Ansi;

namespace DecOR8R.Daemon.Decorators;

internal static class Base16
{
    internal static class Foreground
    {
        internal static AnsiControlCode Default => Color.Foreground.Default;
        internal static AnsiControlCode Base03 => Color.Foreground.DarkGray;
        internal static AnsiControlCode Base02 => Color.Foreground.Black;
        internal static AnsiControlCode Base01 => Color.Foreground.LightGreen;
        internal static AnsiControlCode Base00 => Color.Foreground.LightYellow;
        internal static AnsiControlCode Base0 => Color.Foreground.LightBlue;
        internal static AnsiControlCode Base1 => Color.Foreground.LightCyan;
        internal static AnsiControlCode Base2 => Color.Foreground.White;
        internal static AnsiControlCode Base3 => Color.Foreground.LightGray;
        internal static AnsiControlCode Red => Color.Foreground.Red;
        internal static AnsiControlCode Orange => Color.Foreground.LightRed;
        internal static AnsiControlCode Yellow => Color.Foreground.Yellow;
        internal static AnsiControlCode Green => Color.Foreground.Green;
        internal static AnsiControlCode Blue => Color.Foreground.Blue;
        internal static AnsiControlCode Cyan => Color.Foreground.Cyan;
        internal static AnsiControlCode Magenta => Color.Foreground.Magenta;
        internal static AnsiControlCode Violet => Color.Foreground.LightMagenta;
    }

    internal static class Background
    {
        internal static AnsiControlCode Default => Color.Background.Default;
        internal static AnsiControlCode Base03 => Color.Background.DarkGray;
        internal static AnsiControlCode Base02 => Color.Background.Black;
        internal static AnsiControlCode Base01 => Color.Background.LightGreen;
        internal static AnsiControlCode Base00 => Color.Background.LightYellow;
        internal static AnsiControlCode Base0 => Color.Background.LightBlue;
        internal static AnsiControlCode Base1 => Color.Background.LightCyan;
        internal static AnsiControlCode Base2 => Color.Background.White;
        internal static AnsiControlCode Base3 => Color.Background.LightGray;
        internal static AnsiControlCode Red => Color.Background.Red;
        internal static AnsiControlCode Orange => Color.Background.LightRed;
        internal static AnsiControlCode Yellow => Color.Background.Yellow;
        internal static AnsiControlCode Green => Color.Background.Green;
        internal static AnsiControlCode Blue => Color.Background.Blue;
        internal static AnsiControlCode Cyan => Color.Background.Cyan;
        internal static AnsiControlCode Magenta => Color.Background.Magenta;
        internal static AnsiControlCode Violet => Color.Background.LightMagenta;
    }
}
