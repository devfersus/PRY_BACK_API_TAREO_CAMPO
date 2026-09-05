using API_TAREO_CAMPO.Authorization;
using CORE.Ajuste_.Web.Aplicacion.DTOs;
using CORE.Ajuste_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Core.Ajuste_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/core/ajustes")]
    public class AjusteController(IAjusteCasoUso ajusteCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<AjusteListadoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var ajustes = await ajusteCasoUso.ListarAsync(ct);
            return Ok(ajustes);
        }

        [HttpGet]
        [ProducesResponseType<AjusteDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
            var ajuste = await ajusteCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(ajuste);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarAjusteDTO request, CancellationToken ct)
        {
            await ajusteCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarAjusteDTO request, CancellationToken ct)
        {
            await ajusteCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpPost("detalle/masivo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarDetalleMasivo([FromBody] RegistrarAjusteMasivoDTO request, CancellationToken ct)
        {
            await ajusteCasoUso.RegistrarDetallesMasivoAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("detalle/listar")]
        [ProducesResponseType<List<AjusteDetalleListadoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarDetalles([FromQuery] string? codigoAjuste, CancellationToken ct)
        {
            var detalles = await ajusteCasoUso.ListarDetallesAsync(codigoAjuste, ct);
            return Ok(detalles);
        }
    }
}
