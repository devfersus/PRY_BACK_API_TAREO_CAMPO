# ─── Stage 1: Build ────────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar .csproj primero → maximiza caché de Docker para restore
COPY ["API_TAREO_CAMPO/API_TAREO_CAMPO.csproj", "API_TAREO_CAMPO/"]
COPY ["SEGURIDAD/SEGURIDAD.csproj",             "SEGURIDAD/"]
COPY ["MAESTRO/MAESTRO.csproj",                 "MAESTRO/"]
COPY ["CORE/CORE.csproj",                       "CORE/"]

RUN dotnet restore "API_TAREO_CAMPO/API_TAREO_CAMPO.csproj"

# Copiar código fuente completo de los 4 proyectos
COPY API_TAREO_CAMPO/ API_TAREO_CAMPO/
COPY SEGURIDAD/       SEGURIDAD/
COPY MAESTRO/         MAESTRO/
COPY CORE/            CORE/

WORKDIR /src/API_TAREO_CAMPO
RUN dotnet build "API_TAREO_CAMPO.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ─── Stage 2: Publish ──────────────────────────────────────────────────────────
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "API_TAREO_CAMPO.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# ─── Stage 3: Runtime (Linux) ──────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_TAREO_CAMPO.dll"]
