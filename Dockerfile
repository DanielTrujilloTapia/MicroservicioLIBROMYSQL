# Imagen base con .NET 9 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagen para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["uttt.Micro.Libro.csproj", "/src/"]
WORKDIR /src
RUN dotnet restore

COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Publicar
FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish --no-restore

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["appsettings.json", "."]
ENTRYPOINT ["dotnet", "uttt.Micro.Libro.dll"]
