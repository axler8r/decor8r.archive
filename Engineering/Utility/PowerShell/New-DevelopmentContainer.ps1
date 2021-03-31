docker run `
    --detach `
    --mount 'type=volume,source=projects,destination=/root/Projects/AxlER8R' `
    --interactive `
    --tty `
    --name decor8r.net `
    mcr.microsoft.com/dotnet/sdk:5.0
