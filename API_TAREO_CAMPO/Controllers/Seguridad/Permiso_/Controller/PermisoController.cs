using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Permiso_.Web.Aplicacion.DTOs;
using SEGURIDAD.Permiso_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Permiso_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/permisos")]
    public class PermisoController(IPermisoCasoUso permisoCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<PermisoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var permisos = await permisoCasoUso.ListarAsync(ct);
            return Ok(permisos);
        }

        [HttpGet]
        [ProducesResponseType<PermisoDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
            var permiso = await permisoCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(permiso);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPermisoDTO request, CancellationToken ct)
        {
            await permisoCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarPermisoDTO request, CancellationToken ct)
        {
            await permisoCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(Guid id, CancellationToken ct)
        {
            await permisoCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
