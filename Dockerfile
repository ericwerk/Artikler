#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Artikler/Artikler.csproj Artikler/
RUN dotnet restore "Artikler/Artikler.csproj"
COPY . .
WORKDIR /src/Artikler
RUN dotnet build "Artikler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artikler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artikler.dll"]
