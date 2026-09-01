using MAESTRO.UnidadMedida_.Web.Aplicacion.DTOs;
using MAESTRO.UnidadMedida_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Maestro.UnidadMedida_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/maestro/unidades-medida")]
    public class UnidadMedidaController(IUnidadMedidaCasoUso unidadMedidaCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<UnidadMedidaDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var unidades = await unidadMedidaCasoUso.ListarAsync(ct);
            return Ok(unidades);
        }

        [HttpGet("combo")]
        [ProducesResponseType<List<UnidadMedidaComboDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Combo(CancellationToken ct)
        {
            var combo = await unidadMedidaCasoUso.ListarComboAsync(ct);
            return Ok(combo);
        }

        [HttpGet]
        [ProducesResponseType<UnidadMedidaDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorCodigo([FromQuery] string codigo, CancellationToken ct)
        {
            var unidad = await unidadMedidaCasoUso.ObtenerPorCodigoAsync(codigo, ct);
            return Ok(unidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarUnidadMedidaDTO request, CancellationToken ct)
        {
            await unidadMedidaCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] string codigo, [FromBody] ActualizarUnidadMedidaDTO request, CancellationToken ct)
        {
            await unidadMedidaCasoUso.ActualizarAsync(codigo, request, ct);
            return NoContent();
        }
    }
}
