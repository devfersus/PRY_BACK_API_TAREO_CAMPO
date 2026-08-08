using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Permiso_.Web.Aplicacion.DTOs;
using SEGURIDAD.Permiso_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Permiso_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/permisos")]
    public class PermisoDetalleController(IPermisoDetalleCasoUso permisoDetalleCasoUso) : ControllerBase
    {
        [HttpGet("{permisoId:guid}/detalles")]
        [ProducesResponseType<List<PermisoDetalleDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarPorPermiso(Guid permisoId, CancellationToken ct)
        {
            var detalles = await permisoDetalleCasoUso.ListarPorPermisoAsync(permisoId, ct);
            return Ok(detalles);
        }

        [HttpPost("detalles")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPermisoDetallesDTO request, CancellationToken ct)
        {
            await permisoDetalleCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("detalles")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Actualizar([FromBody] List<ActualizarPermisoDetalleDTO> request, CancellationToken ct)
        {
            await permisoDetalleCasoUso.ActualizarAsync(request, ct);
            return NoContent();
        }

        [HttpDelete("detalles/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(Guid id, CancellationToken ct)
        {
            await permisoDetalleCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
