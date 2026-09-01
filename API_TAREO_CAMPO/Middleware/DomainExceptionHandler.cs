using CORE.Ajuste_.Web.Dominio.Exceptions;
using CORE.Salida_.Web.Dominio.Exceptions;
using MAESTRO.Almacen_.Web.Dominio.Exceptions;
using MAESTRO.Categoria_.Web.Dominio.Exceptions;
using MAESTRO.Pais_.Web.Dominio.Exceptions;
using MAESTRO.Producto_.Web.Dominio.Exceptions;
using MAESTRO.UnidadMedida_.Web.Dominio.Exceptions;
using SEGURIDAD.Proveedor_.Web.Dominio.Exceptions;
using SEGURIDAD.Accion_.Web.Dominio.Exceptions;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Exceptions;
using SEGURIDAD.Modulo_.Web.Dominio.Exceptions;
using SEGURIDAD.Permiso_.Web.Dominio.Exceptions;
using SEGURIDAD.SubModulo_.Web.Dominio.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;

namespace API_TAREO_CAMPO.Middleware
{
    public class DomainExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            switch (exception)
            {
                case CredencialesInvalidasException credEx:
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Title  = "No autorizado",
                        Detail = credEx.Message
                    }, cancellationToken);
                    return true;

                case DominiIoExceptionUsuario domEx:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title  = "Regla de negocio violada",
                        Detail = domEx.Message
                    }, cancellationToken);
                    return true;

                case ProveedorNoEncontradoException provEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Proveedor no encontrado",
                        Detail = provEx.Message
                    }, cancellationToken);
                    return true;

                case PaisNoEncontradoException paisEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "País no encontrado",
                        Detail = paisEx.Message
                    }, cancellationToken);
                    return true;

                case AccionNoEncontradaException accionEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Acción no encontrada",
                        Detail = accionEx.Message
                    }, cancellationToken);
                    return true;

                case ModuloNoEncontradoException moduloEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Módulo no encontrado",
                        Detail = moduloEx.Message
                    }, cancellationToken);
                    return true;

                case SubModuloNoEncontradoException subModuloEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Submódulo no encontrado",
                        Detail = subModuloEx.Message
                    }, cancellationToken);
                    return true;

                case AccionSubModuloNoEncontradaException asmEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Acción-Submódulo no encontrada",
                        Detail = asmEx.Message
                    }, cancellationToken);
                    return true;

                case PermisoDetalleDuplicadoException dupEx:
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status409Conflict,
                        Title  = "Registro duplicado",
                        Detail = dupEx.Message
                    }, cancellationToken);
                    return true;

                case PermisoNoEncontradoException permisoEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Permiso no encontrado",
                        Detail = permisoEx.Message
                    }, cancellationToken);
                    return true;

                case UsuarioNoEncontradoException usuEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Usuario no encontrado",
                        Detail = usuEx.Message
                    }, cancellationToken);
                    return true;

                case CategoriaNoEncontradaException catEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Categoría no encontrada",
                        Detail = catEx.Message
                    }, cancellationToken);
                    return true;

                case ProductoNoEncontradoException prodEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Producto no encontrado",
                        Detail = prodEx.Message
                    }, cancellationToken);
                    return true;

                case UnidadMedidaNoEncontradaException umEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Unidad de medida no encontrada",
                        Detail = umEx.Message
                    }, cancellationToken);
                    return true;

                case AlmacenNoEncontradoException almEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Almacén no encontrado",
                        Detail = almEx.Message
                    }, cancellationToken);
                    return true;

                case SalidaNoEncontradaException salidaEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Salida no encontrada",
                        Detail = salidaEx.Message
                    }, cancellationToken);
                    return true;

                case AjusteNoEncontradoException ajusteEx:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title  = "Ajuste no encontrado",
                        Detail = ajusteEx.Message
                    }, cancellationToken);
                    return true;

                case DbUpdateException dbEx when dbEx.InnerException?.Message
                        .Contains("duplicate", StringComparison.OrdinalIgnoreCase) == true:
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status409Conflict,
                        Title  = "Conflicto de datos",
                        Detail = "Ya existe un registro con esos datos."
                    }, cancellationToken);
                    return true;

                default:
                    return false;
            }
        }
    }
}
