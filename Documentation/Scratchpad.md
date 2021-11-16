# Docopt
```text
decor8r

Usage:
    decor8r config new [<dir>]
    decor8r config import <file> [<dir>]
    decor8r config show
    decor8r config check [<dir>|<file>]
    decor8r config backup <gist> <repo>
    decor8r config restore <gist> <repo>
    decor8r decorate shell [shell_options] (bash|fish|zsh|pwsh)
    decor8r decorate tmux [tmux_options]
    decor8r decorate nvim [neovim_options]

Shell Options:
    -w, --width             Terminal width.
    -d, --directory=<dir>   Directory to decorate [default: ${PWD}].

Tmux Options:

Neovim Options:
```


# Priority List
1. `docker decorate shell`
    1. `zsh`
    1. `bash`
1. `docker decorate nvim`
1. `docker decorate tmux`
1. `docker config new`
1. `docker config show`
1. `docker config import`
1. `docker decorate shell`
    1. `pwsh`
    1. `fish`
1. `docker config check`
1. `docker config backup`
1. `docker config restore`
