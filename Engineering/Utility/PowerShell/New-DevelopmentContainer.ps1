docker run `
    --name DecoR8R.NET `
    --workdir="/root" `
    --mount "type=volume,source=Projects,destination=/root/Projects" `
    --interactive `
    --tty `
    --cpu-shares=256 `
    --memory=8g `
    --memory-reservation=2g `
    --detach `
    mcr.microsoft.com/dotnet/sdk:5.0

