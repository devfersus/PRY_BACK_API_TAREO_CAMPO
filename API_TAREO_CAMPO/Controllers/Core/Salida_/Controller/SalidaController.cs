using CORE.Salida_.Web.Aplicacion.DTOs;
using CORE.Salida_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Core.Salida_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/core/salidas")]
    public class SalidaController(ISalidaCasoUso salidaCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<SalidaListadoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var salidas = await salidaCasoUso.ListarAsync(ct);
            return Ok(salidas);
        }

        [HttpGet]
        [ProducesResponseType<SalidaDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
            var salida = await salidaCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(salida);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarSalidaDTO request, CancellationToken ct)
        {
            await salidaCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarSalidaDTO request, CancellationToken ct)
        {
            await salidaCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpPost("detalle/masivo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarDetalleMasivo([FromBody] RegistrarSalidaMasivoDTO request, CancellationToken ct)
        {
            await salidaCasoUso.RegistrarDetallesMasivoAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("detalle/listar")]
        [ProducesResponseType<List<SalidaDetalleListadoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarDetalles([FromQuery] string? codigoSalida, CancellationToken ct)
        {
            var detalles = await salidaCasoUso.ListarDetallesAsync(codigoSalida, ct);
            return Ok(detalles);
        }
    }
}
