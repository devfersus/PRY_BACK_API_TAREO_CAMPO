# TAREO CAMPO — Backend API

API RESTful para la gestión de seguridad y control de acceso del sistema de tareo de campo. Provee autenticación basada en JWT, control de acceso basado en roles (RBAC) y administración de datos maestros.

---

## Stack tecnológico

| Componente        | Tecnología                                      |
|-------------------|-------------------------------------------------|
| Framework         | ASP.NET Core 8.0 (C#)                          |
| Base de datos     | PostgreSQL (Npgsql EF Core 9.0)                |
| ORM               | Entity Framework Core 9.0                      |
| Autenticación     | JWT Bearer (Microsoft.AspNetCore.Authentication) |
| Caché             | Redis (StackExchange.Redis 2.x)                |
| Documentación API | Swagger (Swashbuckle) + Scalar                 |
| Contenedores      | Docker + Docker Compose                        |
| CI/CD             | GitHub Actions                                 |

---

## Arquitectura

El proyecto implementa **Arquitectura Hexagonal (Ports & Adapters)** con principios de **Domain-Driven Design (DDD)**:

```
Entidad / Value Objects  →  Dominio
Casos de Uso / DTOs      →  Aplicación
Repositorios / EF Core   →  Infraestructura
Controllers              →  Capa API (adaptadores de entrada)
```

Cada módulo de negocio es autónomo y sigue la misma estructura interna.

---

## Estructura del proyecto

```
PROYECTO_TAREO_CAMPO/
├── API_TAREO_CAMPO/              # Proyecto principal ASP.NET Core
│   ├── Program.cs                # Configuración de la app y middlewares
│   └── appsettings*.json         # Configuración por entorno
├── SEGURIDAD/                    # Dominio de seguridad
│   ├── Usuario_/                 # Gestión de usuarios
│   ├── Login_/                   # Autenticación / generación de token
│   ├── Modulo_/                  # Módulos del sistema
│   ├── SubModulo_/               # Sub-módulos del sistema
│   ├── Accion_/                  # Acciones/operaciones
│   ├── AccionSubModulo_/         # Relación acción ↔ sub-módulo
│   ├── Permiso_/                 # Conjuntos de permisos
│   └── Infraestructura/          # DbContext de seguridad
├── MAESTRO/                      # Dominio de datos maestros
│   └── Pais_/                    # Países
├── CONFIGURACION/                # Librería de configuración compartida
├── Dockerfile                    # Build multi-etapa
└── docker-compose.yml            # Orquestación de servicios
```

Cada módulo de negocio tiene la siguiente estructura interna:

```
Modulo_/
└── Web/
    ├── Dominio/
    │   ├── Entidad/              # Entidades del dominio
    │   └── ValueObject/          # Objetos de valor (Email, Nombre, etc.)
    ├── Aplicacion/
    │   ├── Ports/                # Interfaces (contratos)
    │   ├── CasosUso/             # Servicios de aplicación
    │   └── DTOs/                 # Objetos de transferencia
    └── Infraestructura/
        ├── Persistencia/         # Configuraciones EF Core
        └── Repositorio/          # Acceso a datos
```

---

## Requisitos previos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 14+](https://www.postgresql.org/)
- [Redis 7+](https://redis.io/)
- [Docker](https://www.docker.com/) *(opcional, para ejecución con contenedores)*

---

## Configuración

Crea o edita `API_TAREO_CAMPO/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "SeguridadDb": "Host=ls;Port=xxx;Database=xxxx;Username=xxxx;Password=tu_password",
    "Redis": "localhost:6379,abortConnect=false"
  },
  "Jwt": {
    "Issuer": "tareo-campo-api",
    "Audience": "tareo-campo-client",
    "ExpirationMinutes": 1440,
    "SecretKey": "tu-clave-secreta-de-al-menos-32-caracteres!"
  }
}
```

> **Nunca** incluyas credenciales reales en el repositorio. Usa variables de entorno o secretos en producción.

---

## Cómo ejecutar

### Ejecución local

```bash
# Restaurar dependencias y ejecutar
dotnet restore
dotnet run --project API_TAREO_CAMPO
```

La API estará disponible en:
- HTTP: `http://localhost:5179`
- HTTPS: `https://localhost:7092`
- Swagger UI: `http://localhost:5179/scalar/v1#tag/accion`

### Ejecución con Docker Compose

```bash
docker-compose up -d --build
```

La API estará disponible en `http://localhost:8080`.

Los servicios levantados son:
- `api` — ASP.NET Core en el puerto 8080
- `redis` — Redis 7 Alpine en el puerto 6379

---

## Endpoints de la API

### Autenticación

| Método | Endpoint                        | Descripción               |
|--------|---------------------------------|---------------------------|
| POST   | `/api/seguridad/auth/login`     | Login — retorna token JWT |

### Usuarios

| Método | Endpoint                               | Descripción             |
|--------|----------------------------------------|-------------------------|
| GET    | `/api/seguridad/usuarios`              | Listar usuarios         |
| GET    | `/api/seguridad/usuarios/detalle`      | Detalle de usuario      |
| POST   | `/api/seguridad/usuarios`              | Crear usuario           |
| PUT    | `/api/seguridad/usuarios`              | Actualizar usuario      |
| DELETE | `/api/seguridad/usuarios`              | Eliminar usuario        |

### Módulos

| Método | Endpoint                          | Descripción           |
|--------|-----------------------------------|-----------------------|
| GET    | `/api/seguridad/modulos`          | Listar módulos        |
| GET    | `/api/seguridad/modulos/{id}`     | Obtener módulo        |
| POST   | `/api/seguridad/modulos`          | Crear módulo          |
| PUT    | `/api/seguridad/modulos`          | Actualizar módulo     |
| DELETE | `/api/seguridad/modulos`          | Eliminar módulo       |

### Sub-Módulos

| Método | Endpoint                              | Descripción               |
|--------|---------------------------------------|---------------------------|
| GET    | `/api/seguridad/sub-modulos`          | Listar sub-módulos        |
| GET    | `/api/seguridad/sub-modulos/{id}`     | Obtener sub-módulo        |
| POST   | `/api/seguridad/sub-modulos`          | Crear sub-módulo          |
| PUT    | `/api/seguridad/sub-modulos`          | Actualizar sub-módulo     |
| DELETE | `/api/seguridad/sub-modulos`          | Eliminar sub-módulo       |

### Acciones

| Método | Endpoint                         | Descripción           |
|--------|----------------------------------|-----------------------|
| GET    | `/api/seguridad/acciones`        | Listar acciones       |
| GET    | `/api/seguridad/acciones/{id}`   | Obtener acción        |
| POST   | `/api/seguridad/acciones`        | Crear acción          |
| PUT    | `/api/seguridad/acciones`        | Actualizar acción     |
| DELETE | `/api/seguridad/acciones`        | Eliminar acción       |

### Permisos

| Método | Endpoint                               | Descripción                   |
|--------|----------------------------------------|-------------------------------|
| GET    | `/api/seguridad/permisos`              | Listar permisos               |
| GET    | `/api/seguridad/permisos/{id}`         | Obtener permiso               |
| POST   | `/api/seguridad/permisos`              | Crear permiso                 |
| PUT    | `/api/seguridad/permisos`              | Actualizar permiso            |
| DELETE | `/api/seguridad/permisos`              | Eliminar permiso              |
| GET    | `/api/seguridad/permisos/detalles`     | Listar detalles de permisos   |
| POST   | `/api/seguridad/permisos/detalles`     | Agregar detalle de permiso    |
| PUT    | `/api/seguridad/permisos/detalles`     | Actualizar detalle de permiso |
| DELETE | `/api/seguridad/permisos/detalles`     | Eliminar detalle de permiso   |

### Datos Maestros — Países

| Método | Endpoint                     | Descripción       |
|--------|------------------------------|-------------------|
| GET    | `/api/maestro/paises`        | Listar países     |
| GET    | `/api/maestro/paises/{id}`   | Obtener país      |
| POST   | `/api/maestro/paises`        | Crear país        |
| PUT    | `/api/maestro/paises/{id}`   | Actualizar país   |
| DELETE | `/api/maestro/paises/{id}`   | Eliminar país     |

---

## Flujo de autenticación

```
Cliente  →  POST /auth/login (email + contraseña)
         ←  Token JWT

Cliente  →  GET /cualquier-endpoint (Authorization: Bearer <token>)
         →  Middleware valida token en Redis
         →  Si válido: continúa
         ←  Si inválido/expirado: 401 Unauthorized
```

El token JWT es almacenado en Redis al momento del login y validado en cada solicitud mediante el middleware `TokenCacheValidationMiddleware`. El tiempo de expiración predeterminado es de **1440 minutos (24 horas)**.

---

## CI/CD

El pipeline de despliegue está configurado en `.github/workflows/deploy.yml`:

- **Disparador**: push a la rama `migrations`
- **Proceso**: conexión SSH al servidor → `docker-compose up -d --build`
- **Servidor destino**: `/opt/PRY_SECURITY_BACK_API`
