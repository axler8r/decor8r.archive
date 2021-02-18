docker run `
    --name decor8r.net `
    --interactive `
    --tty `
    --mount 'type=volume,source=projects,destination=/root/Projects/AxlER8R' `
    --detach mcr.microsoft.com/dotnet/sdk:5.0
