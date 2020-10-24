using System;
using System.IO;

namespace DecoR8R.Configuration
{
    public struct Configuration
    {
        public string PathSeparatorChar { get; set; }

        public bool CompressPath { get; set; }

        public string CompressPathChar { get; set; }

        public bool CompressHomePath { get; set; }

        public string CompressHomePathChar { get; set; }

        public string SectionTerminatorChar { get; set; }
    }

    public class Configurator
    {
        public static Configuration Read(FileInfo file)
        {
            return new Configuration();
        }
    }
}
