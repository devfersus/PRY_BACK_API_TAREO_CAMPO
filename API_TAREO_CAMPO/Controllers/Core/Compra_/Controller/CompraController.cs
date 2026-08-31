using CORE.Compra_.Web.Aplicacion.DTOs;
using CORE.Compra_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Core.Compra_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/core/compras")]
    public class CompraController(ICompraCasoUso compraCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<CompraListadoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var compras = await compraCasoUso.ListarAsync(ct);
            return Ok(compras);
        }

        [HttpGet]
        [ProducesResponseType<CompraDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
            var compra = await compraCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(compra);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarCompraDTO request, CancellationToken ct)
        {
            await compraCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarCompraDTO request, CancellationToken ct)
        {
            await compraCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpPost("detalle/masivo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarDetalleMasivo([FromBody] RegistrarCompraMasivoDTO request, CancellationToken ct)
        {
            await compraCasoUso.RegistrarDetallesMasivoAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("detalle/listar")]
        [ProducesResponseType<List<CompraDetalleListadoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarDetalles([FromQuery] string? codigoCompra, [FromQuery] string? codigoProveedor, CancellationToken ct)
        {
            var detalles = await compraCasoUso.ListarDetallesAsync(codigoCompra, codigoProveedor, ct);
            return Ok(detalles);
        }
    }
}
