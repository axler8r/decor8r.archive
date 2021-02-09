docker run `
    --name seq `
    --detach `
    --restart unless-stopped `
    --env ACCEPT_EULA=Y `
    --publish 5341:80 datalust/seq:2021.1
