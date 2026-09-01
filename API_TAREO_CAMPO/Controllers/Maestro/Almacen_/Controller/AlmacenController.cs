using MAESTRO.Almacen_.Web.Aplicacion.DTOs;
using MAESTRO.Almacen_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Maestro.Almacen_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/maestro/almacenes")]
    public class AlmacenController(IAlmacenCasoUso almacenCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<AlmacenDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var almacenes = await almacenCasoUso.ListarAsync(ct);
            return Ok(almacenes);
        }

        [HttpGet("combo")]
        [ProducesResponseType<List<AlmacenComboDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Combo(CancellationToken ct)
        {
            var combo = await almacenCasoUso.ListarComboAsync(ct);
            return Ok(combo);
        }

        [HttpGet]
        [ProducesResponseType<AlmacenDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorCodigo([FromQuery] string codigo, CancellationToken ct)
        {
            var almacen = await almacenCasoUso.ObtenerPorCodigoAsync(codigo, ct);
            return Ok(almacen);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarAlmacenDTO request, CancellationToken ct)
        {
            await almacenCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] string codigo, [FromBody] ActualizarAlmacenDTO request, CancellationToken ct)
        {
            await almacenCasoUso.ActualizarAsync(codigo, request, ct);
            return NoContent();
        }
    }
}
