#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DecOR8R.Daemon/DecOR8R.Daemon.csproj", "DecOR8R.Daemon/"]
RUN dotnet restore "DecOR8R.Daemon/DecOR8R.Daemon.csproj"
COPY . .
WORKDIR "/src/DecOR8R.Daemon"
RUN dotnet build "DecOR8R.Daemon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DecOR8R.Daemon.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DecOR8R.Daemon.dll"]