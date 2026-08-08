using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.AccionSubModulo_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/accion-submodulo")]
    public class AccionSubModuloController(IAccionSubModuloCasoUso accionSubModuloCasoUso) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
            await accionSubModuloCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarAccionSubModuloDTO request, CancellationToken ct)
        {
            await accionSubModuloCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarAccionSubModuloDTO request, CancellationToken ct)
        {
            await accionSubModuloCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar([FromQuery] Guid id, CancellationToken ct)
        {
            await accionSubModuloCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
