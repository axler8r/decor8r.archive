Push-Location -Path "~/Projects/GitHub"
Remove-Item -Recurse -Force go-app-powerline
Remove-Item -Recurse -Force microsoft-pwsh-extension-ohmyposh
Remove-Item -Recurse -Force microsoft-pwsh-extension-poshgit
Remove-Item -Recurse -Force python-app-powerline
Remove-Item -Recurse -Force rust-app-starship
Pop-Location
