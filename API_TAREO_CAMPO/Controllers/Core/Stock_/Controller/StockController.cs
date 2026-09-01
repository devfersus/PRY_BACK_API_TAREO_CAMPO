using CORE.Stock_.Web.Aplicacion.DTOs;
using CORE.Stock_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Core.Stock_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/core/stock")]
    public class StockController(IStockCasoUso stockCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<StockDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var stocks = await stockCasoUso.ListarAsync(ct);
            return Ok(stocks);
        }

        [HttpGet]
        [ProducesResponseType<StockDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorProductoAlmacen(
            [FromQuery] string codigoProducto,
            [FromQuery] string? codigoAlmacen,
            CancellationToken ct)
        {
            var stock = await stockCasoUso.ObtenerPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);
            if (stock is null) return NotFound();
            return Ok(stock);
        }

        [HttpGet("alertas")]
        [ProducesResponseType<List<StockDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Alertas(CancellationToken ct)
        {
            var alertas = await stockCasoUso.ListarAlertasAsync(ct);
            return Ok(alertas);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ConfigurarLimites(
            [FromQuery] string codigoProducto,
            [FromQuery] string? codigoAlmacen,
            [FromBody] ConfigurarStockDTO request,
            CancellationToken ct)
        {
            await stockCasoUso.ConfigurarLimitesAsync(codigoProducto, codigoAlmacen, request, ct);
            return NoContent();
        }
    }
}
