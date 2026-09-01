using CORE.Kardex_.Web.Aplicacion.DTOs;
using CORE.Kardex_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Core.Kardex_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/core/kardex")]
    public class KardexController(IKardexCasoUso kardexCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<KardexDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var movimientos = await kardexCasoUso.ListarAsync(ct);
            return Ok(movimientos);
        }

        [HttpGet]
        [ProducesResponseType<List<KardexDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarPorProductoAlmacen(
            [FromQuery] string codigoProducto,
            [FromQuery] string? codigoAlmacen,
            CancellationToken ct)
        {
            var movimientos = await kardexCasoUso.ListarPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);
            return Ok(movimientos);
        }
    }
}
