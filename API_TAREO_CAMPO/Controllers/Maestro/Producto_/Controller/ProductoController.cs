using MAESTRO.Producto_.Web.Aplicacion.DTOs;
using MAESTRO.Producto_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Maestro.Producto_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/maestro/productos")]
    public class ProductoController(IProductoCasoUso productoCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<ProductoDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var productos = await productoCasoUso.ListarAsync(ct);
            return Ok(productos);
        }

        [HttpGet("combo")]
        [ProducesResponseType<List<ProductoComboDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Combo(CancellationToken ct)
        {
            var combo = await productoCasoUso.ListarComboAsync(ct);
            return Ok(combo);
        }

        [HttpGet]
        [ProducesResponseType<ProductoDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorCodigo([FromQuery] string codigo, CancellationToken ct)
        {
            var producto = await productoCasoUso.ObtenerPorCodigoAsync(codigo, ct);
            return Ok(producto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarProductoDTO request, CancellationToken ct)
        {
            await productoCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] string codigo, [FromBody] ActualizarProductoDTO request, CancellationToken ct)
        {
            await productoCasoUso.ActualizarAsync(codigo, request, ct);
            return NoContent();
        }
    }
}
