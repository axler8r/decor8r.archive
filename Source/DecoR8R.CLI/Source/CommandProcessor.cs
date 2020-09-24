using System.CommandLine;

namespace DecoR8R.CLI {
    internal class ProcessorFactory {
        static ConfigureCommandProcessor NewConfigureCommandProcessor() {
            return new ConfigureCommandProcessor();
        }

        static ConfigureCommandProcessor.ImportCommandProcessor NewConfigureImportCommandProcessor() {
            return new ConfigureCommandProcessor.ImportCommandProcessor();
        }
    }

    internal class ConfigureCommandProcessor {
        internal ConfigureCommandProcessor() {
        }

        internal class ImportCommandProcessor {
            internal ImportCommandProcessor() {
            }
        }
    }

    internal class DecorateCommandProcessor {
        internal DecorateCommandProcessor() {
        }

        internal class ShellCommandProcessor
        {
            internal ShellCommandProcessor() {
            }
        }
        internal class TMuxCommandProcessor
        {
            internal TMuxCommandProcessor() {
            }
        }
        internal class NeoVimCommandProcessor
        {
            internal NeoVimCommandProcessor() {
            }
        }
    }
}
