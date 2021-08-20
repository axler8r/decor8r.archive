# Design
`DecoR8R` informs its users about their environment. It does not try to display all relevant and pertinent information on the command line. Instead, it shares the repsonsibility to inform accross `tmux`, `nvim` and the shell (`zsh`, `bash`, `pwsh` and `fish`).

It is opinionated. It does not try to cover all tools or environements.


## Goals
* Sensible defaults
* Intuitive
* Themes


## Questions
* Should PWD be handled as:
    1. [×] A string
    1. [ ] A DirectoryInfo


## Components
1. **CLI** (_executable_)
    * Generate shell, nvim and tmux functions
    * Send decoration request to Daemon
    * Hand responses over to decoration shell, nvim and tmux functions
    * Handle errors gracefully
    * Testing provided by **CLI Test** (_project_)
1. **Common Services** (_library_), (TODO: need this?)
    * Add, remove, find, modify configuration elements
1. **Daemon** (_executable_, _daemon_)
    * Accept requests from CLI
    * Hand over requests to appropriate decorator
    * Retrun response to CLI
    * Implement reasonable uptime functionality
1. **NeoVim Decorator** (_library_)
    * Accept requests from Daemon
    * Create decorations for NeoVim status bar
    * Create decorations for NeoVim tab bar
    * Retrun decorations to Daemon
1. **Terminal Decorator Service** (_library_)
    * Accept requests from Daemon
    * Create decorations for shell prompt(s)
    * Retrun decorations to Daemon
1. **TMux Decorator Service** (_library_)
    * Accept requests from Daemon
    * Create decorations for tmux status bar
    * Retrun decorations to Daemon


## Decorator Responsibility
Information about:
* Path -> Terminal Decorator
* Git -> Terminal Decorator
* Terminal mode -> Terminal Decorator
* SSH -> Terminal Decorator
* User -> Terminal Decorator
* Command status -> Terminal Decorator
* Jobs -> Terminal Decorator
* System load -> TMux Decorator
* Uptime -> TMux Decorator
* Datetime -> TMux Decorator
* Virtual environment -> TMux Decorator
    * .NET
    * Python
    * Rust
    * Ruby
    * Elixir
    * Reason
    * NodeJS


## Implementation


## Exclusions
