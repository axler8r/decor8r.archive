$GitHubDir = "~/Projects/GitHub"
if (Test-Path $GitHubDir) {
    Push-Location -Path $GitHubDir
    Remove-Item -Recurse -Force go-app-powerline
    Remove-Item -Recurse -Force microsoft-pwsh-extension-ohmyposh
    Remove-Item -Recurse -Force microsoft-pwsh-extension-poshgit
    Remove-Item -Recurse -Force python-app-powerline
    Remove-Item -Recurse -Force rust-app-starship
    Pop-Location
}

