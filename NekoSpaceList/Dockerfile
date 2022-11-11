#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NekoSpaceList/NekoSpace.API.csproj", "NekoSpaceList/"]
COPY ["NekoSpace.Seed/NekoSpace.Seed.csproj", "NekoSpace.Seed/"]
COPY ["MamiRepository/Mami.csproj", "MamiRepository/"]
COPY ["NekoSpace.Data/NekoSpace.Data.csproj", "NekoSpace.Data/"]
RUN dotnet restore "NekoSpaceList/NekoSpace.API.csproj"
COPY . .
WORKDIR "/src/NekoSpaceList"
RUN dotnet build "NekoSpace.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NekoSpace.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NekoSpace.API.dll"]