using System;
using System.Collections.Generic;
using System.CommandLine.Rendering;

namespace DecOR8R.CLI
{
#nullable enable
    interface ISegment
    {
        internal AnsiControlCode? Foreground { get; }
        internal AnsiControlCode? Background { get; }
        internal AnsiControlCode? Style { get; }
        internal IFormattable? Leader { get; } // Leading spacer(s)
        internal IFormattable? Separator { get; } // Format glyph(s)
        internal IFormattable? Trailer { get; } // Trailing spacer(s)
        internal IList<ISegment>? Segments { get; }
        internal string Content { get; }
        internal string Render<C>(C configuration) where C : class?;
    }
#nullable disable
}
