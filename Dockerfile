# Usar la imagen base de .NET SDK (para compilar el proyecto)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establecer el directorio de trabajo en /app
WORKDIR /app

# Copiar todos los archivos del proyecto
COPY . .

# Restaurar las dependencias de NuGet
RUN dotnet restore

# Compilar el proyecto
RUN dotnet build -c Release -o /app/out

# Publicar la aplicaci�n (prepararla para producci�n)
RUN dotnet publish -c Release -o /app/out

# Usar la imagen base de ASP.NET para ejecutar la aplicaci�n
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/out .

# Configurar el punto de entrada para ejecutar la aplicaci�n
ENTRYPOINT ["dotnet", "CatalogApi.dll"]
