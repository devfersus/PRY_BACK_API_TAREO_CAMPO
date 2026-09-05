using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using System.Security.Claims;

namespace API_TAREO_CAMPO.Controllers.Seguridad.UsuarioPermiso_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/mis-permisos")]
    public class MisPermisosController(ITokenCache tokenCache) : ControllerBase
    {
        /// <summary>
        /// Devuelve las claves de permiso del usuario autenticado almacenadas en Redis.
        /// El frontend puede usar este endpoint para mostrar/ocultar secciones y acciones.
        /// Formato de cada clave: "MODULO|SUBMODULO|ACCION"
        /// </summary>
        [HttpGet]
        [ProducesResponseType<IReadOnlySet<string>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ObtenerMisPermisos(CancellationToken ct)
        {
            var usuarioIdTexto = User.FindFirstValue(ClaimTypes.NameIdentifier)
                              ?? User.FindFirstValue("sub");

            if (!Guid.TryParse(usuarioIdTexto, out var usuarioId))
                return Unauthorized();

            var permisos = await tokenCache.ObtenerPermisosAsync(usuarioId, ct);
            return Ok(permisos);
        }
    }
}
