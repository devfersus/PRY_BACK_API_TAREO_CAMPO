using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Modulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.Modulo_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Modulo_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/modulos")]
    public class ModuloController(IModuloCasoUso moduloCasoUso) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<List<ModuloDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var modulos = await moduloCasoUso.ListarAsync(ct);
            return Ok(modulos);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType<ModuloDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(Guid id, CancellationToken ct)
        {
            var modulo = await moduloCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(modulo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarModuloDTO request, CancellationToken ct)
        {
            await moduloCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery]Guid id, [FromBody] ActualizarModuloDTO request, CancellationToken ct)
        {
            await moduloCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar([FromQuery]Guid id, CancellationToken ct)
        {
            await moduloCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
