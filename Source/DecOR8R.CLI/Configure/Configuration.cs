using System;
using System.Text.Json.Serialization;

namespace DecOR8R.CLI
{
    public class Configuration
    {
        public class _Symbol
        {
            public class _Common
            {
                [JsonPropertyName("at")]
                public string At { get; private set; } = Char.ConvertFromUtf32(0x0040);

                [JsonPropertyName("bar")]
                public string Bar { get; private set; } = Char.ConvertFromUtf32(0x007C);

                [JsonPropertyName("tilde")]
                public string Tilde { get; private set; } = Char.ConvertFromUtf32(0x007E);

                [JsonPropertyName("elipsis")]
                public string Elipsis { get; private set; } = Char.ConvertFromUtf32(0x2026);

                [JsonPropertyName("dash")]
                public string Dash { get; private set; } = Char.ConvertFromUtf32(0x2212);

                public class _Delimit
                {
                    public class _LeftToRight
                    {
                        [JsonPropertyName("hard")]
                        public string Hard { get; private set; } = Char.ConvertFromUtf32(0xE0B0);

                        [JsonPropertyName("soft")]
                        public string Soft { get; private set; } = Char.ConvertFromUtf32(0xE0B1);
                    }

                    public class _RightToLeft
                    {
                        [JsonPropertyName("hard")]
                        public string Hard { get; private set; } = Char.ConvertFromUtf32(0xE0B2);

                        [JsonPropertyName("soft")]
                        public string Soft { get; private set; } = Char.ConvertFromUtf32(0xE0B3);
                    }

                    [JsonPropertyName("leftToRight")]
                    public _LeftToRight LeftToRight { get; private set; } = new _LeftToRight();

                    [JsonPropertyName("rightToLeft")]
                    public _RightToLeft RightToLeft { get; private set; } = new _RightToLeft();
                }

                [JsonPropertyName("delimit")]
                public _Delimit Delimit { get; private set; } = new _Delimit();
            }

            public class _Terminal
            {
                public class _Version
                {
                    [JsonPropertyName("branch")]
                    public string Branch { get; private set; } = Char.ConvertFromUtf32(0xE0A0);

                    [JsonPropertyName("stash")]
                    public string Stash { get; private set; } = Char.ConvertFromUtf32(0x00A4);

                    [JsonPropertyName("ahead")]
                    public string Ahead { get; private set; } = Char.ConvertFromUtf32(0x2191);

                    [JsonPropertyName("behind")]
                    public string Behind { get; private set; } = Char.ConvertFromUtf32(0x2193);

                    [JsonPropertyName("aheadBehind")]
                    public string AheadBehind { get; private set; } = Char.ConvertFromUtf32(0x2195);

                    [JsonPropertyName("equivalent")]
                    public string Equivalent { get; private set; } = Char.ConvertFromUtf32(0x2261);

                    [JsonPropertyName("add")]
                    public string Add { get; private set; } = Char.ConvertFromUtf32(0x002B);

                    [JsonPropertyName("remove")]
                    public string Remove { get; private set; } = Char.ConvertFromUtf32(0x2212);

                    [JsonPropertyName("modify")]
                    public string Modify { get; private set; } = Char.ConvertFromUtf32(0x0394);

                    [JsonPropertyName("conflict")]
                    public string Conflict { get; private set; } = Char.ConvertFromUtf32(0x002A);
                }

                [JsonPropertyName("version")]
                public _Version Version { get; private set; } = new _Version();
            }

            [JsonPropertyName("common")]
            public _Common Common { get; private set; } = new _Common();

            [JsonPropertyName("terminal")]
            public _Terminal Terminal { get; private set; } = new _Terminal();
        }

        [JsonPropertyName("symbol")]
        public _Symbol Symbol { get; private set; } = new _Symbol();
    }
}
