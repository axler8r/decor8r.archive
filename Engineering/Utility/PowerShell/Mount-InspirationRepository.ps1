$GitHubDir = "~/Projects/GitHub"
if (-Not (Test-Path $GitHubDir)) {
    New-Item -ItemType Directory $GitHubDir
}
else {
    Push-Location -Path $GitHubDir
    git clone https://github.com/justjanne/powerline-go.git     go-app-powerline
    git clone https://github.com/JanDeDobbeleer/oh-my-posh.git  microsoft-pwsh-extension-ohmyposh
    git clone https://github.com/dahlbyk/posh-git.git           microsoft-pwsh-extension-poshgit
    git clone https://github.com/powerline/powerline.git        python-app-powerline
    git clone https://github.com/starship/starship.git          rust-app-starship
    Pop-Location
}
