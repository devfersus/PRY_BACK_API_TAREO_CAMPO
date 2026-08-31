using MAESTRO.Categoria_.Web.Aplicacion.DTOs;
using MAESTRO.Categoria_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Maestro.Categoria_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/maestro/categorias")]
    public class CategoriaController(ICategoriaCasoUso categoriaCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [ProducesResponseType<List<CategoriaDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var categorias = await categoriaCasoUso.ListarAsync(ct);
            return Ok(categorias);
        }

        [HttpGet("combo")]
        [ProducesResponseType<List<CategoriaComboDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Combo(CancellationToken ct)
        {
            var combo = await categoriaCasoUso.ListarComboAsync(ct);
            return Ok(combo);
        }

        [HttpGet]
        [ProducesResponseType<CategoriaDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorCodigo([FromQuery] string codigo, CancellationToken ct)
        {
            var categoria = await categoriaCasoUso.ObtenerPorCodigoAsync(codigo, ct);
            return Ok(categoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarCategoriaDTO request, CancellationToken ct)
        {
            await categoriaCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] string codigo, [FromBody] ActualizarCategoriaDTO request, CancellationToken ct)
        {
            await categoriaCasoUso.ActualizarAsync(codigo, request, ct);
            return NoContent();
        }
    }
}
