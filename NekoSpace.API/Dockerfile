#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
RUN dotnet new webapi -o app
RUN dotnet dev-certs https
RUN pwd && ls
CMD pwd && ls
RUN echo "$PWD"
RUN ls
RUN ls ..
CMD pwd

#COPY . /NekoSpace.API
COPY ["NekoSpace.API/NekoSpace.API.csproj", "NekoSpace.API/"]
#COPY ["NekoSpace.Core/NekoSpace.Core.csproj", "NekoSpace.Core/"]
#COPY ["NekoSpace.Seed/NekoSpace.Seed.csproj", "NekoSpace.Seed/"]
#COPY ["MamiRepository/Mami.csproj", "MamiRepository/"]
#COPY ["NekoSpace.Data/NekoSpace.Data.csproj", "NekoSpace.Data/"]
RUN dotnet restore "NekoSpace.API/NekoSpace.API.csproj"
COPY . .
WORKDIR "/src/NekoSpace.API"
RUN dotnet build "NekoSpace.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NekoSpace.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "NekoSpace.API.dll"]