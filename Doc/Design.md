# Design
`DecoR8R` informs its users about their environment. It does not try to display all relevant and pertinent information on the command line. Instead, it shares the repsonsibility to inform accross `tmux`, `nvim` and the shell (`zsh`, `bash`, `pwsh` and `fish`).

It is opinionated. It does not try to cover all tools or environements.


## Goals
* Sensible defaults
* Intuitive
* Themes


## Questions
* Should PWD be handled as:
    1. [ ] A string
    1. [ ] A DirectoryInfo


## Components
1. CLI
    * Generate the CLI
    * Parse the CLI
    * Invoke Services
1. Configuration Service
    * Add, remove, find, modify configuration elements
1. NeoVim Decorator Service
    * Decorate NeoVim status bar
    * Decorate NeoVim tab bar
1. Terminal Decorator Service
    * Decorate terminal command prompt
1. TMux Decorator Service
    * Decorate TMux status bar


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
