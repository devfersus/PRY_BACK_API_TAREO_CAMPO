using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.DTOs;
using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.UsuarioPermiso_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/usuario-permisos")]
    public class UsuarioPermisoController(IUsuarioPermisoCasoUso usuarioPermisoCasoUso) : ControllerBase
    {
        [HttpGet("{usuarioId:guid}")]
        [ProducesResponseType<List<UsuarioPermisoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarPorUsuario(Guid usuarioId, CancellationToken ct)
        {
            var resultado = await usuarioPermisoCasoUso.ListarPorUsuarioAsync(usuarioId, ct);
            return Ok(resultado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Asignar([FromBody] AsignarUsuarioPermisoDTO request, CancellationToken ct)
        {
            await usuarioPermisoCasoUso.AsignarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Revocar(
            [FromQuery] Guid usuarioId,
            [FromQuery] Guid permisoId,
            CancellationToken ct)
        {
            await usuarioPermisoCasoUso.RevocarAsync(usuarioId, permisoId, ct);
            return NoContent();
        }
    }
}
