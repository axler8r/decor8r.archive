using System;
using System.Text.Json.Serialization;

namespace DecOR8R.CLI
{
    public class Configuration
    {
        public class Symbol_
        {
            public class Common_
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

                public class Delimit_
                {
                    public class LeftToRight_
                    {
                        [JsonPropertyName("hard")]
                        public string Hard { get; private set; } = Char.ConvertFromUtf32(0xE0B0);

                        [JsonPropertyName("soft")]
                        public string Soft { get; private set; } = Char.ConvertFromUtf32(0xE0B1);
                    }

                    public class RightToLeft_
                    {
                        [JsonPropertyName("hard")]
                        public string Hard { get; private set; } = Char.ConvertFromUtf32(0xE0B2);

                        [JsonPropertyName("soft")]
                        public string Soft { get; private set; } = Char.ConvertFromUtf32(0xE0B3);
                    }

                    [JsonPropertyName("leftToRight")]
                    public LeftToRight_ LeftToRight { get; private set; } = new LeftToRight_();

                    [JsonPropertyName("rightToLeft")]
                    public RightToLeft_ RightToLeft { get; private set; } = new RightToLeft_();
                }

                [JsonPropertyName("delimit")]
                public Delimit_ Delimit { get; private set; } = new Delimit_();
            }

            public class Terminal_
            {
                public class Version_
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
                public Version_ Version { get; private set; } = new Version_();
            }

            [JsonPropertyName("common")]
            public Common_ Common { get; private set; } = new Common_();

            [JsonPropertyName("terminal")]
            public Terminal_ Terminal { get; private set; } = new Terminal_();
        }

        [JsonPropertyName("symbol")]
        public Symbol_ Symbol { get; private set; } = new Symbol_();
    }
}
