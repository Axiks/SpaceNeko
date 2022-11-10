#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /source
COPY ["NekoSpaceList/NekoSpace.API.csproj", "NekoSpaceList/"]
COPY ["NekoSpace.Seed/NekoSpace.Seed.csproj", "NekoSpace.Seed/"]
COPY ["MamiRepository/Mami.csproj", "MamiRepository/"]
COPY ["NekoSpace.Data/NekoSpace.Data.csproj", "NekoSpace.Data/"]
RUN dotnet restore "NekoSpaceList/NekoSpace.API.csproj"
COPY . .
WORKDIR "/source/NekoSpaceList"
RUN dotnet build "NekoSpace.API.csproj" -c Release -o /app/build

FROM base AS final
WORKDIR /app
COPY --from=build  /app ./
RUN dotnet ef database update
ENTRYPOINT ["dotnet", "NekoSpace.API.dll"]