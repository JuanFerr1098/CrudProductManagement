# =============================
# Etapa 1: Build de la aplicación
# =============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo el archivo del proyecto y restaurar dependencias
COPY CrudProductManagement/CrudProductManagement/CrudProductManagement.csproj CrudProductManagement/
RUN dotnet restore CrudProductManagement/CrudProductManagement.csproj

# Copiar todo el código fuente
COPY CrudProductManagement/ CrudProductManagement/
WORKDIR /src/CrudProductManagement

# Compilar y publicar en modo Release
RUN dotnet publish -c Release -o /app/publish

# =============================
# Etapa 2: Runtime (ejecución)
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CrudProductManagement.dll"]
