using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Accion_.Web.Aplicacion.DTOs;
using SEGURIDAD.Accion_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Accion_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/acciones")]
    public class AccionController(IAccionCasoUso accionCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var acciones = await accionCasoUso.ListarAsync(ct);
            return Ok(acciones);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
          var s = await accionCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(s);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarAccionDTO request, CancellationToken ct)
        {
            await accionCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarAccionDTO request, CancellationToken ct)
        {
            await accionCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar([FromQuery] Guid id, CancellationToken ct)
        {
            await accionCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
