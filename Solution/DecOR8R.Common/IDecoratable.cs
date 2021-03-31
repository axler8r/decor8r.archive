using System;
using System.Collections.Generic;

namespace DecOR8R.Common
{
    /// <summary>
    /// A decoratable construct like a terminal command prompt, vim status line or tmux status bar.
    /// </summary>
    public interface IDecoratable
    {
        /// <summary>
        /// The thing that will be decorated.
        /// </summary>
        public string Subject { get; }
    }
}
